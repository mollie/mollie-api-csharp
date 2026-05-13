# Payouts

## Overview

### Available Operations

* [Create](#create) - Create payout
* [List](#list) - List payouts
* [Get](#get) - Get payout
* [Cancel](#cancel) - Cancel payout

## Create

Request a payout from one of your balances to the balance's configured bank account.

The payout will be executed on the next scheduled business day. If no `amount` is specified, the full available
balance minus any configured balance reserve is paid out.

Once the payout is created with status `requested`, you can cancel it via the
[Cancel payout](cancel-payout) endpoint, up until the payout moves to `initiated`.

Creating a payout via the API automatically sets the balance's `transferFrequency` to `never`,
pausing any previously configured automatic settlement schedule. To resume automatic settlements,
update the transfer frequency via the dashboard.

### Webhooks

Subscribe to the following webhook events to track payout status changes. See the
[Webhook Subscriptions API](list-webhooks) for details on subscribing.

| Event | Description |
|---|---|
| `payout.initiated` | The payout is being executed and funds are reserved. |
| `payout.processing-at-bank` | The payout has been submitted to the bank. |
| `payout.completed` | The payout has been sent to the destination bank account. |
| `payout.canceled` | The payout was canceled via the API before being submitted to the bank. |
| `payout.failed` | The payout failed after creation, including bank rejections and post-submission cancellations. |

### Payout failure reasons

A payout request may fail immediately if one of the following conditions applies:

- A payout is already scheduled for the next business day for this balance.
- The balance has insufficient funds.
- The balance is not active.
- Payouts are blocked for this organization.
- The balance has queued refunds.
- One of the organization's balances is below the negative balance threshold.
- The payout destination (bank account) is invalid or not configured.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-payout" method="post" path="/v2/payouts" example="create-payout-201" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Payouts.CreateAsync(
    payoutRequest: new PayoutRequest() {
        BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
        Amount = new AmountNullable() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "My payout description",
        Testmode = false,
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PayoutRequest`                                                                                                                                                                                                                                                                                                                                                                          | [PayoutRequest](../../Models/Components/PayoutRequest.md)                                                                                                                                                                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | N/A                                                                                                                                                                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

### Response

**[CreatePayoutResponse](../../Models/Requests/CreatePayoutResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all payouts for your organization, including payouts initiated automatically by the
balance's payout schedule and payouts requested via the API or dashboard.

Only payouts created on or after April 1st, 2026 are returned.

The results are paginated. Use the `from` query parameter together with `_links.next` to iterate through
the full result set.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-payouts" method="get" path="/v2/payouts" example="list-payouts-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListPayoutsRequest req = new ListPayoutsRequest() {
    BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListPayoutsResponse? res = await sdk.Payouts.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [ListPayoutsRequest](../../Models/Requests/ListPayoutsRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[ListPayoutsResponse](../../Models/Requests/ListPayoutsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single payout by its ID.

### Example Usage: get-payout-200-completed

<!-- UsageSnippet language="csharp" operationID="get-payout" method="get" path="/v2/payouts/{payoutId}" example="get-payout-200-completed" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Payouts.GetAsync(
    payoutId: "payout_j8NvRAM2WNZtsykpLEX8J",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: get-payout-200-failed

<!-- UsageSnippet language="csharp" operationID="get-payout" method="get" path="/v2/payouts/{payoutId}" example="get-payout-200-failed" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Payouts.GetAsync(
    payoutId: "payout_j8NvRAM2WNZtsykpLEX8J",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: get-payout-200-requested

<!-- UsageSnippet language="csharp" operationID="get-payout" method="get" path="/v2/payouts/{payoutId}" example="get-payout-200-requested" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Payouts.GetAsync(
    payoutId: "payout_j8NvRAM2WNZtsykpLEX8J",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PayoutId`                                                                                                                                                                                                                                                                                                                                                                               | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the payout.                                                                                                                                                                                                                                                                                                                                                            | payout_j8NvRAM2WNZtsykpLEX8J                                                                                                                                                                                                                                                                                                                                                             |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

### Response

**[GetPayoutResponse](../../Models/Requests/GetPayoutResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Cancel

Cancel a payout. A payout can only be canceled while it has the status `requested`. Once the payout moves
to `initiated`, it is too late to cancel.

The canceled payout object is returned with the status set to `canceled`.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-payout" method="delete" path="/v2/payouts/{payoutId}" example="cancel-payout-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Payouts.CancelAsync(
    payoutId: "payout_j8NvRAM2WNZtsykpLEX8J",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PayoutId`                                                                                                                                                                                                                                                                                                                                                                               | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the payout.                                                                                                                                                                                                                                                                                                                                                            | payout_j8NvRAM2WNZtsykpLEX8J                                                                                                                                                                                                                                                                                                                                                             |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

### Response

**[CancelPayoutResponse](../../Models/Requests/CancelPayoutResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 409                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |