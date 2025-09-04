# Mollie

Developer-friendly & type-safe Csharp SDK specifically catered to leverage *Mollie* API.

<div align="left">
    <a href="https://www.speakeasy.com/?utm_source=mollie&utm_campaign=csharp"><img src="https://custom-icon-badges.demolab.com/badge/-Built%20By%20Speakeasy-212015?style=for-the-badge&logoColor=FBE331&logo=speakeasy&labelColor=545454" /></a>
    <a href="https://opensource.org/licenses/MIT">
        <img src="https://img.shields.io/badge/License-MIT-blue.svg" style="width: 100px; height: 28px;" />
    </a>
</div>


<br /><br />
> [!IMPORTANT]
> This SDK is not yet ready for production use. To complete setup please follow the steps outlined in your [workspace](https://app.speakeasy.com/org/mollie-oom/mollie). Delete this section before > publishing to a package manager.

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
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Retries](#retries)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
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

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Balances.ListAsync(
    currency: "EUR",
    fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
    limit: 50,
    testmode: false
);

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

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Balances.ListAsync(
    currency: "EUR",
    fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
    limit: 50,
    testmode: false
);

// handle response
```
<!-- End Authentication [security] -->

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

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

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
    currency: "EUR",
    fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
    limit: 50,
    testmode: false
);

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Mollie;
using Mollie.Models.Components;

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

var res = await sdk.Balances.ListAsync(
    currency: "EUR",
    fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
    limit: 50,
    testmode: false
);

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

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

try
{
    var res = await sdk.Balances.ListAsync(
        currency: "EUR",
        fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
        limit: 50,
        testmode: false
    );

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

    if (ex is ListBalancesBadRequestHalJSONException) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        ListBalancesBadRequestHalJSONExceptionPayload payload = ex.Payload;
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
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exception:**
* [`BaseException`](./src/Mollie/Models/Errors/BaseException.cs): The base class for HTTP error responses.

<details><summary>Less common exceptions (128)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`BaseException`](./src/Mollie/Models/Errors/BaseException.cs):
  * [`ListBalancesBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListBalancesBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListBalanceTransactionsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListBalanceTransactionsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSettlementsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListSettlementsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSettlementPaymentsHalJSONException`](./src/Mollie/Models/Errors/ListSettlementPaymentsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSettlementCapturesBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListSettlementCapturesBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSettlementRefundsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListSettlementRefundsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSettlementChargebacksBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListSettlementChargebacksBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListInvoicesBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListInvoicesBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListPermissionsHalJSONException`](./src/Mollie/Models/Errors/ListPermissionsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListProfilesHalJSONException`](./src/Mollie/Models/Errors/ListProfilesHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListClientsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListClientsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListWebhooksHalJSONException`](./src/Mollie/Models/Errors/ListWebhooksHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListPaymentsHalJSONException`](./src/Mollie/Models/Errors/ListPaymentsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListMethodsHalJSONException`](./src/Mollie/Models/Errors/ListMethodsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListAllMethodsHalJSONException`](./src/Mollie/Models/Errors/ListAllMethodsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`GetMethodBadRequestHalJSONException`](./src/Mollie/Models/Errors/GetMethodBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListRefundsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListRefundsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListAllRefundsHalJSONException`](./src/Mollie/Models/Errors/ListAllRefundsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListChargebacksBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListChargebacksBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListAllChargebacksBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListAllChargebacksBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListCapturesBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListCapturesBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListPaymentLinksHalJSONException`](./src/Mollie/Models/Errors/ListPaymentLinksHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`GetPaymentLinkPaymentsHalJSONException`](./src/Mollie/Models/Errors/GetPaymentLinkPaymentsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListTerminalsHalJSONException`](./src/Mollie/Models/Errors/ListTerminalsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListCustomersBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListCustomersBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListCustomerPaymentsHalJSONException`](./src/Mollie/Models/Errors/ListCustomerPaymentsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListMandatesBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListMandatesBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSubscriptionsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListSubscriptionsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListAllSubscriptionsBadRequestHalJSONException`](./src/Mollie/Models/Errors/ListAllSubscriptionsBadRequestHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSubscriptionPaymentsHalJSONException`](./src/Mollie/Models/Errors/ListSubscriptionPaymentsHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListSalesInvoicesHalJSONException`](./src/Mollie/Models/Errors/ListSalesInvoicesHalJSONException.cs): An error response object. Status code `400`. Applicable to 1 of 93 methods.*
  * [`ListBalancesNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListBalancesNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetBalanceHalJSONException`](./src/Mollie/Models/Errors/GetBalanceHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetBalanceReportNotFoundHalJSONException`](./src/Mollie/Models/Errors/GetBalanceReportNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListBalanceTransactionsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListBalanceTransactionsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListSettlementsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListSettlementsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetSettlementHalJSONException`](./src/Mollie/Models/Errors/GetSettlementHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListSettlementCapturesNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListSettlementCapturesNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListSettlementRefundsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListSettlementRefundsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListSettlementChargebacksNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListSettlementChargebacksNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListInvoicesNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListInvoicesNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetInvoiceHalJSONException`](./src/Mollie/Models/Errors/GetInvoiceHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetPermissionHalJSONException`](./src/Mollie/Models/Errors/GetPermissionHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetOrganizationHalJSONException`](./src/Mollie/Models/Errors/GetOrganizationHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetProfileNotFoundHalJSONException`](./src/Mollie/Models/Errors/GetProfileNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdateProfileNotFoundHalJSONException`](./src/Mollie/Models/Errors/UpdateProfileNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`DeleteProfileNotFoundHalJSONException`](./src/Mollie/Models/Errors/DeleteProfileNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListClientsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListClientsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetClientHalJSONException`](./src/Mollie/Models/Errors/GetClientHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateClientLinkNotFoundHalJSONException`](./src/Mollie/Models/Errors/CreateClientLinkNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdateWebhookNotFoundHalJSONException`](./src/Mollie/Models/Errors/UpdateWebhookNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetWebhookNotFoundHalJSONException`](./src/Mollie/Models/Errors/GetWebhookNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`DeleteWebhookNotFoundHalJSONException`](./src/Mollie/Models/Errors/DeleteWebhookNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`TestWebhookNotFoundHalJSONException`](./src/Mollie/Models/Errors/TestWebhookNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetWebhookEventHalJSONException`](./src/Mollie/Models/Errors/GetWebhookEventHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetPaymentHalJSONException`](./src/Mollie/Models/Errors/GetPaymentHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdatePaymentNotFoundHalJSONException`](./src/Mollie/Models/Errors/UpdatePaymentNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CancelPaymentNotFoundHalJSONException`](./src/Mollie/Models/Errors/CancelPaymentNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ReleaseAuthorizationNotFoundHalJSONException`](./src/Mollie/Models/Errors/ReleaseAuthorizationNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetMethodNotFoundHalJSONException`](./src/Mollie/Models/Errors/GetMethodNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateRefundNotFoundHalJSONException`](./src/Mollie/Models/Errors/CreateRefundNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListRefundsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListRefundsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetRefundHalJSONException`](./src/Mollie/Models/Errors/GetRefundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CancelRefundHalJSONException`](./src/Mollie/Models/Errors/CancelRefundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListChargebacksNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListChargebacksNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetChargebackHalJSONException`](./src/Mollie/Models/Errors/GetChargebackHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListAllChargebacksNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListAllChargebacksNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateCaptureNotFoundHalJSONException`](./src/Mollie/Models/Errors/CreateCaptureNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListCapturesNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListCapturesNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetCaptureHalJSONException`](./src/Mollie/Models/Errors/GetCaptureHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreatePaymentLinkNotFoundHalJSONException`](./src/Mollie/Models/Errors/CreatePaymentLinkNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetPaymentLinkHalJSONException`](./src/Mollie/Models/Errors/GetPaymentLinkHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdatePaymentLinkNotFoundHalJSONException`](./src/Mollie/Models/Errors/UpdatePaymentLinkNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`DeletePaymentLinkNotFoundHalJSONException`](./src/Mollie/Models/Errors/DeletePaymentLinkNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetTerminalHalJSONException`](./src/Mollie/Models/Errors/GetTerminalHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`PaymentCreateRouteHalJSONException`](./src/Mollie/Models/Errors/PaymentCreateRouteHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`PaymentListRoutesHalJSONException`](./src/Mollie/Models/Errors/PaymentListRoutesHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateCustomerHalJSONException`](./src/Mollie/Models/Errors/CreateCustomerHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListCustomersNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListCustomersNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetCustomerHalJSONException`](./src/Mollie/Models/Errors/GetCustomerHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdateCustomerHalJSONException`](./src/Mollie/Models/Errors/UpdateCustomerHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`DeleteCustomerHalJSONException`](./src/Mollie/Models/Errors/DeleteCustomerHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateMandateHalJSONException`](./src/Mollie/Models/Errors/CreateMandateHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListMandatesNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListMandatesNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetMandateHalJSONException`](./src/Mollie/Models/Errors/GetMandateHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`RevokeMandateHalJSONException`](./src/Mollie/Models/Errors/RevokeMandateHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateSubscriptionHalJSONException`](./src/Mollie/Models/Errors/CreateSubscriptionHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListSubscriptionsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListSubscriptionsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetSubscriptionHalJSONException`](./src/Mollie/Models/Errors/GetSubscriptionHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdateSubscriptionHalJSONException`](./src/Mollie/Models/Errors/UpdateSubscriptionHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CancelSubscriptionHalJSONException`](./src/Mollie/Models/Errors/CancelSubscriptionHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ListAllSubscriptionsNotFoundHalJSONException`](./src/Mollie/Models/Errors/ListAllSubscriptionsNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`CreateSalesInvoiceNotFoundHalJSONException`](./src/Mollie/Models/Errors/CreateSalesInvoiceNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`GetSalesInvoiceHalJSONException`](./src/Mollie/Models/Errors/GetSalesInvoiceHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`UpdateSalesInvoiceNotFoundHalJSONException`](./src/Mollie/Models/Errors/UpdateSalesInvoiceNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`DeleteSalesInvoiceNotFoundHalJSONException`](./src/Mollie/Models/Errors/DeleteSalesInvoiceNotFoundHalJSONException.cs): An error response object. Status code `404`. Applicable to 1 of 93 methods.*
  * [`ConflictHalJSONException`](./src/Mollie/Models/Errors/ConflictHalJSONException.cs): An error response object. Status code `409`. Applicable to 1 of 93 methods.*
  * [`GetProfileGoneHalJSONException`](./src/Mollie/Models/Errors/GetProfileGoneHalJSONException.cs): An error response object. Status code `410`. Applicable to 1 of 93 methods.*
  * [`UpdateProfileGoneHalJSONException`](./src/Mollie/Models/Errors/UpdateProfileGoneHalJSONException.cs): An error response object. Status code `410`. Applicable to 1 of 93 methods.*
  * [`DeleteProfileGoneHalJSONException`](./src/Mollie/Models/Errors/DeleteProfileGoneHalJSONException.cs): An error response object. Status code `410`. Applicable to 1 of 93 methods.*
  * [`GetBalanceReportUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/GetBalanceReportUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateProfileHalJSONException`](./src/Mollie/Models/Errors/CreateProfileHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`UpdateProfileUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/UpdateProfileUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateClientLinkUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreateClientLinkUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateWebhookHalJSONException`](./src/Mollie/Models/Errors/CreateWebhookHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`UpdateWebhookUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/UpdateWebhookUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`GetWebhookUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/GetWebhookUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`DeleteWebhookUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/DeleteWebhookUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`TestWebhookUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/TestWebhookUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreatePaymentUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreatePaymentUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`UpdatePaymentUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/UpdatePaymentUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CancelPaymentUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CancelPaymentUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`ReleaseAuthorizationUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/ReleaseAuthorizationUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateRefundUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreateRefundUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateCaptureUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreateCaptureUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`RequestApplePayPaymentSessionHalJSONException`](./src/Mollie/Models/Errors/RequestApplePayPaymentSessionHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreatePaymentLinkUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreatePaymentLinkUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`UpdatePaymentLinkUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/UpdatePaymentLinkUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`DeletePaymentLinkUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/DeletePaymentLinkUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateCustomerPaymentUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreateCustomerPaymentUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`CreateSalesInvoiceUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/CreateSalesInvoiceUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`UpdateSalesInvoiceUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/UpdateSalesInvoiceUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`DeleteSalesInvoiceUnprocessableEntityHalJSONException`](./src/Mollie/Models/Errors/DeleteSalesInvoiceUnprocessableEntityHalJSONException.cs): An error response object. Status code `422`. Applicable to 1 of 93 methods.*
  * [`TooManyRequestsHalJSONException`](./src/Mollie/Models/Errors/TooManyRequestsHalJSONException.cs): An error response object. Status code `429`. Applicable to 1 of 93 methods.*
  * [`CreatePaymentServiceUnavailableHalJSONException`](./src/Mollie/Models/Errors/CreatePaymentServiceUnavailableHalJSONException.cs): An error response object. Status code `503`. Applicable to 1 of 93 methods.*
  * [`CreateCustomerPaymentServiceUnavailableHalJSONException`](./src/Mollie/Models/Errors/CreateCustomerPaymentServiceUnavailableHalJSONException.cs): An error response object. Status code `503`. Applicable to 1 of 93 methods.*
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

var sdk = new Client(
    serverUrl: "https://api.mollie.com/v2",
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Balances.ListAsync(
    currency: "EUR",
    fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
    limit: 50,
    testmode: false
);

// handle response
```
<!-- End Server Selection [server] -->

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
