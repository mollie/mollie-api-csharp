# Accounts

## Overview

### Available Operations

* [CreateAccount](#createaccount) - Create business account
* [ListAccounts](#listaccounts) - List business accounts
* [GetAccount](#getaccount) - Get business account
* [List](#list) - List transactions
* [Get](#get) - Get transaction

## CreateAccount

> 🔒 Restricted access
>
> This API is currently only available to Mollie's authorized partners via OAuth. Direct access for individual businesses isn't available yet, but it's on our roadmap — check back here for updates.

Create a new business account for the authenticated organization.

The response contains the newly created business account.

Each organization can have up to 5 active business accounts. Need more? [Contact us](https://www.mollie.com/contact)
and we'll help you out.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-business-account" method="post" path="/v2/business-accounts/accounts" example="create-business-account-201" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

var res = await sdk.Accounts.CreateAccountAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426614174000",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
    requestBody: new CreateBusinessAccountRequestBody() {
        Name = "Main Checking Account",
        Currency = AccountCurrency.Eur,
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                                                           | Type                                                                                                                                                                                                                                                                                                                                                                                                                                | Required                                                                                                                                                                                                                                                                                                                                                                                                                            | Description                                                                                                                                                                                                                                                                                                                                                                                                                         | Example                                                                                                                                                                                                                                                                                                                                                                                                                             |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                                                                    | *string*                                                                                                                                                                                                                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                  | A unique value that identifies this request, so you can safely retry it without creating a second account.<br/>Retrying with the same key within one hour returns the original response. We recommend a UUIDv4.<br/><br/>Keys are tied to the credential that sent the original request, so a refreshed OAuth token won't match<br/>earlier keys. View the [public documentation](https://docs.mollie.com/reference/api-idempotency) to learn<br/>more. | 123e4567-e89b-12d3-a456-426614174000                                                                                                                                                                                                                                                                                                                                                                                                |
| `XClientSignature`                                                                                                                                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                  | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.                                                                                                                                                                                                                                                    | MEUCIQDx8sJvK3z...                                                                                                                                                                                                                                                                                                                                                                                                                  |
| `XClientSignedAt`                                                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                  | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration.                                                                                                                                                                                                                                             | 2025-01-01T12:00:00Z                                                                                                                                                                                                                                                                                                                                                                                                                |
| `RequestBody`                                                                                                                                                                                                                                                                                                                                                                                                                       | [CreateBusinessAccountRequestBody](../../Models/Requests/CreateBusinessAccountRequestBody.md)                                                                                                                                                                                                                                                                                                                                       | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                                                                  | N/A                                                                                                                                                                                                                                                                                                                                                                                                                                 |                                                                                                                                                                                                                                                                                                                                                                                                                                     |

### Response

**[CreateBusinessAccountResponse](../../Models/Requests/CreateBusinessAccountResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 409, 422, 429                 | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListAccounts

> 🔒 Restricted access
>
> This API is currently only available to Mollie's authorized partners via OAuth. Direct access for individual businesses isn't available yet, but it's on our roadmap — check back here for updates.

Retrieve all business accounts for the authenticated organization.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-business-accounts" method="get" path="/v2/business-accounts/accounts" example="list-business-accounts-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        OAuth = "<YOUR_O_AUTH_HERE>",
    }
);

ListBusinessAccountsRequest req = new ListBusinessAccountsRequest() {
    Iban = "NL95MLLE1234567890",
    From = "ba_nopqrstuvwxyz23456789A",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListBusinessAccountsResponse? res = await sdk.Accounts.ListAccountsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [ListBusinessAccountsRequest](../../Models/Requests/ListBusinessAccountsRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[ListBusinessAccountsResponse](../../Models/Requests/ListBusinessAccountsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## GetAccount

> 🔒 Restricted access
>
> This API is currently only available to Mollie's authorized partners via OAuth. Direct access for individual businesses isn't available yet, but it's on our roadmap — check back here for updates.

Retrieve a single business account object by its account ID. This allows you to check the current status,
balance, and account details.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-business-account" method="get" path="/v2/business-accounts/accounts/{businessAccountId}" example="get-business-account-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        OAuth = "<YOUR_O_AUTH_HERE>",
    }
);

GetBusinessAccountRequest req = new GetBusinessAccountRequest() {
    BusinessAccountId = "ba_nopqrstuvwxyz23456789A",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Accounts.GetAccountAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [GetBusinessAccountRequest](../../Models/Requests/GetBusinessAccountRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[GetBusinessAccountResponse](../../Models/Requests/GetBusinessAccountResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

> 🔒 Restricted access
>
> This API is currently only available to Mollie's authorized partners via OAuth. Direct access for individual businesses isn't available yet, but it's on our roadmap — check back here for updates.

Retrieve all transactions for a specific business account.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-business-account-transactions" method="get" path="/v2/business-accounts/accounts/{businessAccountId}/transactions" example="list-transactions-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        OAuth = "<YOUR_O_AUTH_HERE>",
    }
);

ListBusinessAccountTransactionsRequest req = new ListBusinessAccountTransactionsRequest() {
    BusinessAccountId = "ba_nopqrstuvwxyz23456789A",
    CreditDebitIndicator = CreditDebitIndicator.Debit,
    ProcessedAfter = System.DateTime.Parse("2025-02-01T00:00:00+00:00").ToUniversalTime(),
    ProcessedBefore = System.DateTime.Parse("2025-02-26T23:59:59+00:00").ToUniversalTime(),
    From = "batr_87GByBuj4UCcUTEbs6aGJ",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListBusinessAccountTransactionsResponse? res = await sdk.Accounts.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                 | [ListBusinessAccountTransactionsRequest](../../Models/Requests/ListBusinessAccountTransactionsRequest.md) | :heavy_check_mark:                                                                                        | The request object to use for the request.                                                                |

### Response

**[ListBusinessAccountTransactionsResponse](../../Models/Requests/ListBusinessAccountTransactionsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🔒 Restricted access
>
> This API is currently only available to Mollie's authorized partners via OAuth. Direct access for individual businesses isn't available yet, but it's on our roadmap — check back here for updates.

Retrieve a single transaction object by its transaction ID. This allows you to check the details,
amount, counterparty, and balance impact of a specific transaction.

### Example Usage: get-transaction-200

<!-- UsageSnippet language="csharp" operationID="get-business-account-transaction" method="get" path="/v2/business-accounts/accounts/{businessAccountId}/transactions/{transactionId}" example="get-transaction-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        OAuth = "<YOUR_O_AUTH_HERE>",
    }
);

GetBusinessAccountTransactionRequest req = new GetBusinessAccountTransactionRequest() {
    BusinessAccountId = "ba_nopqrstuvwxyz23456789A",
    TransactionId = "batr_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Accounts.GetAsync(req);

// handle response
```
### Example Usage: get-transaction-200-credit

<!-- UsageSnippet language="csharp" operationID="get-business-account-transaction" method="get" path="/v2/business-accounts/accounts/{businessAccountId}/transactions/{transactionId}" example="get-transaction-200-credit" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: true,
    security: new Security() {
        OAuth = "<YOUR_O_AUTH_HERE>",
    }
);

GetBusinessAccountTransactionRequest req = new GetBusinessAccountTransactionRequest() {
    BusinessAccountId = "ba_nopqrstuvwxyz23456789A",
    TransactionId = "batr_87GByBuj4UCcUTEbs6aGJ",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Accounts.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                             | Type                                                                                                  | Required                                                                                              | Description                                                                                           |
| ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `request`                                                                                             | [GetBusinessAccountTransactionRequest](../../Models/Requests/GetBusinessAccountTransactionRequest.md) | :heavy_check_mark:                                                                                    | The request object to use for the request.                                                            |

### Response

**[GetBusinessAccountTransactionResponse](../../Models/Requests/GetBusinessAccountTransactionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |