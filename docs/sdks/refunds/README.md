# Refunds
(*Refunds*)

## Overview

### Available Operations

* [Create](#create) - Create payment refund
* [List](#list) - List payment refunds
* [Get](#get) - Get payment refund
* [Cancel](#cancel) - Cancel payment refund
* [All](#all) - List all refunds

## Create

Creates a refund for a specific payment. The refunded amount is credited to your customer usually either via a bank
transfer or by refunding the amount to your customer's credit card.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-refund" method="post" path="/payments/{paymentId}/refunds" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
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
        ExternalReference = new ExternalReferenceRequest() {
            Type = TypeAcquirerReferenceRequest.AcquirerReference,
            Id = "123456789012345",
        },
        ReverseRouting = false,
        RoutingReversals = new List<RoutingReversalRequest>() {
            new RoutingReversalRequest() {
                Amount = new RoutingReversalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Source = new CreateRefundSourceRequest() {
                    Type = RoutingReversalType.Organization,
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

| Error Type                                                           | Status Code                                                          | Content Type                                                         |
| -------------------------------------------------------------------- | -------------------------------------------------------------------- | -------------------------------------------------------------------- |
| Mollie.Models.Errors.CreateRefundNotFoundHalJSONException            | 404                                                                  | application/hal+json                                                 |
| Mollie.Models.Errors.ConflictHalJSONException                        | 409                                                                  | application/hal+json                                                 |
| Mollie.Models.Errors.CreateRefundUnprocessableEntityHalJSONException | 422                                                                  | application/hal+json                                                 |
| Mollie.Models.Errors.APIException                                    | 4XX, 5XX                                                             | \*/\*                                                                |

## List

Retrieve a list of all refunds created for a specific payment.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-refunds" method="get" path="/payments/{paymentId}/refunds" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListRefundsRequest req = new ListRefundsRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "re_5B8cwPMGnU",
    Embed = ListRefundsEmbed.Payment,
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

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| Mollie.Models.Errors.ListRefundsBadRequestHalJSONException | 400                                                        | application/hal+json                                       |
| Mollie.Models.Errors.ListRefundsNotFoundHalJSONException   | 404                                                        | application/hal+json                                       |
| Mollie.Models.Errors.APIException                          | 4XX, 5XX                                                   | \*/\*                                                      |

## Get

Retrieve a single payment refund by its ID and the ID of its parent payment.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-refund" method="get" path="/payments/{paymentId}/refunds/{refundId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Refunds.GetAsync(
    paymentId: "tr_5B8cwPMGnU",
    refundId: "re_5B8cwPMGnU",
    embed: GetRefundEmbed.Payment,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment.                                                                                                                                                                                                                                                                                                                                                 | tr_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `RefundId`                                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related refund.                                                                                                                                                                                                                                                                                                                                                  | re_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `Embed`                                                                                                                                                                                                                                                                                                                                                                                | [GetRefundEmbed](../../Models/Requests/GetRefundEmbed.md)                                                                                                                                                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | This endpoint allows embedding related API items by appending the following values via the `embed` query string<br/>parameter.                                                                                                                                                                                                                                                         | payment                                                                                                                                                                                                                                                                                                                                                                                |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetRefundResponse](../../Models/Requests/GetRefundResponse.md)**

### Errors

| Error Type                                     | Status Code                                    | Content Type                                   |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| Mollie.Models.Errors.GetRefundHalJSONException | 404                                            | application/hal+json                           |
| Mollie.Models.Errors.APIException              | 4XX, 5XX                                       | \*/\*                                          |

## Cancel

Refunds will be executed with a delay of two hours. Until that time, refunds may be canceled manually via the
Mollie Dashboard, or by using this endpoint.

A refund can only be canceled while its `status` field is either `queued` or `pending`. See the
[Get refund endpoint](get-refund) for more information.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-refund" method="delete" path="/payments/{paymentId}/refunds/{refundId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

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
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[CancelRefundResponse](../../Models/Requests/CancelRefundResponse.md)**

### Errors

| Error Type                                        | Status Code                                       | Content Type                                      |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| Mollie.Models.Errors.CancelRefundHalJSONException | 404                                               | application/hal+json                              |
| Mollie.Models.Errors.APIException                 | 4XX, 5XX                                          | \*/\*                                             |

## All

Retrieve a list of all of your refunds.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-all-refunds" method="get" path="/refunds" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListAllRefundsRequest req = new ListAllRefundsRequest() {
    From = "re_5B8cwPMGnU",
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

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| Mollie.Models.Errors.ListAllRefundsHalJSONException | 400                                                 | application/hal+json                                |
| Mollie.Models.Errors.APIException                   | 4XX, 5XX                                            | \*/\*                                               |