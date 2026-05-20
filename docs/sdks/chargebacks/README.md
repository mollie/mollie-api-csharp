# Chargebacks

## Overview

### Available Operations

* [List](#list) - List payment chargebacks
* [Get](#get) - Get payment chargeback
* [All](#all) - List all chargebacks

## List

Retrieve the chargebacks initiated for a specific payment.

The results are paginated.

### Example Usage: list-chargeback-200-1

<!-- UsageSnippet language="csharp" operationID="list-chargebacks" method="get" path="/v2/payments/{paymentId}/chargebacks" example="list-chargeback-200-1" -->
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

ListChargebacksRequest req = new ListChargebacksRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListChargebacksResponse? res = await sdk.Chargebacks.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-chargeback-200-2

<!-- UsageSnippet language="csharp" operationID="list-chargebacks" method="get" path="/v2/payments/{paymentId}/chargebacks" example="list-chargeback-200-2" -->
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

ListChargebacksRequest req = new ListChargebacksRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListChargebacksResponse? res = await sdk.Chargebacks.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-chargeback-200-3

<!-- UsageSnippet language="csharp" operationID="list-chargebacks" method="get" path="/v2/payments/{paymentId}/chargebacks" example="list-chargeback-200-3" -->
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

ListChargebacksRequest req = new ListChargebacksRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListChargebacksResponse? res = await sdk.Chargebacks.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [ListChargebacksRequest](../../Models/Requests/ListChargebacksRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[ListChargebacksResponse](../../Models/Requests/ListChargebacksResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single payment chargeback by its ID and the ID of its parent payment.

### Example Usage: get-chargeback-200-1

<!-- UsageSnippet language="csharp" operationID="get-chargeback" method="get" path="/v2/payments/{paymentId}/chargebacks/{chargebackId}" example="get-chargeback-200-1" -->
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

GetChargebackRequest req = new GetChargebackRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    ChargebackId = "chb_xFzwUN4ci8HAmSGUACS4J",
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Chargebacks.GetAsync(req);

// handle response
```
### Example Usage: get-chargeback-200-2

<!-- UsageSnippet language="csharp" operationID="get-chargeback" method="get" path="/v2/payments/{paymentId}/chargebacks/{chargebackId}" example="get-chargeback-200-2" -->
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

GetChargebackRequest req = new GetChargebackRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    ChargebackId = "chb_xFzwUN4ci8HAmSGUACS4J",
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Chargebacks.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [GetChargebackRequest](../../Models/Requests/GetChargebackRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[GetChargebackResponse](../../Models/Requests/GetChargebackResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## All

Retrieve all chargebacks initiated for all your payments.

The results are paginated.

### Example Usage: list-all-chargebacks-200-1

<!-- UsageSnippet language="csharp" operationID="list-all-chargebacks" method="get" path="/v2/chargebacks" example="list-all-chargebacks-200-1" -->
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

ListAllChargebacksRequest req = new ListAllChargebacksRequest() {
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListAllChargebacksResponse? res = await sdk.Chargebacks.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-all-chargebacks-200-2

<!-- UsageSnippet language="csharp" operationID="list-all-chargebacks" method="get" path="/v2/chargebacks" example="list-all-chargebacks-200-2" -->
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

ListAllChargebacksRequest req = new ListAllChargebacksRequest() {
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListAllChargebacksResponse? res = await sdk.Chargebacks.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-all-chargebacks-200-3

<!-- UsageSnippet language="csharp" operationID="list-all-chargebacks" method="get" path="/v2/chargebacks" example="list-all-chargebacks-200-3" -->
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

ListAllChargebacksRequest req = new ListAllChargebacksRequest() {
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListAllChargebacksResponse? res = await sdk.Chargebacks.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [ListAllChargebacksRequest](../../Models/Requests/ListAllChargebacksRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[ListAllChargebacksResponse](../../Models/Requests/ListAllChargebacksResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |