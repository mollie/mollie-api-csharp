# Mollie

Developer-friendly & type-safe Csharp SDK specifically catered to leverage *Mollie* API.

<div align="left">
    <a href="https://www.speakeasy.com/?utm_source=mollie&utm_campaign=csharp"><img src="https://custom-icon-badges.demolab.com/badge/-Built%20By%20Speakeasy-212015?style=for-the-badge&logoColor=FBE331&logo=speakeasy&labelColor=545454" /></a>
    <a href="https://opensource.org/licenses/MIT">
        <img src="https://img.shields.io/badge/License-MIT-blue.svg" style="width: 100px; height: 28px;" />
    </a>
</div>

<!-- Start Summary [summary] -->
## Summary


<!-- End Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
* [Mollie](#mollie)
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Authentication](#authentication)
  * [Idempotency Key](#idempotency-key)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Retries](#retries)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
  * [Custom HTTP Client](#custom-http-client)
* [Development](#development)
  * [Maturity](#maturity)
  * [Contributions](#contributions)

<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

### NuGet

To add the [NuGet](https://www.nuget.org/) package to a .NET project:
```bash
dotnet add package Mollie
```

### Locally

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference src/Mollie/Mollie.csproj
```
<!-- End SDK Installation [installation] -->

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    Testmode = false,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(req);

// handle response
```
<!-- End SDK Example Usage [usage] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security schemes globally:

| Name     | Type   | Scheme       |
| -------- | ------ | ------------ |
| `ApiKey` | http   | HTTP Bearer  |
| `OAuth`  | oauth2 | OAuth2 token |

You can set the security parameters through the `security` optional parameter when initializing the SDK client instance. The selected scheme will be used by default to authenticate with the API for all operations that support it. For example:
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    Testmode = false,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(req);

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Idempotency Key -->
## Idempotency Key

This SDK supports the usage of Idempotency Keys. See our [documentation](https://docs.mollie.com/reference/api-idempotency) on how to use it.

```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Mollie.Client(security: new Security() {
    ApiKey = Environment.GetEnvironmentVariable("MOLLIE_API_KEY") ?? "test_...",
});

var paymentRequest = new PaymentRequest() {
    Description = "Description",
    Amount = new Amount() {
        Currency = "EUR",
        Value = "5.00",
    },
    RedirectUrl = "https://example.org/redirect"
};

var idempotencyKey = "<some-idempotency-key>";

var payment1 = await sdk.Payments.CreateAsync(
    idempotencyKey: idempotencyKey,
    paymentRequest: paymentRequest
);

var payment2 = await sdk.Payments.CreateAsync(
    idempotencyKey: idempotencyKey,
    paymentRequest: paymentRequest
);

Console.WriteLine("Payment created with ID: " + payment1.PaymentResponse?.Id);
Console.WriteLine("Payment created with ID: " + payment2.PaymentResponse?.Id);
if (payment1.PaymentResponse?.Id == payment2.PaymentResponse?.Id) {
    Console.WriteLine("Payments are the same");
} else {
    Console.WriteLine("Payments are different");
}
```
<!-- End Idempotency Key -->

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [Balances](docs/sdks/balances/README.md)

* [List](docs/sdks/balances/README.md#list) - List balances
* [Get](docs/sdks/balances/README.md#get) - Get balance
* [GetPrimary](docs/sdks/balances/README.md#getprimary) - Get primary balance
* [GetReport](docs/sdks/balances/README.md#getreport) - Get balance report
* [ListTransactions](docs/sdks/balances/README.md#listtransactions) - List balance transactions

### [BalanceTransfers](docs/sdks/balancetransfers/README.md)

* [Create](docs/sdks/balancetransfers/README.md#create) - Create a Connect balance transfer
* [List](docs/sdks/balancetransfers/README.md#list) - List all Connect balance transfers
* [Get](docs/sdks/balancetransfers/README.md#get) - Get a Connect balance transfer

### [Capabilities](docs/sdks/capabilities/README.md)

* [List](docs/sdks/capabilities/README.md#list) - List capabilities

### [Captures](docs/sdks/captures/README.md)

* [Create](docs/sdks/captures/README.md#create) - Create capture
* [List](docs/sdks/captures/README.md#list) - List captures
* [Get](docs/sdks/captures/README.md#get) - Get capture

### [Chargebacks](docs/sdks/chargebacks/README.md)

* [List](docs/sdks/chargebacks/README.md#list) - List payment chargebacks
* [Get](docs/sdks/chargebacks/README.md#get) - Get payment chargeback
* [All](docs/sdks/chargebacks/README.md#all) - List all chargebacks

### [ClientLinks](docs/sdks/clientlinks/README.md)

* [Create](docs/sdks/clientlinks/README.md#create) - Create client link

### [Clients](docs/sdks/clients/README.md)

* [List](docs/sdks/clients/README.md#list) - List clients
* [Get](docs/sdks/clients/README.md#get) - Get client

### [Customers](docs/sdks/customers/README.md)

* [Create](docs/sdks/customers/README.md#create) - Create customer
* [List](docs/sdks/customers/README.md#list) - List customers
* [Get](docs/sdks/customers/README.md#get) - Get customer
* [Update](docs/sdks/customers/README.md#update) - Update customer
* [Delete](docs/sdks/customers/README.md#delete) - Delete customer
* [CreatePayment](docs/sdks/customers/README.md#createpayment) - Create customer payment
* [ListPayments](docs/sdks/customers/README.md#listpayments) - List customer payments

### [DelayedRouting](docs/sdks/delayedrouting/README.md)

* [Create](docs/sdks/delayedrouting/README.md#create) - Create a delayed route
* [List](docs/sdks/delayedrouting/README.md#list) - List payment routes

### [Invoices](docs/sdks/invoices/README.md)

* [List](docs/sdks/invoices/README.md#list) - List invoices
* [Get](docs/sdks/invoices/README.md#get) - Get invoice

### [Mandates](docs/sdks/mandates/README.md)

* [Create](docs/sdks/mandates/README.md#create) - Create mandate
* [List](docs/sdks/mandates/README.md#list) - List mandates
* [Get](docs/sdks/mandates/README.md#get) - Get mandate
* [Revoke](docs/sdks/mandates/README.md#revoke) - Revoke mandate

### [Methods](docs/sdks/methods/README.md)

* [List](docs/sdks/methods/README.md#list) - List payment methods
* [All](docs/sdks/methods/README.md#all) - List all payment methods
* [Get](docs/sdks/methods/README.md#get) - Get payment method

### [Onboarding](docs/sdks/onboarding/README.md)

* [Get](docs/sdks/onboarding/README.md#get) - Get onboarding status
* [Submit](docs/sdks/onboarding/README.md#submit) - Submit onboarding data

### [Organizations](docs/sdks/organizations/README.md)

* [Get](docs/sdks/organizations/README.md#get) - Get organization
* [GetCurrent](docs/sdks/organizations/README.md#getcurrent) - Get current organization
* [GetPartner](docs/sdks/organizations/README.md#getpartner) - Get partner status

### [PaymentLinks](docs/sdks/paymentlinks/README.md)

* [Create](docs/sdks/paymentlinks/README.md#create) - Create payment link
* [List](docs/sdks/paymentlinks/README.md#list) - List payment links
* [Get](docs/sdks/paymentlinks/README.md#get) - Get payment link
* [Update](docs/sdks/paymentlinks/README.md#update) - Update payment link
* [Delete](docs/sdks/paymentlinks/README.md#delete) - Delete payment link
* [ListPayments](docs/sdks/paymentlinks/README.md#listpayments) - Get payment link payments

### [Payments](docs/sdks/payments/README.md)

* [Create](docs/sdks/payments/README.md#create) - Create payment
* [List](docs/sdks/payments/README.md#list) - List payments
* [Get](docs/sdks/payments/README.md#get) - Get payment
* [Update](docs/sdks/payments/README.md#update) - Update payment
* [Cancel](docs/sdks/payments/README.md#cancel) - Cancel payment
* [ReleaseAuthorization](docs/sdks/payments/README.md#releaseauthorization) - Release payment authorization

### [Permissions](docs/sdks/permissions/README.md)

* [List](docs/sdks/permissions/README.md#list) - List permissions
* [Get](docs/sdks/permissions/README.md#get) - Get permission

### [Profiles](docs/sdks/profiles/README.md)

* [Create](docs/sdks/profiles/README.md#create) - Create profile
* [List](docs/sdks/profiles/README.md#list) - List profiles
* [Get](docs/sdks/profiles/README.md#get) - Get profile
* [Update](docs/sdks/profiles/README.md#update) - Update profile
* [Delete](docs/sdks/profiles/README.md#delete) - Delete profile
* [GetCurrent](docs/sdks/profiles/README.md#getcurrent) - Get current profile

### [Refunds](docs/sdks/refunds/README.md)

* [Create](docs/sdks/refunds/README.md#create) - Create payment refund
* [List](docs/sdks/refunds/README.md#list) - List payment refunds
* [Get](docs/sdks/refunds/README.md#get) - Get payment refund
* [Cancel](docs/sdks/refunds/README.md#cancel) - Cancel payment refund
* [All](docs/sdks/refunds/README.md#all) - List all refunds

### [SalesInvoices](docs/sdks/salesinvoices/README.md)

* [Create](docs/sdks/salesinvoices/README.md#create) - Create sales invoice
* [List](docs/sdks/salesinvoices/README.md#list) - List sales invoices
* [Get](docs/sdks/salesinvoices/README.md#get) - Get sales invoice
* [Update](docs/sdks/salesinvoices/README.md#update) - Update sales invoice
* [Delete](docs/sdks/salesinvoices/README.md#delete) - Delete sales invoice

### [Settlements](docs/sdks/settlements/README.md)

* [List](docs/sdks/settlements/README.md#list) - List settlements
* [Get](docs/sdks/settlements/README.md#get) - Get settlement
* [GetOpen](docs/sdks/settlements/README.md#getopen) - Get open settlement
* [GetNext](docs/sdks/settlements/README.md#getnext) - Get next settlement
* [ListPayments](docs/sdks/settlements/README.md#listpayments) - List settlement payments
* [ListCaptures](docs/sdks/settlements/README.md#listcaptures) - List settlement captures
* [ListRefunds](docs/sdks/settlements/README.md#listrefunds) - List settlement refunds
* [ListChargebacks](docs/sdks/settlements/README.md#listchargebacks) - List settlement chargebacks

### [Subscriptions](docs/sdks/subscriptions/README.md)

* [Create](docs/sdks/subscriptions/README.md#create) - Create subscription
* [List](docs/sdks/subscriptions/README.md#list) - List customer subscriptions
* [Get](docs/sdks/subscriptions/README.md#get) - Get subscription
* [Update](docs/sdks/subscriptions/README.md#update) - Update subscription
* [Cancel](docs/sdks/subscriptions/README.md#cancel) - Cancel subscription
* [All](docs/sdks/subscriptions/README.md#all) - List all subscriptions
* [ListPayments](docs/sdks/subscriptions/README.md#listpayments) - List subscription payments

### [Terminals](docs/sdks/terminals/README.md)

* [List](docs/sdks/terminals/README.md#list) - List terminals
* [Get](docs/sdks/terminals/README.md#get) - Get terminal

### [Wallets](docs/sdks/wallets/README.md)

* [RequestApplePaySession](docs/sdks/wallets/README.md#requestapplepaysession) - Request Apple Pay payment session

### [WebhookEvents](docs/sdks/webhookevents/README.md)

* [Get](docs/sdks/webhookevents/README.md#get) - Get a Webhook Event

### [Webhooks](docs/sdks/webhooks/README.md)

* [Create](docs/sdks/webhooks/README.md#create) - Create a webhook
* [List](docs/sdks/webhooks/README.md#list) - List all webhooks
* [Update](docs/sdks/webhooks/README.md#update) - Update a webhook
* [Get](docs/sdks/webhooks/README.md#get) - Get a webhook
* [Delete](docs/sdks/webhooks/README.md#delete) - Delete a webhook
* [Test](docs/sdks/webhooks/README.md#test) - Test a webhook

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Retries [retries] -->
## Retries

Some of the endpoints in this SDK support retries. If you use the SDK without any configuration, it will fall back to the default retry strategy provided by the API. However, the default retry strategy can be overridden on a per-operation basis, or across the entire SDK.

To change the default retry strategy for a single API call, simply pass a `RetryConfig` to the call:
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    Testmode = false,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    request: req
);

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    Testmode = false,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(req);

// handle response
```
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`BaseException`](./src/Mollie/Models/Errors/BaseException.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `Request`     | *HttpRequestMessage*  | HTTP request object   |
| `Response`    | *HttpResponseMessage* | HTTP response object  |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Errors;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

try
{
    ListBalancesRequest req = new ListBalancesRequest() {
        Currency = "EUR",
        From = "bal_gVMhHKqSSRYJyPsuoPNFH",
        Limit = 50,
        Testmode = false,
        IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    };

    var res = await sdk.Balances.ListAsync(req);

    // handle response
}
catch (BaseException ex)  // all SDK exceptions inherit from BaseException
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpRequestMessage request = ex.Request;
    HttpResponseMessage response = ex.Response;
    var statusCode = (int)response.StatusCode;
    var responseBody = ex.Body;

    if (ex is ErrorResponse) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        ErrorResponsePayload payload = ex.Payload;
        long Status = payload.Status;
        string Title = payload.Title;
        // ...
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (OperationCanceledException ex)
{
    // CancellationToken was cancelled
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exceptions:**
* [`BaseException`](./src/Mollie/Models/Errors/BaseException.cs): The base class for HTTP error responses.
  * [`ErrorResponse`](./src/Mollie/Models/Errors/ErrorResponse.cs): An error response object. *

<details><summary>Less common exceptions (2)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`BaseException`](./src/Mollie/Models/Errors/BaseException.cs):
  * [`ResponseValidationError`](./src/Mollie/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>

\* Refer to the [relevant documentation](#available-resources-and-operations) to determine whether an exception applies to a specific operation.
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Override Server URL Per-Client

The default server can be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    serverUrl: "https://api.mollie.com/v2",
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    Testmode = false,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(req);

// handle response
```
<!-- End Server Selection [server] -->

<!-- Start Custom HTTP Client [http-client] -->
## Custom HTTP Client

The C# SDK makes API calls using an `ISpeakeasyHttpClient` that wraps the native
[HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient). This
client provides the ability to attach hooks around the request lifecycle that can be used to modify the request or handle
errors and response.

The `ISpeakeasyHttpClient` interface allows you to either use the default `SpeakeasyHttpClient` that comes with the SDK,
or provide your own custom implementation with customized configuration such as custom message handlers, timeouts,
connection pooling, and other HTTP client settings.

The following example shows how to create a custom HTTP client with request modification and error handling:

```csharp
using Mollie;
using Mollie.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Create a custom HTTP client
public class CustomHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _defaultClient;

    public CustomHttpClient()
    {
        _defaultClient = new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Add custom header and timeout
        request.Headers.Add("x-custom-header", "custom value");
        request.Headers.Add("x-request-timeout", "30");
        
        try
        {
            var response = await _defaultClient.SendAsync(request, cancellationToken);
            // Log successful response
            Console.WriteLine($"Request successful: {response.StatusCode}");
            return response;
        }
        catch (Exception error)
        {
            // Log error
            Console.WriteLine($"Request failed: {error.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _defaultClient?.Dispose();
    }
}

// Use the custom HTTP client with the SDK
var customHttpClient = new CustomHttpClient();
var sdk = new Client(client: customHttpClient);
```

<details>
<summary>You can also provide a completely custom HTTP client with your own configuration:</summary>

```csharp
using Mollie.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Custom HTTP client with custom configuration
public class AdvancedHttpClient : ISpeakeasyHttpClient
{
    private readonly HttpClient _httpClient;

    public AdvancedHttpClient()
    {
        var handler = new HttpClientHandler()
        {
            MaxConnectionsPerServer = 10,
            // ServerCertificateCustomValidationCallback = customCertValidation, // Custom SSL validation if needed
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        return await _httpClient.SendAsync(request, cancellationToken ?? CancellationToken.None);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}

var sdk = Client.Builder()
    .WithClient(new AdvancedHttpClient())
    .Build();
```
</details>

<details>
<summary>For simple debugging, you can enable request/response logging by implementing a custom client:</summary>

```csharp
public class LoggingHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _innerClient;

    public LoggingHttpClient(ISpeakeasyHttpClient innerClient = null)
    {
        _innerClient = innerClient ?? new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Log request
        Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
        
        var response = await _innerClient.SendAsync(request, cancellationToken);
        
        // Log response
        Console.WriteLine($"Received {response.StatusCode} response");
        
        return response;
    }

    public void Dispose() => _innerClient?.Dispose();
}

var sdk = new Client(client: new LoggingHttpClient());
```
</details>

The SDK also provides built-in hook support through the `SDKConfiguration.Hooks` system, which automatically handles
`BeforeRequestAsync`, `AfterSuccessAsync`, and `AfterErrorAsync` hooks for advanced request lifecycle management.
<!-- End Custom HTTP Client [http-client] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development

## Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation. 
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release. 

### SDK Created by [Speakeasy](https://www.speakeasy.com/?utm_source=mollie&utm_campaign=csharp)
