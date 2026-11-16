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

Creates a draft transfer. The draft transfer immediately enters `pending-review` and appears in the
initiator's queue in Mollie Apps. It carries no legal weight and moves no funds until a human initiator
approves it there.

### Test mode

Creating a draft transfer always returns a synthetic draft in `pending-review` status, using synthetic data,
same as in live mode. No real funds move and nothing is sent to Mollie Apps.

Editing a draft transfer after creation is not supported via the API. Instead, depending on the amount, you
can simulate different outcomes for the initiator's decision at creation time:

| Amount  | Simulated outcome                                    | Webhook sequence                                                                                  |
|---------|-------------------------------------------------------|----------------------------------------------------------------------------------------------------|
| `13.00` | Declined by the initiator, with a free-text reason     | `business-account-draft-transfer.created` → `business-account-draft-transfer.declined`             |
| `14.00` | Approved                                               | `business-account-draft-transfer.created` → `business-account-draft-transfer.approved`             |
| Other   | Default behavior (pending review)                      | `business-account-draft-transfer.created`                                                          |

The webhooks fire asynchronously, with a short delay between them to mimic real timing. [Get](get-draft-transfer)
and [list](list-draft-transfers) reflect the simulated outcome once it lands.

Cancelling (via `DELETE`) is unaffected by the amount: it always transitions the draft to `declined` with
`statusReason.code` set to `deleted-by-creator`, the same as in live mode.

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
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
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
        ScheduledExecutionDate = LocalDate.FromDateTime(System.DateTime.Parse("2025-03-01")),
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |
| `CreateDraftTransferRequest`                                                                                                                                                            | [Models.Components.CreateDraftTransferRequest](../../Models/Components/CreateDraftTransferRequest.md)                                                                                   | :heavy_minus_sign:                                                                                                                                                                      | N/A                                                                                                                                                                                     |                                                                                                                                                                                         |

### Response

**[CreateDraftTransferResponse](../../Models/Requests/CreateDraftTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieves a list of draft transfers created via this API for the organization.

The results are paginated.

In test mode, this returns synthetic draft transfers only, not your real data.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-draft-transfers" method="get" path="/v2/business-accounts/draft-transfers" example="list-draft-transfers-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListDraftTransfersRequest req = new ListDraftTransfersRequest() {
    Limit = 50,
    Status = DraftTransferStatus.Approved,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
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

In test mode, this returns synthetic data only, not your real draft transfer. See [Create draft
transfer](create-draft-transfer) for how to simulate `approved` and `declined` outcomes.

### Example Usage: approved-draft-transfer

<!-- UsageSnippet language="csharp" operationID="get-draft-transfer" method="get" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="approved-draft-transfer" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetDraftTransferRequest req = new GetDraftTransferRequest() {
    DraftTransferId = "badrt_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.DraftTransfers.GetAsync(req);

// handle response
```
### Example Usage: declined-by-initiator-draft-transfer

<!-- UsageSnippet language="csharp" operationID="get-draft-transfer" method="get" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="declined-by-initiator-draft-transfer" -->
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

GetDraftTransferRequest req = new GetDraftTransferRequest() {
    DraftTransferId = "badrt_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.DraftTransfers.GetAsync(req);

// handle response
```
### Example Usage: get-draft-transfer-200

<!-- UsageSnippet language="csharp" operationID="get-draft-transfer" method="get" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="get-draft-transfer-200" -->
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

GetDraftTransferRequest req = new GetDraftTransferRequest() {
    DraftTransferId = "badrt_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.DraftTransfers.GetAsync(req);

// handle response
```
### Example Usage: initiated-draft-transfer

<!-- UsageSnippet language="csharp" operationID="get-draft-transfer" method="get" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="initiated-draft-transfer" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetDraftTransferRequest req = new GetDraftTransferRequest() {
    DraftTransferId = "badrt_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.DraftTransfers.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [GetDraftTransferRequest](../../Models/Requests/GetDraftTransferRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

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
`statusReason.code` set to `deleted-by-creator`.

Only draft transfers created via this API, and still in `pending-review`, can be cancelled this way. A
`422` is returned if the initiator has already started approving it.

In test mode, this always returns a synthetic `declined` draft. See [Create draft
transfer](create-draft-transfer) for how to simulate `approved` and `declined` outcomes.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-draft-transfer" method="delete" path="/v2/business-accounts/draft-transfers/{draftTransferId}" example="cancel-draft-transfer-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

CancelDraftTransferRequest req = new CancelDraftTransferRequest() {
    DraftTransferId = "badrt_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new CancelDraftTransferRequestBody() {
        Testmode = false,
    },
};

var res = await sdk.DraftTransfers.CancelAsync(req);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `request`                                                                         | [CancelDraftTransferRequest](../../Models/Requests/CancelDraftTransferRequest.md) | :heavy_check_mark:                                                                | The request object to use for the request.                                        |

### Response

**[CancelDraftTransferResponse](../../Models/Requests/CancelDraftTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |