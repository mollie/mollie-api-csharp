# Transfers

## Overview

### Available Operations

* [Create](#create) - Create transfer
* [Get](#get) - Get transfer

## Create

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Create a SEPA Credit Transfer from your Mollie Business Account.

To initiate a transfer, you must provide the transfer scheme, the amount, the debtor IBAN (your Mollie Business
Account IBAN), and the creditor (recipient) details.

Each request must include an `Idempotency-Key` header to prevent duplicate transfers, and must be signed using the
`X-Client-Signature` and `X-Client-Signed-At` headers.

### Simulating transfer scenarios in test mode

In test mode, you can simulate various transfer scenarios by adjusting the transfer amount. This allows you to
mimic the typical status progression of a real-world transfer. Note that a transfer's progression will stop once
it reaches a final status: `blocked`, `failed`, `processed`, or `returned`.

| Amount  | Scenario                                            | Webhook sequence                                                                                                                                                   |
|---------|-----------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `11.00` | Transfer initiated, pending review by Mollie        | `business-account-transfer.requested` → `business-account-transfer.initiated` → `business-account-transfer.pending-review`                                         |
| `12.00` | Transfer initiated, blocked by Mollie               | `business-account-transfer.requested` → `business-account-transfer.initiated` → `business-account-transfer.pending-review` → `business-account-transfer.blocked`   |
| `13.00` | Transfer initiated, failed on scheme submission     | `business-account-transfer.requested` → `business-account-transfer.initiated` → `business-account-transfer.failed`                                                 |
| `14.00` | Transfer processed, then returned by receiving bank | `business-account-transfer.requested` → `business-account-transfer.initiated` → `business-account-transfer.processed` → `business-account-transfer.returned`       |
| Other   | Default: transfer is processed                      | `business-account-transfer.requested` → `business-account-transfer.initiated` → `business-account-transfer.processed`                                              |

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-transfer" method="post" path="/v2/business-accounts/transfers" example="create-transfer-201" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    XClientSignature = "<value>",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    IdempotencyKey = "aa84d3c0-1484-4f45-8a8d-4674a0147f3f",
    IdempotencyKey1 = "123e4567-e89b-12d3-a456-426",
    TransferRequest = new TransferRequest() {
        DebtorIban = "NL55MLLE0123456789",
        Creditor = new TransferParty() {
            FullName = "Jan Jansen",
            Account = new TransferPartyAccount() {
                Iban = "NL02ABNA0123456789",
            },
        },
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Invoice 12345",
        TransferScheme = new TransferScheme() {
            Type = TransferSchemeType.SepaCreditInst,
        },
        Testmode = false,
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [CreateTransferRequest](../../Models/Requests/CreateTransferRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[CreateTransferResponse](../../Models/Requests/CreateTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422                                | application/hal+json               |
| Mollie.Models.Errors.ErrorResponse | 503                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieve a single transfer object by its transfer ID. This allows you to check the current status
and details of a previously created transfer.

### Example Usage: get-transfer-200

<!-- UsageSnippet language="csharp" operationID="get-transfer" method="get" path="/v2/business-accounts/transfers/{businessAccountsTransferId}" example="get-transfer-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Transfers.GetAsync(
    businessAccountsTransferId: "batrf_87GByBuj4UCcUTEbs6aGJ",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: processed-transfer

<!-- UsageSnippet language="csharp" operationID="get-transfer" method="get" path="/v2/business-accounts/transfers/{businessAccountsTransferId}" example="processed-transfer" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Transfers.GetAsync(
    businessAccountsTransferId: "batrf_87GByBuj4UCcUTEbs6aGJ",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `BusinessAccountsTransferId`                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the related transfer.                                                                                                                                                                                                                                                                                                                                                  | batrf_87GByBuj4UCcUTEbs6aGJ                                                                                                                                                                                                                                                                                                                                                              |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

### Response

**[GetTransferResponse](../../Models/Requests/GetTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |