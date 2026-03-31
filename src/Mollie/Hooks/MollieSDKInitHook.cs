#nullable enable
namespace Mollie.Hooks
{
    using System;
    using Mollie.Utils;

    public class MollieSDKInitHook : ISDKInitHook
    {
        public SDKConfig SDKInit(SDKConfig config)
        {
            if (!MollieAuthUtils.CanHaveGlobalFields(config.SecuritySource) && MollieAuthUtils.HasGlobalFields(config))
            {
                throw new ArgumentException("Global fields like testmode and profileId can only be set when using an Access or oAuth Key.");
            }

            return config;
        }
    }
}
