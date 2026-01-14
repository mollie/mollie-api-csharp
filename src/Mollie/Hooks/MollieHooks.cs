using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mollie.Utils;

namespace Mollie.Hooks
{
    public class MollieHooks : IBeforeRequestHook
    {
        public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            // Validate path parameters
            ValidatePathParameters(request);

            // Add the idempotency key if it doesn't already exist
            HandleIdempotencyKey(request.Headers);

            // Customize the User Agent header
            CustomizeUserAgent(request.Headers, hookCtx);

            // Then populate profile ID and testmode if OAuth
            if (IsOAuthRequest(request.Headers, hookCtx))
            {
                Console.WriteLine("Populating profileId and testmode for OAuth request");
                PopulateProfileIdAndTestmode(request, hookCtx);
            }

            return Task.FromResult(request);
        }

        private void ValidatePathParameters(HttpRequestMessage request)
        {
            var pathSegments = request.RequestUri.AbsolutePath.Split('/');

            for (int i = 0; i < pathSegments.Length; i++)
            {
                if (i == 0 && pathSegments[i] == "")
                {
                    continue;
                }

                if (string.IsNullOrEmpty(pathSegments[i]) || string.IsNullOrWhiteSpace(pathSegments[i]))
                {
                    throw new InvalidOperationException(
                        $"Invalid request: empty path parameter detected in [{request.Method}] '{request.RequestUri.AbsolutePath}'");
                }
            }
        }

        private bool IsOAuthRequest(HttpRequestHeaders headers, BeforeRequestContext hookCtx)
        {
            var securitySource = hookCtx.SecuritySource;

            if (securitySource == null)
            {
                return false;
            }

            // If SecuritySource is a Func, invoke it to get the actual Security object
            object security = securitySource;
            if (securitySource is Delegate del)
            {
                security = del.DynamicInvoke();
            }

            if (security == null)
            {
                return false;
            }

            var oAuthProperty = security.GetType().GetProperty("OAuth");

            if (oAuthProperty == null)
            {
                return false;
            }

            var oAuthValue = oAuthProperty.GetValue(security) as string;

            if (string.IsNullOrEmpty(oAuthValue))
            {
                return false;
            }

            var authHeader = headers.Authorization?.ToString();
            var result = authHeader == $"Bearer {oAuthValue}";
            return result;
        }

        private void HandleIdempotencyKey(HttpRequestHeaders headers)
        {
            const string idempotencyKey = "idempotency-key";
            if (!headers.Contains(idempotencyKey) ||
                string.IsNullOrEmpty(headers.GetValues(idempotencyKey).FirstOrDefault()))
            {
                headers.Remove(idempotencyKey);
                headers.Add(idempotencyKey, GenerateIdempotencyKey());
            }
        }

        private void CustomizeUserAgent(HttpRequestHeaders headers, BeforeRequestContext hookCtx)
        {
            const string userAgentKey = "User-Agent";

            string? customUserAgent = hookCtx.SDKConfiguration.CustomUserAgent;

            // Parse from existing UserAgent string: "speakeasy-sdk/csharp 0.9.0 2.731.4 1.0.0 Mollie"
            string[] userAgentParts = hookCtx.SDKConfiguration.UserAgent.Split(' ');
            string sdkVersion = userAgentParts[1];
            string genVersion = userAgentParts[2];
            string packageName = userAgentParts[4];

            string mollieUserAgent = $"Speakeasy/{genVersion} CSharp/{Environment.Version} {packageName}/{sdkVersion}";
            if (!string.IsNullOrEmpty(customUserAgent))
            {
                mollieUserAgent = $"{mollieUserAgent} {customUserAgent}";
            }

            headers.Remove(userAgentKey);
            headers.Add(userAgentKey, mollieUserAgent);
        }

        private void PopulateProfileIdAndTestmode(HttpRequestMessage request, BeforeRequestContext hookCtx)
        {
            var clientProfileId = hookCtx.SDKConfiguration.ProfileId;
            var clientTestmode = hookCtx.SDKConfiguration.Testmode;

            // Get the HTTP method
            var method = request.Method;

            if (method == HttpMethod.Get)
            {
                // Update the query parameters. If testmode or profileId are not present, add them.
                var uriBuilder = new UriBuilder(request.RequestUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);

                // Add profileId if not already present
                if (!string.IsNullOrEmpty(clientProfileId) && string.IsNullOrEmpty(query["profileId"]))
                {
                    query["profileId"] = clientProfileId;
                }

                // Add testmode if not already present
                if (clientTestmode.HasValue && string.IsNullOrEmpty(query["testmode"]))
                {
                    query["testmode"] = clientTestmode.Value.ToString().ToLower();
                }

                uriBuilder.Query = query.ToString();
                request.RequestUri = uriBuilder.Uri;
            }
            else
            {
                // It's POST, DELETE, PATCH
                // Update the JSON body. If testmode or profileId are not present, add them.
                if (request.Content != null)
                {
                    var contentString = request.Content.ReadAsStringAsync().Result;
                    JsonDocument body;

                    try
                    {
                        body = string.IsNullOrEmpty(contentString)
                            ? JsonDocument.Parse("{}")
                            : JsonDocument.Parse(contentString);
                    }
                    catch (JsonException)
                    {
                        // If it's not JSON, return unchanged
                        return;
                    }

                    var bodyDict = new Dictionary<string, object>();
                    foreach (var property in body.RootElement.EnumerateObject())
                    {
                        bodyDict[property.Name] = JsonSerializer.Deserialize<object>(property.Value.GetRawText());
                    }

                    // Add profileId if not already present
                    if (!string.IsNullOrEmpty(clientProfileId) && !bodyDict.ContainsKey("profileId"))
                    {
                        bodyDict["profileId"] = clientProfileId;
                    }

                    // Add testmode if not already present
                    if (clientTestmode.HasValue && !bodyDict.ContainsKey("testmode"))
                    {
                        bodyDict["testmode"] = clientTestmode.Value;
                    }

                    // Create new content with updated body
                    var newContentString = JsonSerializer.Serialize(bodyDict);
                    var newContent = new StringContent(newContentString, Encoding.UTF8, "application/json");

                    request.Content = newContent;
                }
            }
        }

        private static string GenerateIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
