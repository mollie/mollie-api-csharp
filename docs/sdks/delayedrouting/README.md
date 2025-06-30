# DelayedRouting
(*DelayedRouting*)

## Overview

### Available Operations

* [Create](#create) - Create a delayed route
* [List](#list) - List payment routes

## Create

Create a route for a specific payment. The routed amount is credited to the account of your customer.

> 🔑 Access with
>
> [API key](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DelayedRouting.CreateAsync(
    paymentId: "tr_5B8cwPMGnU",
    requestBody: new PaymentCreateRouteRequestBody() {
        Amount = new PaymentCreateRouteAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Payment for Order #12345",
        Destination = new PaymentCreateRouteDestinationRequest() {
            Type = "organization",
            OrganizationId = "org_1234567",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `PaymentId`                                                                             | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the related payment.                                                  | tr_5B8cwPMGnU                                                                           |
| `RequestBody`                                                                           | [PaymentCreateRouteRequestBody](../../Models/Requests/PaymentCreateRouteRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[PaymentCreateRouteResponse](../../Models/Requests/PaymentCreateRouteResponse.md)**

### Errors

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| MollieApi.Models.Errors.PaymentCreateRouteHalJSONException | 404                                                        | application/hal+json                                       |
| MollieApi.Models.Errors.APIException                       | 4XX, 5XX                                                   | \*/\*                                                      |

## List

Retrieve a list of all routes created for a specific payment.

> 🔑 Access with
>
> [API key](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DelayedRouting.ListAsync(paymentId: "tr_5B8cwPMGnU");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            | Example                                |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `PaymentId`                            | *string*                               | :heavy_check_mark:                     | Provide the ID of the related payment. | tr_5B8cwPMGnU                          |

### Response

**[PaymentListRoutesResponse](../../Models/Requests/PaymentListRoutesResponse.md)**

### Errors

| Error Type                                                | Status Code                                               | Content Type                                              |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| MollieApi.Models.Errors.PaymentListRoutesHalJSONException | 404                                                       | application/hal+json                                      |
| MollieApi.Models.Errors.APIException                      | 4XX, 5XX                                                  | \*/\*                                                     |