# Migrating from `Mollie.Api` to `Mollie`

This guide covers migrating from the legacy community .NET client (`Mollie.Api`, "Mollie Api Client for .NET", v4.x) to the official Speakeasy-generated .NET SDK (`Mollie`).

## Table of contents

- [Why migrate?](#why-migrate)
- [Installation](#installation)
- [Client initialization](#client-initialization)
- [Authentication](#authentication)
- [Resources and methods](#resources-and-methods)
- [Request parameters](#request-parameters)
- [Pagination and listing resources](#pagination-and-listing-resources)
- [Error handling](#error-handling)
- [New features](#new-features)
- [Full resource mapping](#full-resource-mapping)

---

## Why migrate?

Mollie is working towards fully migrating to the new, **automatically generated SDKs**. Unlike our legacy SDKs, which are updated manually, the new SDKs are generated directly from our API specification, making new features and API updates available within 24 hours of changes being released. This ensures that your integration stays up to date with minimal effort and allows you to benefit from the latest version of our product at all times.

Beyond staying up-to-date automatically, `Mollie` also provides:

- Coverage for Accounts, Transfers, Unmatched Credit Transfers and Verify Payee, which aren't available in the legacy SDK.
- A single unified client (`sdk.Payments`, `sdk.Customers`, ...) instead of a separate client class or DI registration per resource.
- Automatic pagination through a `Next()` method on the response, instead of manually following `_links.next` yourself.
- Built-in retry logic with configurable backoff strategies.~~ with no dependency on Polly~~.
- Framework-agnostic webhook signature validation that doesn't require [ASP.NET](http://ASP.NET) Core.
- `profileId` and `testmode` configurable once on the client and overridable per request, for every auth type.

---

## Installation

Remove the old package and add the new one.

```bash
dotnet remove package Mollie.Api
dotnet add package Mollie
```

Or via the Package Manager Console:

```powershell
Uninstall-Package Mollie.Api
Install-Package Mollie
```

If you also used `Mollie.Api.AspNet` for webhook signature validation, that package is no longer needed — the new SDK's webhook validator is framework-agnostic (see Webhook signature validation).

---

## Client initialization

The old SDK instantiated one class per resource (or registered them all via dependency injection). The new SDK exposes a single `Client` with every resource as a property.

**Before:**

```c#
using Mollie.Api.Client;

using IPaymentClient paymentClient = new PaymentClient("test_...", new HttpClient());
using ICustomerClient customerClient = new CustomerClient("test_...", new HttpClient());
```

Or via dependency injection:

```c#
builder.Services.AddMollieApi(options => {
    options.ApiKey = builder.Configuration["Mollie:ApiKey"];
});
```

**After:**

```c#
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "test_...",
});

// every resource is now a property on the same client:
var payment = await sdk.Payments.CreateAsync(/* ... */);
var customer = await sdk.Customers.CreateAsync(/* ... */);
```

---

## Authentication

### API key

```
-using IPaymentClient paymentClient = new PaymentClient("test_...", new HttpClient());
+var sdk = new Client(security: new Security() {
+    ApiKey = "test_...",
+});
```

### Advanced Access Token

The old SDK used the same `ApiKey` option to hold either an API key or an organization/OAuth access token — there was no dedicated property to distinguish them. The new SDK introduces a distinct `AdvancedAccessToken` scheme:

```
-var options = new MollieClientOptions {
-    ApiKey = "access_...", // same field used for API keys and access tokens
-};
+var sdk = new Client(security: new Security() {
+    AdvancedAccessToken = "access_...",
+});
```

### OAuth token

The old SDK exchanged an authorization code for an access token via `ConnectClient.GetAccessTokenAsync(...)`, using `ClientId`/`ClientSecret` set on `MollieClientOptions`, then fed the resulting token back into `ApiKey`. The new SDK exposes `OAuth` as a first-class client security scheme, and the token exchange itself is a regular resource call:

```c#
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OAuth = "Bearer eyJ...",
});
```

```
-var connectClient = new ConnectClient(clientId, clientSecret, new HttpClient());
-TokenResponse tokens = await connectClient.GetAccessTokenAsync(new TokenRequest {
-    GrantType = GrantType.AuthorizationCode,
-    Code = "auth_...",
-    RedirectUri = "https://example.com/redirect",
-});
+var sdk = new Client();
+var res = await sdk.Oauth.GenerateAsync(
+    security: new OauthGenerateTokensSecurity() {
+        Username = clientId,
+        Password = clientSecret,
+    },
+    requestBody: new OauthGenerateTokensRequestBody() {
+        GrantType = OauthGrantType.AuthorizationCode,
+        Code = "auth_...",
+        RedirectUri = "https://example.com/redirect",
+    }
+);
```

### Global defaults (`profileId`, `testmode`)

The old SDK already supported `Testmode` and `ProfileId` on `MollieClientOptions`, plus per-method `testmode`/`profileId` optional parameters on many calls. The new SDK supports the same functionality but moves both onto named constructor parameters of the unified client, and consistently exposes them as overridable fields on every request:

```
-var options = new MollieClientOptions {
-    ApiKey = "access_...",
-    Testmode = true,
-    ProfileId = "pfl_...",
-};
+var sdk = new Client(
+    security: new Security() { AdvancedAccessToken = "access_..." },
+    testmode: true,
+    profileId: "pfl_..."
+);
```

---

## Resources and methods

### A single client replaces per-resource client classes

The old SDK required instantiating (or DI-registering) a separate client class per resource, each implementing its own interface (`IPaymentClient`, `ICustomerClient`, ...). The new SDK exposes every resource as a property on one `Client` instance (`sdk.Payments`, `sdk.Customers`, `sdk.Mandates`, ...), each with `Async`-suffixed methods that take named parameters.

```
-using IPaymentClient paymentClient = new PaymentClient("test_...", new HttpClient());
-var paymentRequest = new PaymentRequest {
-    Amount = new Amount(Currency.EUR, 100.00m),
-    Description = "Order #478",
-    RedirectUrl = "https://example.com/redirect",
-};
-PaymentResponse payment = await paymentClient.CreatePaymentAsync(paymentRequest);
+var sdk = new Client(security: new Security() { ApiKey = "test_..." });
+var res = await sdk.Payments.CreateAsync(
+    paymentRequest: new PaymentRequest() {
+        Amount = new Amount() { Currency = "EUR", Value = "100.00" },
+        Description = "Order #478",
+        RedirectUrl = "https://example.com/redirect",
+    }
+);
+var payment = res.PaymentResponse;
```

Operations that accept several optional query parameters alongside a path parameter (like `Get`) take a single request object instead of a long parameter list:

```
-PaymentResponse payment = await paymentClient.GetPaymentAsync("tr_WDqYK6vllg", includeQrCode: true);
+var res = await sdk.Payments.GetAsync(new GetPaymentRequest() {
+    PaymentId = "tr_WDqYK6vllg",
+    Include = "details.qrCode",
+});
+var payment = res.PaymentResponse;
```

### Update

```
-PaymentResponse updated = await paymentClient.UpdatePaymentAsync("tr_...",
-    new PaymentUpdateRequest { Description = "New description" });
+var res = await sdk.Payments.UpdateAsync(
+    paymentId: "tr_...",
+    requestBody: new UpdatePaymentRequestBody() { Description = "New description" }
+);
```

### Cancel / delete

```
-await paymentClient.CancelPaymentAsync("tr_...");
+var res = await sdk.Payments.CancelAsync(paymentId: "tr_...");
```

### Nested resources

The old SDK had a dedicated client class per nested resource, each taking the parent ID as a method argument (for example `IMandateClient.CreateMandateAsync(customerId, request)`). The new SDK keeps the same "parent ID as a parameter" shape, but every nested resource now lives as a property on the single unified client instead of its own injectable client class:

| Old | New |
| --- | --- |
| `customerClient.CreateCustomerPayment(customerId, paymentRequest)` | `sdk.Customers.CreatePaymentAsync(customerId: customerId, paymentRequest: ...)` |
| `customerClient.GetCustomerPaymentListAsync(customerId)` | `sdk.Customers.ListPaymentsAsync(customerId: customerId)` |
| `mandateClient.CreateMandateAsync(customerId, request)` | `sdk.Mandates.CreateAsync(customerId: customerId, mandateRequest: ...)` |
| `mandateClient.GetMandateListAsync(customerId)` | `sdk.Mandates.ListAsync(new ListMandatesRequest { CustomerId = customerId })` |
| `mandateClient.RevokeMandate(customerId, mandateId)` | `sdk.Mandates.RevokeAsync(customerId: customerId, mandateId: mandateId)` |
| `subscriptionClient.CreateSubscriptionAsync(customerId, request)` | `sdk.Subscriptions.CreateAsync(customerId: customerId, subscriptionRequest: ...)` |
| `subscriptionClient.GetAllSubscriptionList()` | `sdk.Subscriptions.AllAsync()` |
| `subscriptionClient.GetSubscriptionPaymentListAsync(customerId, subscriptionId)` | `sdk.Subscriptions.ListPaymentsAsync(customerId: customerId, subscriptionId: subscriptionId)` |
| `refundClient.CreatePaymentRefundAsync(paymentId, request)` | `sdk.Refunds.CreateAsync(paymentId: paymentId, refundRequest: ...)` |
| `chargebackClient.GetChargebackListAsync(paymentId)` | `sdk.Chargebacks.ListAsync(new ListChargebacksRequest { PaymentId = paymentId })` |
| `captureClient.CreateCapture(paymentId, request)` | `sdk.Captures.CreateAsync(paymentId: paymentId, captureRequest: ...)` |
| `walletClient.RequestApplePaySessionAsync(request)` | `sdk.Wallets.RequestApplePaySessionAsync(applePaySessionRequest: ...)` |

---

## Request parameters

### Idempotency key

The old SDK already generated an idempotency key for every request automatically, overridable per call via a scoped `using (client.WithIdempotencyKey(value)) { ... }` block. The new SDK accepts `idempotencyKey` directly as a named parameter on every mutating call, without the scope wrapper:

```
-using (paymentClient.WithIdempotencyKey("<some-idempotency-key>")) {
-    var payment1 = await paymentClient.CreatePaymentAsync(paymentRequest);
-    var payment2 = await paymentClient.CreatePaymentAsync(paymentRequest);
-}
+var payment1 = await sdk.Payments.CreateAsync(
+    idempotencyKey: "<some-idempotency-key>",
+    paymentRequest: paymentRequest
+);
+var payment2 = await sdk.Payments.CreateAsync(
+    idempotencyKey: "<some-idempotency-key>",
+    paymentRequest: paymentRequest
+);
```

### `testmode` and `profileId` per request

These can be overridden per request even when defaults are set on the client, exactly as in the old SDK:

```c#
var res = await sdk.Payments.CreateAsync(
    paymentRequest: new PaymentRequest() {
        Testmode = false,
        ProfileId = "pfl_other",
        Description = "My first payment",
        RedirectUrl = "https://example.org/redirect",
        Amount = new Amount() { Currency = "EUR", Value = "10.00" },
    }
);
```

---

## Pagination and listing resources

### Old SDK — manually following `_links.next`

The old SDK returned a `ListResponse<T>` (`Count`, `Items`, `Links`) from list methods. To fetch subsequent pages, you had to pass the `UrlObjectLink` from `Links.Next` back into an overload of the same method:

```c#
ListResponse<PaymentResponse> page = await paymentClient.GetPaymentListAsync(limit: 50);

while (page.Links.Next != null) {
    page = await paymentClient.GetPaymentListAsync(page.Links.Next);
    // handle page
}
```

### New SDK — `Next()` auto-paginates

The response object itself exposes an async `Next()` method that fetches the next page, returning `null` once there are no more results:

```c#
ListPaymentsRequest req = new ListPaymentsRequest() {
    Limit = 50,
};

ListPaymentsResponse? res = await sdk.Payments.ListAsync(req);

while (res != null) {
    // handle items

    res = await res.Next!();
}
```

---

## Error handling

### Old SDK — `MollieApiException`

```c#
try {
    PaymentResponse payment = await paymentClient.GetPaymentAsync("invalid");
} catch (MollieApiException ex) {
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.Details); // MollieErrorMessage with status/title/detail
}
```

### New SDK — `BaseException` / `ErrorResponse`

```c#
using Mollie.Models.Errors;

try {
    var res = await sdk.Payments.GetAsync(new GetPaymentRequest() { PaymentId = "invalid" });
} catch (BaseException ex) { // all SDK exceptions inherit from BaseException
    var request = ex.Request;
    var response = ex.Response;
    var statusCode = (int)response.StatusCode;

    if (ex is ErrorResponse errorResponse) {
        var payload = errorResponse.Payload;
        var status = payload.Status;
        var title = payload.Title;
        var detail = payload.Detail;
    }
} catch (System.Net.Http.HttpRequestException ex) {
    // network connectivity error — check ex.InnerException
}
```

---

## New features

### Webhook signature validation

The old SDK's webhook validation lived in the separate `Mollie.Api.AspNet` package and was coupled to `Microsoft.AspNetCore.Http.HttpRequest` (`MollieSignatureValidator.Validate(HttpRequest request)`, or the `[ServiceFilter(typeof(MollieSignatureFilter))]` attribute). The new SDK ships a plain, framework-agnostic validator in the core package that works with just the raw body string and header value — no [ASP.NET](http://ASP.NET) Core dependency required:

```c#
using Mollie.Utils.Webhooks;

var validator = new SignatureValidator(
    Environment.GetEnvironmentVariable("MOLLIE_WEBHOOK_SECRET") ?? string.Empty
);

try {
    var isVerified = validator.ValidatePayload(rawBody, signatureHeader);

    if (!isVerified) {
        // no signature header was provided; treat as a legacy webhook
    }
} catch (InvalidSignatureException) {
    // reject the request
}
```

### Retries

The old SDK relied on an external Polly policy set via DI options (`options.RetryPolicy = MollieHttpRetryPolicies.TransientHttpErrorRetryPolicy()`). The new SDK has built-in retry configuration, settable on the client or per call:

```c#
using Mollie;
using Mollie.Utils;

var sdk = new Client(retryConfig: new RetryConfig(
    strategy: RetryConfig.RetryStrategy.BACKOFF,
    backoff: new BackoffStrategy(
        initialIntervalMs: 500,
        maxIntervalMs: 60_000,
        maxElapsedTimeMs: 300_000,
        exponent: 1.5
    ),
    retryConnectionErrors: true
));
```

### Custom HTTP client

```c#
using Mollie;
using Mollie.Utils;

public class LoggingHttpClient : ISpeakeasyHttpClient {
    private readonly ISpeakeasyHttpClient _innerClient = new SpeakeasyHttpClient();

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null) {
        Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
        return await _innerClient.SendAsync(request, cancellationToken);
    }

    public void Dispose() => _innerClient?.Dispose();
}

var sdk = new Client(client: new LoggingHttpClient());
```

---

## Full resource mapping

### Resources available in both SDKs

| Old (client class) | New (`sdk.`) |
| --- | --- |
| `PaymentClient` | `Payments` |
| `RefundClient` | `Refunds` (pass `paymentId`) |
| `ChargebackClient` | `Chargebacks` (pass `paymentId`) |
| `CaptureClient` | `Captures` (pass `paymentId`) |
| `PaymentMethodClient` | `Methods` |
| `CustomerClient` | `Customers` |
| `MandateClient` | `Mandates` (pass `customerId`) |
| `SubscriptionClient` | `Subscriptions` (pass `customerId`) |
| `SettlementClient` | `Settlements` |
| `ProfileClient` | `Profiles` |
| `OrganizationClient` | `Organizations` |
| `PermissionClient` | `Permissions` |
| `OnboardingClient` | `Onboarding` |
| `TerminalClient` | `Terminals` |
| `PaymentLinkClient` | `PaymentLinks` |
| `ClientClient` | `Clients` |
| `ClientLinkClient` | `ClientLinks` |
| `InvoiceClient` | `Invoices` |
| `ConnectClient` | `Oauth` |
| `WalletClient` | `Wallets` |
| `BalanceClient` | `Balances` |
| `BalanceTransferClient` | `BalanceTransfers` |
| `CapabilityClient` | `Capabilities` |
| `DelayedRoutingClient` | `DelayedRouting` |
| `SalesInvoiceClient` | `SalesInvoices` |
| `SessionClient` | `Sessions` |
| `PayoutClient` | `Payouts` |
| `WebhookClient` | `Webhooks` |
| `WebhookEventClient` | `WebhookEvents` |
| `OrderClient` (deprecated) | Not available — replaced by [Payment Links](https://docs.mollie.com/reference/v2/payment-links-api/create-payment-link) and standard Payments |
| `ShipmentClient` (deprecated) | Not available |

### Resources available only in the new SDK

| New (`sdk.`) | Description |
| --- | --- |
| `Accounts` | Business account management |
| `Transfers` | Transfer management |
| `UnmatchedCreditTransfers` | Unmatched credit transfer handling |
| `VerifyPayee` | Payee verification |

For a complete list of all resources and operations with usage examples, see the [Available Resources and Operations](https://github.com/mollie/mollie-api-csharp#available-resources-and-operations) section in the SDK's README.
