# DraftTransfers

## Overview

### Available Operations

* [Create](#create) - Create draft transfer
* [List](#list) - List draft transfers
* [Get](#get) - Get draft transfer
* [Cancel](#cancel) - Cancel draft transfer

## Create

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Creates a draft transfer. The draft transfer immediately enters `awaiting-initiation` and appears in the
initiator's queue in Mollie Apps. It carries no legal weight and moves no funds until a human initiator
approves it there.

### Test mode

| Action | Test-mode behavior |
|---|---|
| Create | Always returns a synthetic draft in `awaiting-initiation`, regardless of most input values |
| Get / List | Always returns synthetic `awaiting-initiation` draft(s), not your real data |
| Cancel | Always returns a synthetic `declined` draft |

There is currently no way to synthesize an `initiated` draft via test mode alone. Initiation only happens when
a real initiator approves in Mollie Apps, which test mode doesn't touch.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-draft-transfer" method="post" path="/v2/business-accounts/draft-transfers" example="create-draft-transfer-201" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using NodaTime;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DraftTransfers.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    createDraftTransferRequest: new Mollie.Models.Components.CreateDraftTransferRequest() {
        DebtorIban = "NL55MLLE0123456789",
        Creditor = new DraftTransferParty() {
            FullName = "Jan Jansen",
            Account = new DraftTransferPartyAccount() {
                Iban = "NL02ABNA0123456789",
            },
        },
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Invoice 12345",
        ScheduledFor = LocalDate.FromDateTime(System.DateTime.Parse("2025-03-01")),
    }
);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           | Example                                                                                               |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                                      | *string*                                                                                              | :heavy_minus_sign:                                                                                    | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                      | 123e4567-e89b-12d3-a456-426                                                                           |
| `CreateDraftTransferRequest`                                                                          | [Models.Components.CreateDraftTransferRequest](../../Models/Components/CreateDraftTransferRequest.md) | :heavy_minus_sign:                                                                                    | N/A                                                                                                   |                                                                                                       |

### Response

**[CreateDraftTransferResponse](../../Models/Requests/CreateDraftTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieves a list of draft transfers for the organization including ones created in Mollie Apps, not just
ones created via this API.

The results are paginated.

In test mode, this always returns a synthetic `awaiting-initiation` list. See [Create draft
transfer](create-draft-transfer) for full test-mode behavior.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-draft-transfers" method="get" path="/v2/business-accounts/draft-transfers" example="list-draft-transfers-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListDraftTransfersRequest req = new ListDraftTransfersRequest() {
    Limit = 50,
    Status = DraftTransferStatus.AwaitingInitiation,
    Source = DraftTransferSource.Api,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListDraftTransfersResponse? res = await sdk.DraftTransfers.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [ListDraftTransfersRequest](../../Models/Requests/ListDraftTransfersRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[ListDraftTransfersResponse](../../Models/Requests/ListDraftTransfersResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieves a single draft transfer by its identifier.

Only draft transfers created via this API are visible via this endpoint. Draft transfers created in Mollie
Apps return a `404`, even though they appear in the [list endpoint](list-draft-transfers).

In test mode, this always returns a synthetic `awaiting-initiation` draft. See [Create draft
transfer](create-draft-transfer) for full test-mode behavior.

### Example Usage: get-draft-transfer-200

<!-- UsageSnippet language="csharp" operationID="get-draft-transfer" method="get" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="get-draft-transfer-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DraftTransfers.GetAsync(
    draftTransferId: "badrt_87GByBuj4UCcUTEbs6aGJ",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: initiated-draft-transfer

<!-- UsageSnippet language="csharp" operationID="get-draft-transfer" method="get" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="initiated-draft-transfer" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DraftTransfers.GetAsync(
    draftTransferId: "badrt_87GByBuj4UCcUTEbs6aGJ",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `DraftTransferId`                                                                | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related draft transfer.                                    | badrt_87GByBuj4UCcUTEbs6aGJ                                                      |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetDraftTransferResponse](../../Models/Requests/GetDraftTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Cancel

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Cancels a draft transfer created via this API. Transitions the draft transfer to `declined` with
`statusReason` set to `"Declined by creator"`.

Only draft transfers created via this API, and still in `awaiting-initiation`, can be cancelled this way. A
`422` is returned if the initiator has already started approving it.

In test mode, this always returns a synthetic `declined` draft. See [Create draft
transfer](create-draft-transfer) for full test-mode behavior.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-draft-transfer" method="delete" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="cancel-draft-transfer-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.DraftTransfers.CancelAsync(
    draftTransferId: "badrt_87GByBuj4UCcUTEbs6aGJ",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `DraftTransferId`                                                                | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related draft transfer.                                    | badrt_87GByBuj4UCcUTEbs6aGJ                                                      |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[CancelDraftTransferResponse](../../Models/Requests/CancelDraftTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |