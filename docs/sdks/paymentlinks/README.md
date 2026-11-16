# PaymentLinks

## Overview

### Available Operations

* [Create](#create) - Create payment link
* [List](#list) - List payment links
* [Get](#get) - Get payment link
* [Update](#update) - Update payment link
* [Delete](#delete) - Delete payment link
* [ListPayments](#listpayments) - Get payment link payments

## Create

With the Payment links API you can generate payment links that by default, unlike regular payments, do not expire.
The payment link can be shared with your customers and will redirect them to them the payment page where they can
complete the payment. A [payment](get-payment) will only be created once the customer initiates the payment.

### Example Usage: create-payment-link-201-1

<!-- UsageSnippet language="csharp" operationID="create-payment-link" method="post" path="/v2/payment-links" example="create-payment-link-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
    requestBody: new CreatePaymentLinkRequestBody() {
        Description = "Chess Board",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        MinimumAmount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://webshop.example.org/payment-links/redirect/",
        WebhookUrl = "https://webshop.example.org/payment-links/webhook/",
        Lines = new List<PaymentLineItem>() {
            new PaymentLineItem() {
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
            },
        },
        BillingAddress = new PaymentAddress() {
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
        ProfileId = "pfl_QkEhN94Ba",
        Reusable = false,
        ExpiresAt = "2025-12-24T11:00:16+00:00",
        AllowedMethods = null,
        ApplicationFee = new ApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "Platform fee",
        },
        SequenceType = PaymentLinkSequenceType.Oneoff,
        CustomerId = "cst_XimFHuaEzd",
        Testmode = false,
    }
);

// handle response
```
### Example Usage: create-payment-link-201-2

<!-- UsageSnippet language="csharp" operationID="create-payment-link" method="post" path="/v2/payment-links" example="create-payment-link-201-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
    requestBody: new CreatePaymentLinkRequestBody() {
        Description = "Chess Board",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        MinimumAmount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://webshop.example.org/payment-links/redirect/",
        WebhookUrl = "https://webshop.example.org/payment-links/webhook/",
        Lines = new List<PaymentLineItem>() {
            new PaymentLineItem() {
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
            },
        },
        BillingAddress = new PaymentAddress() {
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
        ProfileId = "pfl_QkEhN94Ba",
        Reusable = false,
        ExpiresAt = "2025-12-24T11:00:16+00:00",
        AllowedMethods = null,
        ApplicationFee = new ApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "Platform fee",
        },
        SequenceType = PaymentLinkSequenceType.Oneoff,
        CustomerId = "cst_XimFHuaEzd",
        Testmode = false,
    }
);

// handle response
```
### Example Usage: create-payment-link-201-3

<!-- UsageSnippet language="csharp" operationID="create-payment-link" method="post" path="/v2/payment-links" example="create-payment-link-201-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
    requestBody: new CreatePaymentLinkRequestBody() {
        Description = "Chess Board",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        MinimumAmount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://webshop.example.org/payment-links/redirect/",
        WebhookUrl = "https://webshop.example.org/payment-links/webhook/",
        Lines = new List<PaymentLineItem>() {
            new PaymentLineItem() {
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
            },
        },
        BillingAddress = new PaymentAddress() {
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
        ProfileId = "pfl_QkEhN94Ba",
        Reusable = false,
        ExpiresAt = "2025-12-24T11:00:16+00:00",
        AllowedMethods = null,
        ApplicationFee = new ApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "Platform fee",
        },
        SequenceType = PaymentLinkSequenceType.Oneoff,
        CustomerId = "cst_XimFHuaEzd",
        Testmode = false,
    }
);

// handle response
```
### Example Usage: create-payment-link-201-4

<!-- UsageSnippet language="csharp" operationID="create-payment-link" method="post" path="/v2/payment-links" example="create-payment-link-201-4" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
    requestBody: new CreatePaymentLinkRequestBody() {
        Description = "Chess Board",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        MinimumAmount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://webshop.example.org/payment-links/redirect/",
        WebhookUrl = "https://webshop.example.org/payment-links/webhook/",
        Lines = new List<PaymentLineItem>() {
            new PaymentLineItem() {
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
            },
        },
        BillingAddress = new PaymentAddress() {
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
        ProfileId = "pfl_QkEhN94Ba",
        Reusable = false,
        ExpiresAt = "2025-12-24T11:00:16+00:00",
        AllowedMethods = null,
        ApplicationFee = new ApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "Platform fee",
        },
        SequenceType = PaymentLinkSequenceType.Oneoff,
        CustomerId = "cst_XimFHuaEzd",
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |
| `RequestBody`                                                                                                                                                                           | [CreatePaymentLinkRequestBody](../../Models/Requests/CreatePaymentLinkRequestBody.md)                                                                                                   | :heavy_minus_sign:                                                                                                                                                                      | N/A                                                                                                                                                                                     |                                                                                                                                                                                         |

### Response

**[CreatePaymentLinkResponse](../../Models/Requests/CreatePaymentLinkResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all payment links.

The results are paginated.

### Example Usage: list-payment-links-200-1

<!-- UsageSnippet language="csharp" operationID="list-payment-links" method="get" path="/v2/payment-links" example="list-payment-links-200-1" -->
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

ListPaymentLinksRequest req = new ListPaymentLinksRequest() {
    From = "pl_d9fQur83kFdhH8hIhaZfq",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListPaymentLinksResponse? res = await sdk.PaymentLinks.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payment-links-200-2

<!-- UsageSnippet language="csharp" operationID="list-payment-links" method="get" path="/v2/payment-links" example="list-payment-links-200-2" -->
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

ListPaymentLinksRequest req = new ListPaymentLinksRequest() {
    From = "pl_d9fQur83kFdhH8hIhaZfq",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListPaymentLinksResponse? res = await sdk.PaymentLinks.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [ListPaymentLinksRequest](../../Models/Requests/ListPaymentLinksRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[ListPaymentLinksResponse](../../Models/Requests/ListPaymentLinksResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single payment link by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-payment-link" method="get" path="/v2/payment-links/{paymentLinkId}" example="get-payment-link-200-1" -->
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

GetPaymentLinkRequest req = new GetPaymentLinkRequest() {
    PaymentLinkId = "pl_d9fQur83kFdhH8hIhaZfq",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.PaymentLinks.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [GetPaymentLinkRequest](../../Models/Requests/GetPaymentLinkRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[GetPaymentLinkResponse](../../Models/Requests/GetPaymentLinkResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Certain details of an existing payment link can be updated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-payment-link" method="patch" path="/v2/payment-links/{paymentLinkId}" example="update-payment-link-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdatePaymentLinkRequest req = new UpdatePaymentLinkRequest() {
    PaymentLinkId = "pl_d9fQur83kFdhH8hIhaZfq",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdatePaymentLinkRequestBody() {
        Description = "Chess Board",
        MinimumAmount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Archived = false,
        AllowedMethods = new List<PaymentLinkMethod>() {
            PaymentLinkMethod.Ideal,
        },
        Lines = null,
        BillingAddress = new PaymentAddress() {
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
        Testmode = false,
    },
};

var res = await sdk.PaymentLinks.UpdateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [UpdatePaymentLinkRequest](../../Models/Requests/UpdatePaymentLinkRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[UpdatePaymentLinkResponse](../../Models/Requests/UpdatePaymentLinkResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Delete

Payment links which have not been opened and no payments have been made yet can be deleted entirely.
This can be useful for removing payment links that have been incorrectly configured or that are no longer relevant.

Once deleted, the payment link will no longer show up in the API or Mollie dashboard.

To simply disable a payment link without fully deleting it, you can use the `archived` parameter on the
[Update payment link](update-payment-link) endpoint instead.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-payment-link" method="delete" path="/v2/payment-links/{paymentLinkId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

DeletePaymentLinkRequest req = new DeletePaymentLinkRequest() {
    PaymentLinkId = "pl_d9fQur83kFdhH8hIhaZfq",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new DeletePaymentLinkRequestBody() {
        Testmode = false,
    },
};

var res = await sdk.PaymentLinks.DeleteAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [DeletePaymentLinkRequest](../../Models/Requests/DeletePaymentLinkRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[DeletePaymentLinkResponse](../../Models/Requests/DeletePaymentLinkResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListPayments

Retrieve the list of payments for a specific payment link.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-payment-link-payments" method="get" path="/v2/payment-links/{paymentLinkId}/payments" example="get-payment-link-payments-200-1" -->
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

GetPaymentLinkPaymentsRequest req = new GetPaymentLinkPaymentsRequest() {
    PaymentLinkId = "pl_d9fQur83kFdhH8hIhaZfq",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

GetPaymentLinkPaymentsResponse? res = await sdk.PaymentLinks.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [GetPaymentLinkPaymentsRequest](../../Models/Requests/GetPaymentLinkPaymentsRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[GetPaymentLinkPaymentsResponse](../../Models/Requests/GetPaymentLinkPaymentsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |