# BalanceTransfers

## Overview

### Available Operations

* [Create](#create) - Create a Connect balance transfer
* [List](#list) - List all Connect balance transfers
* [Get](#get) - Get a Connect balance transfer

## Create

This API endpoint allows you to create a balance transfer from your organization's balance to a connected organization's balance, or vice versa.
You can also create a balance transfer between two connected organizations.
To create a balance transfer, you must be authenticated as the source organization, and the destination organization must be a connected organization
that has authorized the `balance-transfers.write` scope for your organization.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-connect-balance-transfer" method="post" path="/connect/balance-transfers" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.BalanceTransfers.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    entityBalanceTransfer: new EntityBalanceTransfer() {
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Source = new EntityBalanceTransferParty() {
            Type = BalanceTransferPartyType.Organization,
            Id = "org_1234567",
            Description = "Invoice fee",
        },
        Destination = new EntityBalanceTransferParty() {
            Type = BalanceTransferPartyType.Organization,
            Id = "org_1234567",
            Description = "Invoice fee",
        },
        Description = "Invoice fee",
        Category = BalanceTransferCategory.InvoiceCollection,
        Metadata = new Dictionary<string, object>() {
            { "order_id", 12345 },
            { "customer_id", 9876 },
        },
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `EntityBalanceTransfer`                                                          | [EntityBalanceTransfer](../../Models/Components/EntityBalanceTransfer.md)        | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[CreateConnectBalanceTransferResponse](../../Models/Requests/CreateConnectBalanceTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Returns a paginated list of balance transfers associated with your organization. These may be a balance transfer that was received or sent from your balance, or a balance transfer that you initiated on behalf of your clients. If no balance transfers are available, the resulting array will be empty. This request should never throw an error.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-connect-balance-transfers" method="get" path="/connect/balance-transfers" -->
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

ListConnectBalanceTransfersRequest req = new ListConnectBalanceTransfersRequest() {
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.BalanceTransfers.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `request`                                                                                         | [ListConnectBalanceTransfersRequest](../../Models/Requests/ListConnectBalanceTransfersRequest.md) | :heavy_check_mark:                                                                                | The request object to use for the request.                                                        |

### Response

**[ListConnectBalanceTransfersResponse](../../Models/Requests/ListConnectBalanceTransfersResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single Connect balance transfer object by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-connect-balance-transfer" method="get" path="/connect/balance-transfers/{balanceTransferId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.BalanceTransfers.GetAsync(
    balanceTransferId: "cbtr_j8NvRAM2WNZtsykpLEX8J",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                               | Type                                                                                                                                                                    | Required                                                                                                                                                                | Description                                                                                                                                                             | Example                                                                                                                                                                 |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `BalanceTransferId`                                                                                                                                                     | *string*                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                      | Provide the ID of the related balance transfer.                                                                                                                         | cbtr_j8NvRAM2WNZtsykpLEX8J                                                                                                                                              |
| `Testmode`                                                                                                                                                              | *bool*                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                      | You can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                         |
| `IdempotencyKey`                                                                                                                                                        | *string*                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                             |

### Response

**[GetConnectBalanceTransferResponse](../../Models/Requests/GetConnectBalanceTransferResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |