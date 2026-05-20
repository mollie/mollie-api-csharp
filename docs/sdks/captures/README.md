# Captures

## Overview

### Available Operations

* [Create](#create) - Create capture
* [List](#list) - List captures
* [Get](#get) - Get capture

## Create

Capture an *authorized* payment.

Some payment methods allow you to first collect a customer's authorization,
and capture the amount at a later point.

By default, Mollie captures payments automatically. If however you
configured your payment with `captureMode: manual`, you can capture the payment using this endpoint after
having collected the customer's authorization.

### Example Usage: get-capture-200-1

<!-- UsageSnippet language="csharp" operationID="create-capture" method="post" path="/v2/payments/{paymentId}/captures" example="get-capture-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Captures.CreateAsync(
    paymentId: "tr_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    entityCapture: new EntityCapture() {
        Description = "Capture for cart #12345",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
    }
);

// handle response
```
### Example Usage: get-capture-200-2

<!-- UsageSnippet language="csharp" operationID="create-capture" method="post" path="/v2/payments/{paymentId}/captures" example="get-capture-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Captures.CreateAsync(
    paymentId: "tr_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    entityCapture: new EntityCapture() {
        Description = "Capture for cart #12345",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `PaymentId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related payment.                                           | tr_5B8cwPMGnU                                                                    |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `EntityCapture`                                                                  | [EntityCapture](../../Models/Components/EntityCapture.md)                        | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[CreateCaptureResponse](../../Models/Requests/CreateCaptureResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all captures created for a specific payment.

The results are paginated.

### Example Usage: list-captures-200-1

<!-- UsageSnippet language="csharp" operationID="list-captures" method="get" path="/v2/payments/{paymentId}/captures" example="list-captures-200-1" -->
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

ListCapturesRequest req = new ListCapturesRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListCapturesResponse? res = await sdk.Captures.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-captures-200-2

<!-- UsageSnippet language="csharp" operationID="list-captures" method="get" path="/v2/payments/{paymentId}/captures" example="list-captures-200-2" -->
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

ListCapturesRequest req = new ListCapturesRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListCapturesResponse? res = await sdk.Captures.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListCapturesRequest](../../Models/Requests/ListCapturesRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListCapturesResponse](../../Models/Requests/ListCapturesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single payment capture by its ID and the ID of its parent
payment.

### Example Usage: get-capture-200-1

<!-- UsageSnippet language="csharp" operationID="get-capture" method="get" path="/v2/payments/{paymentId}/captures/{captureId}" example="get-capture-200-1" -->
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

GetCaptureRequest req = new GetCaptureRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    CaptureId = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Captures.GetAsync(req);

// handle response
```
### Example Usage: get-capture-200-2

<!-- UsageSnippet language="csharp" operationID="get-capture" method="get" path="/v2/payments/{paymentId}/captures/{captureId}" example="get-capture-200-2" -->
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

GetCaptureRequest req = new GetCaptureRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    CaptureId = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Captures.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [GetCaptureRequest](../../Models/Requests/GetCaptureRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[GetCaptureResponse](../../Models/Requests/GetCaptureResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |