# DelayedRouting
(*DelayedRouting*)

## Overview

### Available Operations

* [Create](#create) - Create a delayed route
* [List](#list) - List payment routes

## Create

Create a route for a specific payment.
The routed amount is credited to the account of your customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="payment-create-route" method="post" path="/payments/{paymentId}/routes" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DelayedRouting.CreateAsync(
    paymentId: "tr_5B8cwPMGnU",
    routeCreateRequest: new RouteCreateRequest() {
        Id = "crt_dyARQ3JzCgtPDhU2Pbq3J",
        PaymentId = "tr_5B8cwPMGnU",
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Payment for Order #12345",
        Destination = new RouteCreateRequestDestination() {
            Type = RouteCreateRequestType.Organization,
            OrganizationId = "org_1234567",
        },
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PaymentId`                                                         | *string*                                                            | :heavy_check_mark:                                                  | Provide the ID of the related payment.                              | tr_5B8cwPMGnU                                                       |
| `RouteCreateRequest`                                                | [RouteCreateRequest](../../Models/Components/RouteCreateRequest.md) | :heavy_minus_sign:                                                  | N/A                                                                 |                                                                     |

### Response

**[PaymentCreateRouteResponse](../../Models/Requests/PaymentCreateRouteResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all routes created for a specific payment.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="payment-list-routes" method="get" path="/payments/{paymentId}/routes" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DelayedRouting.ListAsync(
    paymentId: "tr_5B8cwPMGnU",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment.                                                                                                                                                                                                                                                                                                                                                 | tr_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[PaymentListRoutesResponse](../../Models/Requests/PaymentListRoutesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |