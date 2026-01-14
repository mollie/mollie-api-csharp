# Payments

## Overview

### Available Operations

* [Create](#create) - Create payment
* [List](#list) - List payments
* [Get](#get) - Get payment
* [Update](#update) - Update payment
* [Cancel](#cancel) - Cancel payment
* [ReleaseAuthorization](#releaseauthorization) - Release payment authorization

## Create

Payment creation is elemental to the Mollie API: this is where most payment
implementations start off.

Once you have created a payment, you should redirect your customer to the
URL in the `_links.checkout` property from the response.

To wrap your head around the payment process, an explanation and flow charts
can be found in the 'Accepting payments' guide.

If you specify the `method` parameter when creating a payment, optional
additional parameters may be available for the payment method that are not listed below. Please refer to the
guide on [method-specific parameters](extra-payment-parameters).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-payment" method="post" path="/payments" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.CreateAsync(
    include: "details.qrCode",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<PaymentRequestLine>() {
            new PaymentRequestLine() {
                Type = PaymentLineType.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new RecurringLineItem() {
                    Description = "Gym subscription",
                    Interval = "... days",
                    Amount = new Amount() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new PaymentAddress() {
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
        Locale = Locale.EnUS,
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CaptureMode.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new PaymentRequestApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<EntityPaymentRoute>() {
            new EntityPaymentRoute() {
                Amount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new EntityPaymentRouteDestination() {
                    Type = RouteDestinationType.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new EntityPaymentRouteLinks() {
                    Self = new Url() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new Url() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = SequenceType.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new Company() {
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

### Parameters

| Parameter                                                                                            | Type                                                                                                 | Required                                                                                             | Description                                                                                          | Example                                                                                              |
| ---------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------- |
| `Include`                                                                                            | *string*                                                                                             | :heavy_minus_sign:                                                                                   | This endpoint allows you to include additional information via the `include` query string parameter. |                                                                                                      |
| `IdempotencyKey`                                                                                     | *string*                                                                                             | :heavy_minus_sign:                                                                                   | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                     | 123e4567-e89b-12d3-a456-426                                                                          |
| `PaymentRequest`                                                                                     | [PaymentRequest](../../Models/Components/PaymentRequest.md)                                          | :heavy_minus_sign:                                                                                   | N/A                                                                                                  |                                                                                                      |

### Response

**[CreatePaymentResponse](../../Models/Requests/CreatePaymentResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422                                | application/hal+json               |
| Mollie.Models.Errors.ErrorResponse | 503                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve all payments created with the current website profile.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-payments" method="get" path="/payments" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListPaymentsRequest req = new ListPaymentsRequest() {
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Payments.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListPaymentsRequest](../../Models/Requests/ListPaymentsRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListPaymentsResponse](../../Models/Requests/ListPaymentsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single payment object by its payment ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-payment" method="get" path="/payments/{paymentId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetPaymentRequest req = new GetPaymentRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    Include = "details.qrCode",
    Embed = "captures",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Payments.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [GetPaymentRequest](../../Models/Requests/GetPaymentRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[GetPaymentResponse](../../Models/Requests/GetPaymentResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Certain details of an existing payment can be updated.

Updating the payment details will not result in a webhook call.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-payment" method="patch" path="/payments/{paymentId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.UpdateAsync(
    paymentId: "tr_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new UpdatePaymentRequestBody() {
        Description = "Chess Board",
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Method = MethodEnum.Ideal,
        Locale = Locale.EnUS,
        DueDate = "2025-01-01",
        RestrictPaymentMethodsToCountry = "NL",
        Testmode = false,
        Issuer = "ideal_INGBNL2A",
        BillingAddress = new BillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new PaymentAddress() {
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
        BillingEmail = "test@example.com",
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `PaymentId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related payment.                                           | tr_5B8cwPMGnU                                                                    |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `RequestBody`                                                                    | [UpdatePaymentRequestBody](../../Models/Requests/UpdatePaymentRequestBody.md)    | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[UpdatePaymentResponse](../../Models/Requests/UpdatePaymentResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Cancel

Depending on the payment method, you may be able to cancel a payment for a certain amount of time — usually until
the next business day or as long as the payment status is open.

Payments may also be canceled manually from the Mollie Dashboard.

The `isCancelable` property on the [Payment object](get-payment) will indicate if the payment can be canceled.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-payment" method="delete" path="/payments/{paymentId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.CancelAsync(
    paymentId: "tr_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new CancelPaymentRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `PaymentId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related payment.                                           | tr_5B8cwPMGnU                                                                    |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `RequestBody`                                                                    | [CancelPaymentRequestBody](../../Models/Requests/CancelPaymentRequestBody.md)    | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[CancelPaymentResponse](../../Models/Requests/CancelPaymentResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ReleaseAuthorization

Releases the full remaining authorized amount. Call this endpoint when you will not be making any additional
captures. Payment authorizations may also be released manually from the Mollie Dashboard.

Mollie will do its best to process release requests, but it is not guaranteed that it will succeed. It is up to
the issuing bank if and when the hold will be released.

If the request does succeed, the payment status will change to `canceled` for payments without captures.
If there is a successful capture, the payment will transition to `paid`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="release-authorization" method="post" path="/payments/{paymentId}/release-authorization" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.ReleaseAuthorizationAsync(
    paymentId: "tr_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new ReleaseAuthorizationRequestBody() {
        ProfileId = "pfl_5B8cwPMGnU",
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 | Example                                                                                     |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                 | *string*                                                                                    | :heavy_check_mark:                                                                          | Provide the ID of the related payment.                                                      | tr_5B8cwPMGnU                                                                               |
| `IdempotencyKey`                                                                            | *string*                                                                                    | :heavy_minus_sign:                                                                          | A unique key to ensure idempotent requests. This key should be a UUID v4 string.            | 123e4567-e89b-12d3-a456-426                                                                 |
| `RequestBody`                                                                               | [ReleaseAuthorizationRequestBody](../../Models/Requests/ReleaseAuthorizationRequestBody.md) | :heavy_minus_sign:                                                                          | N/A                                                                                         |                                                                                             |

### Response

**[ReleaseAuthorizationResponse](../../Models/Requests/ReleaseAuthorizationResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |