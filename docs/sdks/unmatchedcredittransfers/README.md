# UnmatchedCreditTransfers

## Overview

### Available Operations

* [List](#list) - List unmatched credit transfers
* [Get](#get) - Get unmatched credit transfer
* [Match](#match) - Match unmatched credit transfer
* [Return](#return) - Return unmatched credit transfer

## List

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change.

Retrieves a list of unmatched credit transfers for the profile.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-unmatched-credit-transfers" method="get" path="/v2/unmatched-credit-transfers" example="list-unmatched-credit-transfers-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListUnmatchedCreditTransfersResponse? res = await sdk.UnmatchedCreditTransfers.ListAsync(
    limit: 50,
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                                                                      | Type                                                                                                                           | Required                                                                                                                       | Description                                                                                                                    | Example                                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| `From`                                                                                                                         | *string*                                                                                                                       | :heavy_minus_sign:                                                                                                             | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the<br/>result set. |                                                                                                                                |
| `Limit`                                                                                                                        | *long*                                                                                                                         | :heavy_minus_sign:                                                                                                             | The maximum number of items to return. Defaults to 50 items.                                                                   | 50                                                                                                                             |
| `IdempotencyKey`                                                                                                               | *string*                                                                                                                       | :heavy_minus_sign:                                                                                                             | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                               | 123e4567-e89b-12d3-a456-426                                                                                                    |

### Response

**[ListUnmatchedCreditTransfersResponse](../../Models/Requests/ListUnmatchedCreditTransfersResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change.

Retrieves a single unmatched credit transfer by its identifier.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-unmatched-credit-transfer" method="get" path="/v2/unmatched-credit-transfers/{unmatchedCreditTransferId}" example="get-unmatched-credit-transfer-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.UnmatchedCreditTransfers.GetAsync(
    unmatchedCreditTransferId: "uct_abcDEFghij123456789",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `UnmatchedCreditTransferId`                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related unmatched credit transfer.                         | uct_abcDEFghij123456789                                                          |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetUnmatchedCreditTransferResponse](../../Models/Requests/GetUnmatchedCreditTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Match

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change.

Matches an unmatched credit transfer to one or more payments, settling the funds accordingly.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="match-unmatched-credit-transfer" method="post" path="/v2/unmatched-credit-transfers/{unmatchedCreditTransferId}/match" example="match-unmatched-credit-transfer-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.UnmatchedCreditTransfers.MatchAsync(
    unmatchedCreditTransferId: "uct_abcDEFghij123456789",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    unmatchedCreditTransferMatchRequest: new UnmatchedCreditTransferMatchRequest() {
        PaymentIds = new List<string>() {
            "tr_5B8cwPMGnU",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           | Example                                                                                               |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `UnmatchedCreditTransferId`                                                                           | *string*                                                                                              | :heavy_check_mark:                                                                                    | Provide the ID of the related unmatched credit transfer.                                              | uct_abcDEFghij123456789                                                                               |
| `IdempotencyKey`                                                                                      | *string*                                                                                              | :heavy_minus_sign:                                                                                    | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                      | 123e4567-e89b-12d3-a456-426                                                                           |
| `UnmatchedCreditTransferMatchRequest`                                                                 | [UnmatchedCreditTransferMatchRequest](../../Models/Components/UnmatchedCreditTransferMatchRequest.md) | :heavy_minus_sign:                                                                                    | N/A                                                                                                   |                                                                                                       |

### Response

**[MatchUnmatchedCreditTransferResponse](../../Models/Requests/MatchUnmatchedCreditTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Return

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change.

Returns an unmatched credit transfer, sending the funds back to the original sender.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="return-unmatched-credit-transfer" method="post" path="/v2/unmatched-credit-transfers/{unmatchedCreditTransferId}/return" example="return-unmatched-credit-transfer-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.UnmatchedCreditTransfers.ReturnAsync(
    unmatchedCreditTransferId: "uct_abcDEFghij123456789",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `UnmatchedCreditTransferId`                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related unmatched credit transfer.                         | uct_abcDEFghij123456789                                                          |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[ReturnUnmatchedCreditTransferResponse](../../Models/Requests/ReturnUnmatchedCreditTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |