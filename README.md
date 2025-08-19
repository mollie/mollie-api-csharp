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
using Mollie.Models.Requests;
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.CreateAsync(
    include: CreatePaymentInclude.DetailsQrCode,
    requestBody: new CreatePaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreatePaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreatePaymentLineRequest>() {
            new CreatePaymentLineRequest() {
                Type = CreatePaymentLineTypeRequest.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreatePaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreatePaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreatePaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreatePaymentCategoryRequest>() {
                    CreatePaymentCategoryRequest.Meal,
                    CreatePaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreatePaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = "... days",
                    Amount = new CreatePaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreatePaymentBillingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new CreatePaymentShippingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        Locale = CreatePaymentLocaleRequest.EnUS,
        Method = CreatePaymentMethodRequest.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CreatePaymentCaptureModeRequest.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new CreatePaymentApplicationFeeRequest() {
            Amount = new CreatePaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreatePaymentRoutingRequest>() {
            new CreatePaymentRoutingRequest() {
                Amount = new CreatePaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreatePaymentDestinationRequest() {
                    Type = CreatePaymentRoutingTypeRequest.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreatePaymentLinksRequest() {
                    Self = new CreatePaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreatePaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = CreatePaymentSequenceTypeRequest.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new CreatePaymentCompany() {
            RegistrationNumber = "12345678",
            VatNumber = "NL123456789B01",
        },
        CardToken = "tkn_12345",
        VoucherNumber = "1234567890",
        VoucherPin = "1234",
        ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
        DigitalGoods = true,
        CustomerReference = "1234567890",
        TerminalId = "term_1234567890",
    }
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
using Mollie.Models.Requests;
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.CreateAsync(
    include: CreatePaymentInclude.DetailsQrCode,
    requestBody: new CreatePaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreatePaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreatePaymentLineRequest>() {
            new CreatePaymentLineRequest() {
                Type = CreatePaymentLineTypeRequest.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreatePaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreatePaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreatePaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreatePaymentCategoryRequest>() {
                    CreatePaymentCategoryRequest.Meal,
                    CreatePaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreatePaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = "... days",
                    Amount = new CreatePaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreatePaymentBillingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new CreatePaymentShippingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        Locale = CreatePaymentLocaleRequest.EnUS,
        Method = CreatePaymentMethodRequest.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CreatePaymentCaptureModeRequest.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new CreatePaymentApplicationFeeRequest() {
            Amount = new CreatePaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreatePaymentRoutingRequest>() {
            new CreatePaymentRoutingRequest() {
                Amount = new CreatePaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreatePaymentDestinationRequest() {
                    Type = CreatePaymentRoutingTypeRequest.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreatePaymentLinksRequest() {
                    Self = new CreatePaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreatePaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = CreatePaymentSequenceTypeRequest.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new CreatePaymentCompany() {
            RegistrationNumber = "12345678",
            VatNumber = "NL123456789B01",
        },
        CardToken = "tkn_12345",
        VoucherNumber = "1234567890",
        VoucherPin = "1234",
        ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
        DigitalGoods = true,
        CustomerReference = "1234567890",
        TerminalId = "term_1234567890",
    }
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
using Mollie.Models.Requests;
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.CreateAsync(
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
    include: CreatePaymentInclude.DetailsQrCode,
    requestBody: new CreatePaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreatePaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreatePaymentLineRequest>() {
            new CreatePaymentLineRequest() {
                Type = CreatePaymentLineTypeRequest.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreatePaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreatePaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreatePaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreatePaymentCategoryRequest>() {
                    CreatePaymentCategoryRequest.Meal,
                    CreatePaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreatePaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = "... days",
                    Amount = new CreatePaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreatePaymentBillingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new CreatePaymentShippingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        Locale = CreatePaymentLocaleRequest.EnUS,
        Method = CreatePaymentMethodRequest.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CreatePaymentCaptureModeRequest.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new CreatePaymentApplicationFeeRequest() {
            Amount = new CreatePaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreatePaymentRoutingRequest>() {
            new CreatePaymentRoutingRequest() {
                Amount = new CreatePaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreatePaymentDestinationRequest() {
                    Type = CreatePaymentRoutingTypeRequest.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreatePaymentLinksRequest() {
                    Self = new CreatePaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreatePaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = CreatePaymentSequenceTypeRequest.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new CreatePaymentCompany() {
            RegistrationNumber = "12345678",
            VatNumber = "NL123456789B01",
        },
        CardToken = "tkn_12345",
        VoucherNumber = "1234567890",
        VoucherPin = "1234",
        ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
        DigitalGoods = true,
        CustomerReference = "1234567890",
        TerminalId = "term_1234567890",
    }
);

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using NodaTime;
using System.Collections.Generic;

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

var res = await sdk.Payments.CreateAsync(
    include: CreatePaymentInclude.DetailsQrCode,
    requestBody: new CreatePaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreatePaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreatePaymentLineRequest>() {
            new CreatePaymentLineRequest() {
                Type = CreatePaymentLineTypeRequest.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreatePaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreatePaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreatePaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreatePaymentCategoryRequest>() {
                    CreatePaymentCategoryRequest.Meal,
                    CreatePaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreatePaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = "... days",
                    Amount = new CreatePaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreatePaymentBillingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new CreatePaymentShippingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        Locale = CreatePaymentLocaleRequest.EnUS,
        Method = CreatePaymentMethodRequest.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CreatePaymentCaptureModeRequest.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new CreatePaymentApplicationFeeRequest() {
            Amount = new CreatePaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreatePaymentRoutingRequest>() {
            new CreatePaymentRoutingRequest() {
                Amount = new CreatePaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreatePaymentDestinationRequest() {
                    Type = CreatePaymentRoutingTypeRequest.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreatePaymentLinksRequest() {
                    Self = new CreatePaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreatePaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = CreatePaymentSequenceTypeRequest.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new CreatePaymentCompany() {
            RegistrationNumber = "12345678",
            VatNumber = "NL123456789B01",
        },
        CardToken = "tkn_12345",
        VoucherNumber = "1234567890",
        VoucherPin = "1234",
        ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
        DigitalGoods = true,
        CustomerReference = "1234567890",
        TerminalId = "term_1234567890",
    }
);

// handle response
```
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `Mollie.Models.Errors.APIException` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `Request`     | *HttpRequestMessage*  | The HTTP request      |
| `Response`    | *HttpResponseMessage* | The HTTP response     |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `CreateAsync` method throws the following exceptions:

| Error Type                                                            | Status Code | Content Type         |
| --------------------------------------------------------------------- | ----------- | -------------------- |
| Mollie.Models.Errors.CreatePaymentUnprocessableEntityHalJSONException | 422         | application/hal+json |
| Mollie.Models.Errors.CreatePaymentServiceUnavailableHalJSONException  | 503         | application/hal+json |
| Mollie.Models.Errors.APIException                                     | 4XX, 5XX    | \*/\*                |

### Example

```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Errors;
using Mollie.Models.Requests;
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

try
{
    var res = await sdk.Payments.CreateAsync(
        include: CreatePaymentInclude.DetailsQrCode,
        requestBody: new CreatePaymentRequestBody() {
            Description = "Chess Board",
            Amount = new CreatePaymentAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            RedirectUrl = "https://example.org/redirect",
            CancelUrl = "https://example.org/cancel",
            WebhookUrl = "https://example.org/webhooks",
            Lines = new List<CreatePaymentLineRequest>() {
                new CreatePaymentLineRequest() {
                    Type = CreatePaymentLineTypeRequest.Physical,
                    Description = "LEGO 4440 Forest Police Station",
                    Quantity = 1,
                    QuantityUnit = "pcs",
                    UnitPrice = new CreatePaymentUnitPriceRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    TotalAmount = new CreatePaymentTotalAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    VatRate = "21.00",
                    VatAmount = new CreatePaymentVatAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Sku = "9780241661628",
                    Categories = new List<CreatePaymentCategoryRequest>() {
                        CreatePaymentCategoryRequest.Meal,
                        CreatePaymentCategoryRequest.Eco,
                    },
                    ImageUrl = "https://...",
                    ProductUrl = "https://...",
                    Recurring = new CreatePaymentRecurringRequest() {
                        Description = "Gym subscription",
                        Interval = "... days",
                        Amount = new CreatePaymentRecurringAmountRequest() {
                            Currency = "EUR",
                            Value = "10.00",
                        },
                        Times = 1,
                        StartDate = "2024-12-12",
                    },
                },
            },
            BillingAddress = new CreatePaymentBillingAddressRequest() {
                Title = "Mr.",
                GivenName = "Piet",
                FamilyName = "Mondriaan",
                OrganizationName = "Mollie B.V.",
                StreetAndNumber = "Keizersgracht 126",
                StreetAdditional = "Apt. 1",
                PostalCode = "1234AB",
                Email = "piet@example.org",
                Phone = "31208202070",
                City = "Amsterdam",
                Region = "Noord-Holland",
                Country = "NL",
            },
            ShippingAddress = new CreatePaymentShippingAddressRequest() {
                Title = "Mr.",
                GivenName = "Piet",
                FamilyName = "Mondriaan",
                OrganizationName = "Mollie B.V.",
                StreetAndNumber = "Keizersgracht 126",
                StreetAdditional = "Apt. 1",
                PostalCode = "1234AB",
                Email = "piet@example.org",
                Phone = "31208202070",
                City = "Amsterdam",
                Region = "Noord-Holland",
                Country = "NL",
            },
            Locale = CreatePaymentLocaleRequest.EnUS,
            Method = CreatePaymentMethodRequest.Ideal,
            Issuer = "ideal_INGBNL2A",
            RestrictPaymentMethodsToCountry = "NL",
            CaptureMode = CreatePaymentCaptureModeRequest.Manual,
            CaptureDelay = "8 hours",
            ApplicationFee = new CreatePaymentApplicationFeeRequest() {
                Amount = new CreatePaymentApplicationFeeAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Description = "10",
            },
            Routing = new List<CreatePaymentRoutingRequest>() {
                new CreatePaymentRoutingRequest() {
                    Amount = new CreatePaymentRoutingAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Destination = new CreatePaymentDestinationRequest() {
                        Type = CreatePaymentRoutingTypeRequest.Organization,
                        OrganizationId = "org_1234567",
                    },
                    ReleaseDate = "2024-12-12",
                    Links = new CreatePaymentLinksRequest() {
                        Self = new CreatePaymentSelfRequest() {
                            Href = "https://...",
                            Type = "application/hal+json",
                        },
                        Payment = new CreatePaymentPaymentRequest() {
                            Href = "https://...",
                            Type = "application/hal+json",
                        },
                    },
                },
            },
            SequenceType = CreatePaymentSequenceTypeRequest.Oneoff,
            MandateId = "mdt_5B8cwPMGnU",
            CustomerId = "cst_5B8cwPMGnU",
            ProfileId = "pfl_5B8cwPMGnU",
            DueDate = "2025-01-01",
            Testmode = false,
            ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
            Company = new CreatePaymentCompany() {
                RegistrationNumber = "12345678",
                VatNumber = "NL123456789B01",
            },
            CardToken = "tkn_12345",
            VoucherNumber = "1234567890",
            VoucherPin = "1234",
            ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
            DigitalGoods = true,
            CustomerReference = "1234567890",
            TerminalId = "term_1234567890",
        }
    );

    // handle response
}
catch (Exception ex)
{
    if (ex is CreatePaymentUnprocessableEntityHalJSONException)
    {
        // Handle exception data
        throw;
    }
    else if (ex is CreatePaymentServiceUnavailableHalJSONException)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Mollie.Models.Errors.APIException)
    {
        // Handle default exception
        throw;
    }
}
```
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Override Server URL Per-Client

The default server can be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(
    serverUrl: "https://api.mollie.com/v2",
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Payments.CreateAsync(
    include: CreatePaymentInclude.DetailsQrCode,
    requestBody: new CreatePaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreatePaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreatePaymentLineRequest>() {
            new CreatePaymentLineRequest() {
                Type = CreatePaymentLineTypeRequest.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreatePaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreatePaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreatePaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreatePaymentCategoryRequest>() {
                    CreatePaymentCategoryRequest.Meal,
                    CreatePaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreatePaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = "... days",
                    Amount = new CreatePaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreatePaymentBillingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new CreatePaymentShippingAddressRequest() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        Locale = CreatePaymentLocaleRequest.EnUS,
        Method = CreatePaymentMethodRequest.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CreatePaymentCaptureModeRequest.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new CreatePaymentApplicationFeeRequest() {
            Amount = new CreatePaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreatePaymentRoutingRequest>() {
            new CreatePaymentRoutingRequest() {
                Amount = new CreatePaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreatePaymentDestinationRequest() {
                    Type = CreatePaymentRoutingTypeRequest.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreatePaymentLinksRequest() {
                    Self = new CreatePaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreatePaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = CreatePaymentSequenceTypeRequest.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new CreatePaymentCompany() {
            RegistrationNumber = "12345678",
            VatNumber = "NL123456789B01",
        },
        CardToken = "tkn_12345",
        VoucherNumber = "1234567890",
        VoucherPin = "1234",
        ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
        DigitalGoods = true,
        CustomerReference = "1234567890",
        TerminalId = "term_1234567890",
    }
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
