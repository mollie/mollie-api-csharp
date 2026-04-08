#nullable enable
namespace Mollie.Utils.Webhooks
{
    using System;

    /// <summary>
    /// Exception thrown when webhook signature validation fails.
    /// </summary>
    public class InvalidSignatureException : Exception
    {
        public InvalidSignatureException(string message) : base(message) { }

        public InvalidSignatureException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
