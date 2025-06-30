# Refunds
(*Refunds*)

## Overview

### Available Operations

* [Create](#create) - Create payment refund
* [List](#list) - List payment refunds
* [Get](#get) - Get payment refund
* [Cancel](#cancel) - Cancel payment refund
* [CreateOrder](#createorder) - Create order refund
* [ListForOrder](#listfororder) - List order refunds
* [All](#all) - List all refunds

## Create

Creates a refund for a specific payment. The refunded amount is credited to your customer usually either via a bank transfer or by refunding the amount to your customer's credit card.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Refunds.CreateAsync(
    paymentId: "tr_5B8cwPMGnU",
    requestBody: new CreateRefundRequestBody() {
        Description = "Refunding a Chess Board",
        Amount = new CreateRefundAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        ExternalReference = new CreateRefundExternalReferenceRequest() {
            Type = "acquirer-reference",
            Id = "123456789012345",
        },
        ReverseRouting = false,
        RoutingReversals = new List<RoutingReversalRequest>() {
            new RoutingReversalRequest() {
                Amount = new RoutingReversalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Source = new SourceRequest() {
                    Type = "organization",
                    OrganizationId = "org_1234567",
                },
            },
        },
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 | Example                                                                     |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `PaymentId`                                                                 | *string*                                                                    | :heavy_check_mark:                                                          | Provide the ID of the related payment.                                      | tr_5B8cwPMGnU                                                               |
| `RequestBody`                                                               | [CreateRefundRequestBody](../../Models/Requests/CreateRefundRequestBody.md) | :heavy_minus_sign:                                                          | N/A                                                                         |                                                                             |

### Response

**[CreateRefundResponse](../../Models/Requests/CreateRefundResponse.md)**

### Errors

| Error Type                                                              | Status Code                                                             | Content Type                                                            |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| MollieApi.Models.Errors.CreateRefundNotFoundHalJSONException            | 404                                                                     | application/hal+json                                                    |
| MollieApi.Models.Errors.ConflictHalJSONException                        | 409                                                                     | application/hal+json                                                    |
| MollieApi.Models.Errors.CreateRefundUnprocessableEntityHalJSONException | 422                                                                     | application/hal+json                                                    |
| MollieApi.Models.Errors.APIException                                    | 4XX, 5XX                                                                | \*/\*                                                                   |

## List

Retrieve a list of all refunds created for a specific payment.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListRefundsRequest req = new ListRefundsRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "re_5B8cwPMGnU",
    Include = ListRefundsInclude.Payment,
    Testmode = false,
};

var res = await sdk.Refunds.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [ListRefundsRequest](../../Models/Requests/ListRefundsRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[ListRefundsResponse](../../Models/Requests/ListRefundsResponse.md)**

### Errors

| Error Type                                                    | Status Code                                                   | Content Type                                                  |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| MollieApi.Models.Errors.ListRefundsBadRequestHalJSONException | 400                                                           | application/hal+json                                          |
| MollieApi.Models.Errors.ListRefundsNotFoundHalJSONException   | 404                                                           | application/hal+json                                          |
| MollieApi.Models.Errors.APIException                          | 4XX, 5XX                                                      | \*/\*                                                         |

## Get

Retrieve a single payment refund by its ID and the ID of its parent payment.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Refunds.GetAsync(
    paymentId: "tr_5B8cwPMGnU",
    refundId: "re_5B8cwPMGnU",
    include: GetRefundInclude.Payment,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment.                                                                                                                                                                                                                                                                                                                                                 | tr_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `RefundId`                                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related refund.                                                                                                                                                                                                                                                                                                                                                  | re_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `Include`                                                                                                                                                                                                                                                                                                                                                                              | [GetRefundInclude](../../Models/Requests/GetRefundInclude.md)                                                                                                                                                                                                                                                                                                                          | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | This endpoint allows you to include additional information via the `include` query string parameter.                                                                                                                                                                                                                                                                                   | payment                                                                                                                                                                                                                                                                                                                                                                                |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetRefundResponse](../../Models/Requests/GetRefundResponse.md)**

### Errors

| Error Type                                        | Status Code                                       | Content Type                                      |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| MollieApi.Models.Errors.GetRefundHalJSONException | 404                                               | application/hal+json                              |
| MollieApi.Models.Errors.APIException              | 4XX, 5XX                                          | \*/\*                                             |

## Cancel

Refunds will be executed with a delay of two hours. Until that time, refunds may be canceled manually via the Mollie Dashboard, or by using this endpoint.

A refund can only be canceled while its `status` field is either `queued` or `pending`. See the [Get refund endpoint](get-refund) for more information.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Refunds.CancelAsync(
    paymentId: "tr_5B8cwPMGnU",
    refundId: "re_5B8cwPMGnU",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment.                                                                                                                                                                                                                                                                                                                                                 | tr_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `RefundId`                                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related refund.                                                                                                                                                                                                                                                                                                                                                  | re_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[CancelRefundResponse](../../Models/Requests/CancelRefundResponse.md)**

### Errors

| Error Type                                           | Status Code                                          | Content Type                                         |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| MollieApi.Models.Errors.CancelRefundHalJSONException | 404                                                  | application/hal+json                                 |
| MollieApi.Models.Errors.APIException                 | 4XX, 5XX                                             | \*/\*                                                |

## CreateOrder

When using the Orders API, refunds should be made for a specific order.

If you want to refund arbitrary amounts, however, you can also use the [Create payment refund endpoint](create-refund) by creating a refund on the payment itself.

If an order line is still in the `authorized` state, it cannot be refunded. You should cancel it instead. Order lines that are `paid`, `shipping` or `completed` can be refunded.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Refunds.CreateOrderAsync(
    orderId: "ord_5B8cwPMGnU",
    requestBody: new CreateOrderRefundRequestBody() {
        Description = "Refunding a Chess Board",
        Amount = new CreateOrderRefundAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        ExternalReference = new CreateOrderRefundExternalReferenceRequest() {
            Type = "acquirer-reference",
            Id = "123456789012345",
        },
        Testmode = false,
        Lines = new List<LineInput>() {
            new LineInput() {
                Id = "odl_5B8cwPMGnU",
                Name = "Chess Board",
                Sku = "5702016116977",
                Type = TypeRequest.Physical,
                Status = StatusRequest.Created,
                IsCancelable = false,
                Quantity = 1,
                QuantityShipped = 0,
                AmountShipped = new AmountShippedRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                QuantityRefunded = 0,
                AmountRefunded = new AmountRefundedRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                QuantityCanceled = 0,
                AmountCanceled = new AmountCanceledRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Amount = new CreateOrderRefundLineAmount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                ShippableQuantity = 0,
                RefundableQuantity = 0,
                CancelableQuantity = 0,
                VatRate = "21.00",
                CreatedAt = "2025-03-28T16:42:12+00:00",
            },
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `OrderId`                                                                             | *string*                                                                              | :heavy_check_mark:                                                                    | Provide the ID of the related order.                                                  | ord_5B8cwPMGnU                                                                        |
| `RequestBody`                                                                         | [CreateOrderRefundRequestBody](../../Models/Requests/CreateOrderRefundRequestBody.md) | :heavy_minus_sign:                                                                    | N/A                                                                                   |                                                                                       |

### Response

**[CreateOrderRefundResponse](../../Models/Requests/CreateOrderRefundResponse.md)**

### Errors

| Error Type                                                                   | Status Code                                                                  | Content Type                                                                 |
| ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- |
| MollieApi.Models.Errors.CreateOrderRefundNotFoundHalJSONException            | 404                                                                          | application/hal+json                                                         |
| MollieApi.Models.Errors.CreateOrderRefundUnprocessableEntityHalJSONException | 422                                                                          | application/hal+json                                                         |
| MollieApi.Models.Errors.APIException                                         | 4XX, 5XX                                                                     | \*/\*                                                                        |

## ListForOrder

Retrieve a list of all refunds created for a specific order.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListOrderRefundsRequest req = new ListOrderRefundsRequest() {
    OrderId = "ord_5B8cwPMGnU",
    From = "re_4qqhO89gsT",
    Include = "payment",
    Testmode = false,
};

var res = await sdk.Refunds.ListForOrderAsync(req);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [ListOrderRefundsRequest](../../Models/Requests/ListOrderRefundsRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[ListOrderRefundsResponse](../../Models/Requests/ListOrderRefundsResponse.md)**

### Errors

| Error Type                                               | Status Code                                              | Content Type                                             |
| -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- |
| MollieApi.Models.Errors.ListOrderRefundsHalJSONException | 400                                                      | application/hal+json                                     |
| MollieApi.Models.Errors.APIException                     | 4XX, 5XX                                                 | \*/\*                                                    |

## All

Retrieve a list of all of your refunds.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **refunds.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListAllRefundsRequest req = new ListAllRefundsRequest() {
    From = "re_5B8cwPMGnU",
    Sort = "desc",
    Embed = ListAllRefundsEmbed.Payment,
    ProfileId = "pfl_5B8cwPMGnU",
    Testmode = false,
};

var res = await sdk.Refunds.AllAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [ListAllRefundsRequest](../../Models/Requests/ListAllRefundsRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[ListAllRefundsResponse](../../Models/Requests/ListAllRefundsResponse.md)**

### Errors

| Error Type                                             | Status Code                                            | Content Type                                           |
| ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ |
| MollieApi.Models.Errors.ListAllRefundsHalJSONException | 400                                                    | application/hal+json                                   |
| MollieApi.Models.Errors.APIException                   | 4XX, 5XX                                               | \*/\*                                                  |