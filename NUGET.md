# MollieApi


<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
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
                    Interval = "12 months",
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
        Locale = "en_US",
        Method = "ideal",
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = "manual",
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
                    Type = "organization",
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
        SequenceType = "oneoff",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
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
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
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
                    Interval = "12 months",
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
        Locale = "en_US",
        Method = "ideal",
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = "manual",
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
                    Type = "organization",
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
        SequenceType = "oneoff",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
    }
);

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Retries [retries] -->
## Retries

Some of the endpoints in this SDK support retries. If you use the SDK without any configuration, it will fall back to the default retry strategy provided by the API. However, the default retry strategy can be overridden on a per-operation basis, or across the entire SDK.

To change the default retry strategy for a single API call, simply pass a `RetryConfig` to the call:
```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
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
                    Interval = "12 months",
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
        Locale = "en_US",
        Method = "ideal",
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = "manual",
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
                    Type = "organization",
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
        SequenceType = "oneoff",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
    }
);

// handle response
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
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
                    Interval = "12 months",
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
        Locale = "en_US",
        Method = "ideal",
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = "manual",
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
                    Type = "organization",
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
        SequenceType = "oneoff",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
    }
);

// handle response
```
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `MollieApi.Models.Errors.APIException` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `Request`     | *HttpRequestMessage*  | The HTTP request      |
| `Response`    | *HttpResponseMessage* | The HTTP response     |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `CreateAsync` method throws the following exceptions:

| Error Type                                                               | Status Code | Content Type         |
| ------------------------------------------------------------------------ | ----------- | -------------------- |
| MollieApi.Models.Errors.CreatePaymentUnprocessableEntityHalJSONException | 422         | application/hal+json |
| MollieApi.Models.Errors.CreatePaymentServiceUnavailableHalJSONException  | 503         | application/hal+json |
| MollieApi.Models.Errors.APIException                                     | 4XX, 5XX    | \*/\*                |

### Example

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Errors;
using MollieApi.Models.Requests;
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
                        Interval = "12 months",
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
            Locale = "en_US",
            Method = "ideal",
            Issuer = "ideal_INGBNL2A",
            RestrictPaymentMethodsToCountry = "NL",
            CaptureMode = "manual",
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
                        Type = "organization",
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
            SequenceType = "oneoff",
            MandateId = "mdt_5B8cwPMGnU",
            CustomerId = "cst_5B8cwPMGnU",
            ProfileId = "pfl_5B8cwPMGnU",
            DueDate = "2025-01-01",
            Testmode = false,
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
    else if (ex is MollieApi.Models.Errors.APIException)
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
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
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
                    Interval = "12 months",
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
        Locale = "en_US",
        Method = "ideal",
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = "manual",
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
                    Type = "organization",
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
        SequenceType = "oneoff",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
    }
);

// handle response
```
<!-- End Server Selection [server] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->