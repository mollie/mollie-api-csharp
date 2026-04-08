#nullable enable
namespace Mollie.Utils.Webhooks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Validates Mollie webhook signatures to ensure requests originate from Mollie.
    /// Supports multiple signing secrets to allow for secret rotation.
    /// </summary>
    public class SignatureValidator
    {
        /// <summary>
        /// The HTTP header name that contains the webhook signature.
        /// </summary>
        public const string SignatureHeader = "X-Mollie-Signature";

        private const string SignaturePrefix = "sha256=";

        private readonly List<string> _signingSecrets;

        /// <summary>
        /// Creates a new SignatureValidator with a single signing secret.
        /// </summary>
        public SignatureValidator(string signingSecret)
        {
            _signingSecrets = new List<string> { signingSecret };
        }

        /// <summary>
        /// Creates a new SignatureValidator with multiple signing secrets (useful during rotation).
        /// </summary>
        public SignatureValidator(IEnumerable<string> signingSecrets)
        {
            _signingSecrets = signingSecrets.ToList();
        }

        /// <summary>
        /// Validates a webhook request using one or more signing secrets.
        /// Returns false for legacy webhooks that have no signature header.
        /// </summary>
        /// <param name="request">The incoming HTTP request.</param>
        /// <param name="signingSecrets">One or more signing secrets.</param>
        /// <returns>True if the signature is valid, false if no signature is present (legacy webhook).</returns>
        /// <exception cref="InvalidSignatureException">Thrown when a signature is present but invalid.</exception>
        public static bool Validate(HttpRequestMessage request, string signingSecrets) =>
            Validate(request, new[] { signingSecrets });

        /// <inheritdoc cref="Validate(HttpRequestMessage, string)"/>
        public static bool Validate(HttpRequestMessage request, IEnumerable<string> signingSecrets)
        {
            return new SignatureValidator(signingSecrets).ValidateRequest(request);
        }

        /// <summary>
        /// Validates a raw payload against one or more provided signatures and signing secrets.
        /// Returns false for legacy webhooks that have no signatures.
        /// </summary>
        /// <param name="payload">The raw request body.</param>
        /// <param name="signingSecrets">One or more signing secrets.</param>
        /// <param name="signature">A single signature from the request header, or null for legacy webhooks.</param>
        /// <returns>True if any signature is valid, false if no signatures are provided (legacy webhook).</returns>
        /// <exception cref="InvalidSignatureException">Thrown when signatures are present but all are invalid.</exception>
        public static bool Validate(string payload, string signingSecrets, string? signature) =>
            Validate(payload, new[] { signingSecrets }, signature != null ? new[] { signature } : null);

        /// <summary>
        /// Validates a raw payload against one or more provided signatures and signing secrets.
        /// Returns false for legacy webhooks that have no signatures.
        /// </summary>
        /// <param name="payload">The raw request body.</param>
        /// <param name="signingSecrets">One or more signing secrets.</param>
        /// <param name="signatures">One or more signatures from the request header.</param>
        /// <returns>True if any signature is valid, false if no signatures are provided (legacy webhook).</returns>
        /// <exception cref="InvalidSignatureException">Thrown when signatures are present but all are invalid.</exception>
        public static bool Validate(string payload, IEnumerable<string> signingSecrets, IEnumerable<string>? signatures)
        {
            return new SignatureValidator(signingSecrets).ValidatePayload(payload, signatures);
        }

        /// <summary>
        /// Validates the signature on an HTTP request.
        /// Returns false for legacy webhooks that have no signature header.
        /// </summary>
        /// <exception cref="InvalidSignatureException">Thrown when a signature is present but invalid.</exception>
        public bool ValidateRequest(HttpRequestMessage request)
        {
            var body = request.Content?.ReadAsStringAsync().GetAwaiter().GetResult() ?? string.Empty;

            if (!request.Headers.TryGetValues(SignatureHeader, out var signatures))
            {
                // No signature header — treat as legacy webhook
                return false;
            }

            var signatureList = signatures.ToList();
            if (!signatureList.Any())
            {
                return false;
            }

            return ValidateSignatures(body, signatureList);
        }

        /// <summary>
        /// Validates a raw payload against one or more provided signatures.
        /// Returns false for legacy webhooks that have no signatures.
        /// </summary>
        /// <exception cref="InvalidSignatureException">Thrown when signatures are present but all are invalid.</exception>
        public bool ValidatePayload(string payload, string signature) =>
            ValidatePayload(payload, new[] { signature });

        /// <inheritdoc cref="ValidatePayload(string, string)"/>
        public bool ValidatePayload(string payload, IEnumerable<string>? signatures)
        {
            var signatureList = signatures?
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList() ?? new List<string>();

            if (!signatureList.Any())
            {
                // No signatures — treat as legacy webhook
                return false;
            }

            return ValidateSignatures(payload, signatureList);
        }

        private bool ValidateSignatures(string payload, IEnumerable<string> signatures)
        {
            var validSignatureFound = signatures.Any(sig =>
                IsValidSignature(ExtractSignature(sig), payload));

            if (!validSignatureFound)
            {
                throw new InvalidSignatureException("Invalid webhook signature");
            }

            return true;
        }

        private string ExtractSignature(string signatureHeader)
        {
            return signatureHeader.StartsWith(SignaturePrefix, StringComparison.Ordinal)
                ? signatureHeader[SignaturePrefix.Length..]
                : signatureHeader;
        }

        private bool IsValidSignature(string providedSignature, string payload)
        {
            return _signingSecrets.Any(secret =>
            {
                var expectedSignature = CreateSignature(payload, secret);
                return CryptographicOperations.FixedTimeEquals(
                    Encoding.UTF8.GetBytes(expectedSignature),
                    Encoding.UTF8.GetBytes(providedSignature));
            });
        }

        /// <summary>
        /// Creates an HMAC-SHA256 signature for a payload using the given secret.
        /// </summary>
        public static string CreateSignature(string payload, string secret)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secret);
            var payloadBytes = Encoding.UTF8.GetBytes(payload);

            using var hmac = new HMACSHA256(keyBytes);
            var hashBytes = hmac.ComputeHash(payloadBytes);

            return Convert.ToHexString(hashBytes).ToLowerInvariant();
        }
    }
}
