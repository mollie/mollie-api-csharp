using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Mollie.Utils;

namespace Mollie.Hooks
{
    public class MollieHooks: IBeforeRequestHook
    {
        public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if (!request.Headers.Contains("idempotency-key"))
            {
                request.Headers.Add("idempotency-key", GenerateIdempotencyKey());
            }

            return Task.FromResult(request);
        }

        private static string GenerateIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}