# PaymentLinks
(*PaymentLinks*)

## Overview

### Available Operations

* [Create](#create) - Create payment link
* [List](#list) - List payment links
* [Get](#get) - Get payment link
* [Update](#update) - Update payment link
* [Delete](#delete) - Delete payment link
* [ListPayments](#listpayments) - Get payment link payments

## Create

With the Payment links API you can generate payment links that by default, unlike regular payments, do not expire. The payment link can be shared with your customers and will redirect them to them the payment page where they can complete the payment. A [payment](get-payment) will only be created once the customer initiates the payment.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payment-links.write**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-payment-link" method="post" path="/payment-links" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreatePaymentLinkRequest req = new CreatePaymentLinkRequest() {
    Description = "Chess Board",
    Amount = new CreatePaymentLinkAmountRequest() {
        Currency = "EUR",
        Value = "10.00",
    },
    MinimumAmount = new CreatePaymentLinkMinimumAmountRequest() {
        Currency = "EUR",
        Value = "10.00",
    },
    RedirectUrl = "https://webshop.example.org/payment-links/redirect/",
    WebhookUrl = "https://webshop.example.org/payment-links/webhook/",
    Lines = new List<CreatePaymentLinkLineRequest>() {
        new CreatePaymentLinkLineRequest() {
            Description = "LEGO 4440 Forest Police Station",
            Quantity = 1,
            QuantityUnit = "pcs",
            UnitPrice = new CreatePaymentLinkUnitPriceRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            DiscountAmount = new CreatePaymentLinkDiscountAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            TotalAmount = new CreatePaymentLinkTotalAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            VatRate = "21.00",
            VatAmount = new CreatePaymentLinkVatAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Sku = "9780241661628",
            Categories = new List<CreatePaymentLinkCategoryRequest>() {
                CreatePaymentLinkCategoryRequest.Meal,
                CreatePaymentLinkCategoryRequest.Eco,
            },
            ImageUrl = "https://...",
            ProductUrl = "https://...",
        },
    },
    BillingAddress = new CreatePaymentLinkBillingAddressRequest() {
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
    ShippingAddress = new CreatePaymentLinkShippingAddressRequest() {
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
    ExpiresAt = "2025-12-24T11:00:16+00:00",
    AllowedMethods = null,
    ApplicationFee = new CreatePaymentLinkApplicationFeeRequest() {
        Amount = new CreatePaymentLinkApplicationFeeAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Platform fee",
    },
};

var res = await sdk.PaymentLinks.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [CreatePaymentLinkRequest](../../Models/Requests/CreatePaymentLinkRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[CreatePaymentLinkResponse](../../Models/Requests/CreatePaymentLinkResponse.md)**

### Errors

| Error Type                                                                | Status Code                                                               | Content Type                                                              |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| Mollie.Models.Errors.CreatePaymentLinkNotFoundHalJSONException            | 404                                                                       | application/hal+json                                                      |
| Mollie.Models.Errors.CreatePaymentLinkUnprocessableEntityHalJSONException | 422                                                                       | application/hal+json                                                      |
| Mollie.Models.Errors.APIException                                         | 4XX, 5XX                                                                  | \*/\*                                                                     |

## List

Retrieve a list of all payment links.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payment-links.read**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-payment-links" method="get" path="/payment-links" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.ListAsync(
    fromP: "pl_d9fQur83kFdhH8hIhaZfq",
    limit: 50,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `From`                                                                                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the result set.                                                                                                                                                                                                                                                         | pl_d9fQur83kFdhH8hIhaZfq                                                                                                                                                                                                                                                                                                                                                               |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | The maximum number of items to return. Defaults to 50 items.                                                                                                                                                                                                                                                                                                                           | 50                                                                                                                                                                                                                                                                                                                                                                                     |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[ListPaymentLinksResponse](../../Models/Requests/ListPaymentLinksResponse.md)**

### Errors

| Error Type                                            | Status Code                                           | Content Type                                          |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| Mollie.Models.Errors.ListPaymentLinksHalJSONException | 400                                                   | application/hal+json                                  |
| Mollie.Models.Errors.APIException                     | 4XX, 5XX                                              | \*/\*                                                 |

## Get

Retrieve a single payment link by its ID.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payment-links.read**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-payment-link" method="get" path="/payment-links/{paymentLinkId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.GetAsync(
    paymentLinkId: "pl_d9fQur83kFdhH8hIhaZfq",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentLinkId`                                                                                                                                                                                                                                                                                                                                                                        | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment link.                                                                                                                                                                                                                                                                                                                                            | pl_d9fQur83kFdhH8hIhaZfq                                                                                                                                                                                                                                                                                                                                                               |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetPaymentLinkResponse](../../Models/Requests/GetPaymentLinkResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| Mollie.Models.Errors.GetPaymentLinkHalJSONException | 404                                                 | application/hal+json                                |
| Mollie.Models.Errors.APIException                   | 4XX, 5XX                                            | \*/\*                                               |

## Update

Certain details of an existing payment link can be updated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payment-links.write**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-payment-link" method="patch" path="/payment-links/{paymentLinkId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.UpdateAsync(
    paymentLinkId: "pl_d9fQur83kFdhH8hIhaZfq",
    requestBody: new UpdatePaymentLinkRequestBody() {
        Description = "Chess Board",
        MinimumAmount = new UpdatePaymentLinkMinimumAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        Archived = false,
        AllowedMethods = new List<string>() {
            "ideal",
        },
        Lines = null,
        BillingAddress = new UpdatePaymentLinkBillingAddressRequest() {
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
        ShippingAddress = new UpdatePaymentLinkShippingAddressRequest() {
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
    }
);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `PaymentLinkId`                                                                       | *string*                                                                              | :heavy_check_mark:                                                                    | Provide the ID of the related payment link.                                           | pl_d9fQur83kFdhH8hIhaZfq                                                              |
| `RequestBody`                                                                         | [UpdatePaymentLinkRequestBody](../../Models/Requests/UpdatePaymentLinkRequestBody.md) | :heavy_minus_sign:                                                                    | N/A                                                                                   |                                                                                       |

### Response

**[UpdatePaymentLinkResponse](../../Models/Requests/UpdatePaymentLinkResponse.md)**

### Errors

| Error Type                                                                | Status Code                                                               | Content Type                                                              |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| Mollie.Models.Errors.UpdatePaymentLinkNotFoundHalJSONException            | 404                                                                       | application/hal+json                                                      |
| Mollie.Models.Errors.UpdatePaymentLinkUnprocessableEntityHalJSONException | 422                                                                       | application/hal+json                                                      |
| Mollie.Models.Errors.APIException                                         | 4XX, 5XX                                                                  | \*/\*                                                                     |

## Delete

Payment links which have not been opened and no payments have been made yet can be deleted entirely. This can be useful for removing payment links that have been incorrectly configured or that are no longer relevant.

Once deleted, the payment link will no longer show up in the API or Mollie dashboard.

To simply disable a payment link without fully deleting it, you can use the `archived` parameter on the [Update payment link](update-payment-link) endpoint instead.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payment-links.write**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-payment-link" method="delete" path="/payment-links/{paymentLinkId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.PaymentLinks.DeleteAsync(
    paymentLinkId: "pl_d9fQur83kFdhH8hIhaZfq",
    requestBody: new DeletePaymentLinkRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `PaymentLinkId`                                                                       | *string*                                                                              | :heavy_check_mark:                                                                    | Provide the ID of the related payment link.                                           | pl_d9fQur83kFdhH8hIhaZfq                                                              |
| `RequestBody`                                                                         | [DeletePaymentLinkRequestBody](../../Models/Requests/DeletePaymentLinkRequestBody.md) | :heavy_minus_sign:                                                                    | N/A                                                                                   |                                                                                       |

### Response

**[DeletePaymentLinkResponse](../../Models/Requests/DeletePaymentLinkResponse.md)**

### Errors

| Error Type                                                                | Status Code                                                               | Content Type                                                              |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| Mollie.Models.Errors.DeletePaymentLinkNotFoundHalJSONException            | 404                                                                       | application/hal+json                                                      |
| Mollie.Models.Errors.DeletePaymentLinkUnprocessableEntityHalJSONException | 422                                                                       | application/hal+json                                                      |
| Mollie.Models.Errors.APIException                                         | 4XX, 5XX                                                                  | \*/\*                                                                     |

## ListPayments

Retrieve the list of payments for a specific payment link.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payment-links.read**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-payment-link-payments" method="get" path="/payment-links/{paymentLinkId}/payments" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

GetPaymentLinkPaymentsRequest req = new GetPaymentLinkPaymentsRequest() {
    PaymentLinkId = "pl_d9fQur83kFdhH8hIhaZfq",
    From = "tr_5B8cwPMGnU",
    Sort = "desc",
    Testmode = false,
};

var res = await sdk.PaymentLinks.ListPaymentsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [GetPaymentLinkPaymentsRequest](../../Models/Requests/GetPaymentLinkPaymentsRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[GetPaymentLinkPaymentsResponse](../../Models/Requests/GetPaymentLinkPaymentsResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Mollie.Models.Errors.GetPaymentLinkPaymentsHalJSONException | 400                                                         | application/hal+json                                        |
| Mollie.Models.Errors.APIException                           | 4XX, 5XX                                                    | \*/\*                                                       |