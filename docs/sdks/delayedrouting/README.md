# DelayedRouting

## Overview

### Available Operations

* [Create](#create) - Create a delayed route
* [List](#list) - List payment routes
* [Get](#get) - Get a delayed route

## Create

Create a route for a specific payment.
The routed amount is credited to the account of your customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="payment-create-route" method="post" path="/v2/payments/{paymentId}/routes" example="create-route-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

PaymentCreateRouteRequest req = new PaymentCreateRouteRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RouteCreateRequest = new RouteCreateRequest() {
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Destination = new RouteCreateRequestDestination() {
            Type = RouteDestinationType.Organization,
            OrganizationId = "org_1234567",
        },
        Description = "Payment for Order #12345",
    },
};

var res = await sdk.DelayedRouting.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [PaymentCreateRouteRequest](../../Models/Requests/PaymentCreateRouteRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[PaymentCreateRouteResponse](../../Models/Requests/PaymentCreateRouteResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all routes created for a specific payment.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="payment-list-routes" method="get" path="/v2/payments/{paymentId}/routes" example="list-routes-200-1" -->
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

PaymentListRoutesRequest req = new PaymentListRoutesRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.DelayedRouting.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [PaymentListRoutesRequest](../../Models/Requests/PaymentListRoutesRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[PaymentListRoutesResponse](../../Models/Requests/PaymentListRoutesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single route created for a specific payment.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="payment-get-route" method="get" path="/v2/payments/{paymentId}/routes/{routeId}" example="get-route-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

PaymentGetRouteRequest req = new PaymentGetRouteRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    RouteId = "crt_dyARQ3JzCgtPDhU2Pbq3J",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.DelayedRouting.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [PaymentGetRouteRequest](../../Models/Requests/PaymentGetRouteRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[PaymentGetRouteResponse](../../Models/Requests/PaymentGetRouteResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |