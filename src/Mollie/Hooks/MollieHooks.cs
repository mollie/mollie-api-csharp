using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Mollie.Utils;

namespace Mollie.Hooks
{
    public class MollieHooks : IBeforeRequestHook
    {
        private readonly Dictionary<string, HashSet<string>> _globalUsage;

        public MollieHooks()
        {
            _globalUsage = new Dictionary<string, HashSet<string>>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Mollie.Hooks.global_usage.json";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
            {
                using var reader = new StreamReader(stream);
                var json = reader.ReadToEnd();
                var raw = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                if (raw != null)
                {
                    foreach (var kv in raw)
                        _globalUsage[kv.Key] = new HashSet<string>(kv.Value);
                }
            }
        }
        public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            // Validate path parameters
            ValidatePathParameters(request);

            // Add the idempotency key if it doesn't already exist
            HandleIdempotencyKey(request.Headers);

            // Customize the User Agent header
            CustomizeUserAgent(request.Headers, hookCtx);

            // Inject global fields (profileId, testmode) based on operation ID
            if (MollieAuthUtils.CanHaveGlobalFields(hookCtx.SecuritySource))
            {
                InjectGlobalFields(request, hookCtx);
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

        private void InjectGlobalFields(HttpRequestMessage request, BeforeRequestContext hookCtx)
        {
            var operationId = hookCtx.OperationID;

            // Build globals dict from SDKConfiguration (only non-null values)
            var globals = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(hookCtx.SDKConfiguration.ProfileId))
                globals["profileId"] = hookCtx.SDKConfiguration.ProfileId!;
            if (hookCtx.SDKConfiguration.Testmode.HasValue)
                globals["testmode"] = hookCtx.SDKConfiguration.Testmode.Value;

            // Find fields whose operation list contains this operation ID and that have a value
            var fieldsToInject = _globalUsage
                .Where(kv => kv.Value.Contains(operationId) && globals.ContainsKey(kv.Key))
                .ToDictionary(kv => kv.Key, kv => globals[kv.Key]);

            if (fieldsToInject.Count == 0)
                return;

            if (request.Content == null)
                return;

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
                return;
            }

            var bodyDict = new Dictionary<string, JsonElement>();
            foreach (var property in body.RootElement.EnumerateObject())
                bodyDict[property.Name] = property.Value.Clone();

            foreach (var (field, value) in fieldsToInject)
            {
                if (!bodyDict.ContainsKey(field))
                    bodyDict[field] = JsonSerializer.SerializeToElement(value);
            }

            request.Content = new StringContent(
                JsonSerializer.Serialize(bodyDict), Encoding.UTF8, "application/json");
        }

        private static string GenerateIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
