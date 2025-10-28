using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Mollie.Utils;

namespace Mollie.Hooks
{
    public class MollieHooks : IBeforeRequestHook
    {
        public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            HandleIdempotencyKey(request.Headers);
            CustomizeUserAgent(request.Headers, hookCtx);

            return Task.FromResult(request);
        }

        private void HandleIdempotencyKey(HttpRequestHeaders headers)
        {
            if (!headers.Contains("idempotency-key"))
            {
                headers.Add("idempotency-key", GenerateIdempotencyKey());
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

        private static string GenerateIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}