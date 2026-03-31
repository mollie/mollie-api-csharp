#nullable enable
namespace Mollie.Utils
{
    using System;
    using Mollie;
    using Mollie.Models.Components;

    public static class MollieAuthUtils
    {
        public static bool CanHaveGlobalFields(object? securitySource)
        {
            if (securitySource == null)
                return false;

            Security? security = null;
            if (securitySource is Func<Security> securityFunc)
                security = securityFunc();
            else if (securitySource is Security s)
                security = s;

            if (security == null)
                return false;

            string? token = security.ApiKey ?? security.OrganizationAccessToken ?? security.OAuth;
            return token != null && token.StartsWith("access_");
        }

        public static bool HasGlobalFields(SDKConfig config)
        {
            return !string.IsNullOrEmpty(config.ProfileId) || config.Testmode.HasValue;
        }
    }
}
