# Settlements

## Overview

### Available Operations

* [List](#list) - List settlements
* [Get](#get) - Get settlement
* [GetOpen](#getopen) - Get open settlement
* [GetNext](#getnext) - Get next settlement
* [ListPayments](#listpayments) - List settlement payments
* [ListCaptures](#listcaptures) - List settlement captures
* [ListRefunds](#listrefunds) - List settlement refunds
* [ListChargebacks](#listchargebacks) - List settlement chargebacks

## List

Retrieve a list of all your settlements.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-settlements" method="get" path="/v2/settlements" example="list-settlements-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementsRequest req = new ListSettlementsRequest() {
    From = "stl_jDk30akdN",
    Limit = 50,
    BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Year = "2025",
    Month = "1",
    Currencies = Currencies.Eur,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementsResponse? res = await sdk.Settlements.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [ListSettlementsRequest](../../Models/Requests/ListSettlementsRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[ListSettlementsResponse](../../Models/Requests/ListSettlementsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single settlement by its ID.

To lookup settlements by their bank reference, replace the ID in the URL by
a reference. For example: `1234567.2404.03`.

A settlement represents a transfer of your balance funds to your external bank account.

Settlements will typically include a report that details what balance transactions have taken place between this
settlement and the previous one.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the
[balance transactions](list-balance-transactions) endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-settlement" method="get" path="/v2/settlements/{settlementId}" example="get-settlement-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetAsync(
    settlementId: "stl_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `SettlementId`                                                                   | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related settlement.                                        | stl_5B8cwPMGnU                                                                   |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetSettlementResponse](../../Models/Requests/GetSettlementResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## GetOpen

Retrieve the details of the open balance of the organization. This will return a settlement object representing your
organization's balance.

For a complete reference of the settlement object, refer to the [Get settlement endpoint](get-settlement)
documentation.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the
[balance transactions](list-balance-transactions) endpoint.

### Example Usage: get-open-settlement-200-1

<!-- UsageSnippet language="csharp" operationID="get-open-settlement" method="get" path="/v2/settlements/open" example="get-open-settlement-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetOpenAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```
### Example Usage: get-settlement-200-1

<!-- UsageSnippet language="csharp" operationID="get-open-settlement" method="get" path="/v2/settlements/open" example="get-settlement-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetOpenAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetOpenSettlementResponse](../../Models/Requests/GetOpenSettlementResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 429                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## GetNext

Retrieve the details of the current settlement, that has not yet been paid out.

For a complete reference of the settlement object, refer to the [Get settlement endpoint](get-settlement)
documentation.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the
[balance transactions](list-balance-transactions) endpoint.

### Example Usage: get-next-settlement-200-1

<!-- UsageSnippet language="csharp" operationID="get-next-settlement" method="get" path="/v2/settlements/next" example="get-next-settlement-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetNextAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```
### Example Usage: get-settlement-200-1

<!-- UsageSnippet language="csharp" operationID="get-next-settlement" method="get" path="/v2/settlements/next" example="get-settlement-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetNextAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetNextSettlementResponse](../../Models/Requests/GetNextSettlementResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 429                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListPayments

Retrieve all payments included in the given settlement.

The response is in the same format as the response of the [List payments endpoint](list-payments).

For capture-based payment methods such as Klarna, the payments are not listed here. Refer to the
[List captures endpoint](list-captures) endpoint instead.

### Example Usage: list-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-payments" method="get" path="/v2/settlements/{settlementId}/payments" example="list-payments-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementPaymentsRequest req = new ListSettlementPaymentsRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementPaymentsResponse? res = await sdk.Settlements.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-2

<!-- UsageSnippet language="csharp" operationID="list-settlement-payments" method="get" path="/v2/settlements/{settlementId}/payments" example="list-payments-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementPaymentsRequest req = new ListSettlementPaymentsRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementPaymentsResponse? res = await sdk.Settlements.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-3

<!-- UsageSnippet language="csharp" operationID="list-settlement-payments" method="get" path="/v2/settlements/{settlementId}/payments" example="list-payments-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementPaymentsRequest req = new ListSettlementPaymentsRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementPaymentsResponse? res = await sdk.Settlements.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-settlement-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-payments" method="get" path="/v2/settlements/{settlementId}/payments" example="list-settlement-payments-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementPaymentsRequest req = new ListSettlementPaymentsRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementPaymentsResponse? res = await sdk.Settlements.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [ListSettlementPaymentsRequest](../../Models/Requests/ListSettlementPaymentsRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[ListSettlementPaymentsResponse](../../Models/Requests/ListSettlementPaymentsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListCaptures

Retrieve all captures included in the given settlement.

The response is in the same format as the response of the [List captures endpoint](list-captures).

### Example Usage: list-captures-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-captures" method="get" path="/v2/settlements/{settlementId}/captures" example="list-captures-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementCapturesRequest req = new ListSettlementCapturesRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementCapturesResponse? res = await sdk.Settlements.ListCapturesAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-captures-200-2

<!-- UsageSnippet language="csharp" operationID="list-settlement-captures" method="get" path="/v2/settlements/{settlementId}/captures" example="list-captures-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementCapturesRequest req = new ListSettlementCapturesRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementCapturesResponse? res = await sdk.Settlements.ListCapturesAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-settlement-captures-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-captures" method="get" path="/v2/settlements/{settlementId}/captures" example="list-settlement-captures-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementCapturesRequest req = new ListSettlementCapturesRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementCapturesResponse? res = await sdk.Settlements.ListCapturesAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [ListSettlementCapturesRequest](../../Models/Requests/ListSettlementCapturesRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[ListSettlementCapturesResponse](../../Models/Requests/ListSettlementCapturesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListRefunds

Retrieve all refunds 'deducted' from the given settlement.

The response is in the same format as the response of the [List refunds endpoint](list-refunds).

### Example Usage: list-refunds-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-refunds" method="get" path="/v2/settlements/{settlementId}/refunds" example="list-refunds-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementRefundsRequest req = new ListSettlementRefundsRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "re_5B8cwPMGnU",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementRefundsResponse? res = await sdk.Settlements.ListRefundsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-settlement-refunds-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-refunds" method="get" path="/v2/settlements/{settlementId}/refunds" example="list-settlement-refunds-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementRefundsRequest req = new ListSettlementRefundsRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "re_5B8cwPMGnU",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementRefundsResponse? res = await sdk.Settlements.ListRefundsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [ListSettlementRefundsRequest](../../Models/Requests/ListSettlementRefundsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[ListSettlementRefundsResponse](../../Models/Requests/ListSettlementRefundsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListChargebacks

Retrieve all chargebacks 'deducted' from the given settlement.

The response is in the same format as the response of the [List chargebacks endpoint](list-chargebacks).

### Example Usage: list-chargeback-200-1

<!-- UsageSnippet language="csharp" operationID="list-settlement-chargebacks" method="get" path="/v2/settlements/{settlementId}/chargebacks" example="list-chargeback-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementChargebacksRequest req = new ListSettlementChargebacksRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementChargebacksResponse? res = await sdk.Settlements.ListChargebacksAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-chargeback-200-2

<!-- UsageSnippet language="csharp" operationID="list-settlement-chargebacks" method="get" path="/v2/settlements/{settlementId}/chargebacks" example="list-chargeback-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementChargebacksRequest req = new ListSettlementChargebacksRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementChargebacksResponse? res = await sdk.Settlements.ListChargebacksAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-chargeback-200-3

<!-- UsageSnippet language="csharp" operationID="list-settlement-chargebacks" method="get" path="/v2/settlements/{settlementId}/chargebacks" example="list-chargeback-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSettlementChargebacksRequest req = new ListSettlementChargebacksRequest() {
    SettlementId = "stl_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Limit = 50,
    Embed = "payment",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListSettlementChargebacksResponse? res = await sdk.Settlements.ListChargebacksAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `request`                                                                                     | [ListSettlementChargebacksRequest](../../Models/Requests/ListSettlementChargebacksRequest.md) | :heavy_check_mark:                                                                            | The request object to use for the request.                                                    |

### Response

**[ListSettlementChargebacksResponse](../../Models/Requests/ListSettlementChargebacksResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |