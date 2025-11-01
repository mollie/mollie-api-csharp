# Balances
(*Balances*)

## Overview

### Available Operations

* [List](#list) - List balances
* [Get](#get) - Get balance
* [GetPrimary](#getprimary) - Get primary balance
* [GetReport](#getreport) - Get balance report
* [ListTransactions](#listtransactions) - List balance transactions

## List

Retrieve a list of the organization's balances, including the primary balance.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-balances" method="get" path="/balances" -->
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

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListBalancesRequest](../../Models/Requests/ListBalancesRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListBalancesResponse](../../Models/Requests/ListBalancesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

When processing payments with Mollie, we put all pending funds — usually
minus Mollie fees — on a balance. Once you have linked a bank account to your Mollie account, we can pay out your
balance towards this bank account.

With the Balances API you can retrieve your current balance. The response
includes two amounts:

* The *pending amount*. These are payments that have been marked as `paid`,
but are not yet available on your balance.
* The *available amount*. This is the amount that you can get paid out to
your bank account, or use for refunds.

With instant payment methods like iDEAL, payments are moved to the available
balance instantly. With slower payment methods, like credit card for example, it can take a few days before the
funds are available on your balance. These funds will be shown under the *pending amount* in the meanwhile.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-balance" method="get" path="/balances/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Balances.GetAsync(
    id: "bal_gVMhHKqSSRYJyPsuoPNFH",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Id`                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the item you want to perform this operation on.                                                                                                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                                                                                        |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                        |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                       | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                       | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                            |

### Response

**[GetBalanceResponse](../../Models/Requests/GetBalanceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## GetPrimary

Retrieve the primary balance. This is the balance of your account's primary
currency, where all payments are settled to by default.

This endpoint is a convenient alias of the [Get balance](get-balance)
endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-primary-balance" method="get" path="/balances/primary" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Balances.GetPrimaryAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetPrimaryBalanceResponse](../../Models/Requests/GetPrimaryBalanceResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |

## GetReport

Retrieve a summarized report for all transactions on a given balance within a given timeframe.

The API also provides a detailed report on all 'prepayments' for Mollie fees that were deducted from your balance
during the reported period, ahead of your Mollie invoice.

The alias `primary` can be used instead of the balance ID to refer to the
organization's primary balance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-balance-report" method="get" path="/balances/{balanceId}/report" -->
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

GetBalanceReportRequest req = new GetBalanceReportRequest() {
    BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
    From = "2024-01-01",
    Until = "2024-02-01",
    Grouping = BalanceReportGrouping.StatusBalances,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.GetReportAsync(req);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [GetBalanceReportRequest](../../Models/Requests/GetBalanceReportRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[GetBalanceReportResponse](../../Models/Requests/GetBalanceReportResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListTransactions

Retrieve a list of all balance transactions. Transactions include for
example payments, refunds, chargebacks, and settlements.

For an aggregated report of these balance transactions, refer to the [Get
balance report](get-balance-report) endpoint.

The alias `primary` can be used instead of the balance ID to refer to the
organization's primary balance.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-balance-transactions" method="get" path="/balances/{balanceId}/transactions" -->
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

ListBalanceTransactionsRequest req = new ListBalanceTransactionsRequest() {
    BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
    From = "baltr_QM24QwzUWR4ev4Xfgyt29A",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListTransactionsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [ListBalanceTransactionsRequest](../../Models/Requests/ListBalanceTransactionsRequest.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[ListBalanceTransactionsResponse](../../Models/Requests/ListBalanceTransactionsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |