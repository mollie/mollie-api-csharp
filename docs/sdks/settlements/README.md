# Settlements
(*Settlements*)

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

<!-- UsageSnippet language="csharp" operationID="list-settlements" method="get" path="/settlements" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementsRequest req = new ListSettlementsRequest() {
    From = "stl_jDk30akdN",
    BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Year = "2025",
    Month = "1",
    Currencies = Currencies.Eur,
};

var res = await sdk.Settlements.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [ListSettlementsRequest](../../Models/Requests/ListSettlementsRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[ListSettlementsResponse](../../Models/Requests/ListSettlementsResponse.md)**

### Errors

| Error Type                                                     | Status Code                                                    | Content Type                                                   |
| -------------------------------------------------------------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Mollie.Models.Errors.ListSettlementsBadRequestHalJSONException | 400                                                            | application/hal+json                                           |
| Mollie.Models.Errors.ListSettlementsNotFoundHalJSONException   | 404                                                            | application/hal+json                                           |
| Mollie.Models.Errors.APIException                              | 4XX, 5XX                                                       | \*/\*                                                          |

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

<!-- UsageSnippet language="csharp" operationID="get-settlement" method="get" path="/settlements/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetAsync(id: "stl_jDk30akdN");

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Id`                                                              | *string*                                                          | :heavy_check_mark:                                                | Provide the ID of the item you want to perform this operation on. | stl_jDk30akdN                                                     |

### Response

**[GetSettlementResponse](../../Models/Requests/GetSettlementResponse.md)**

### Errors

| Error Type                                         | Status Code                                        | Content Type                                       |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| Mollie.Models.Errors.GetSettlementHalJSONException | 404                                                | application/hal+json                               |
| Mollie.Models.Errors.APIException                  | 4XX, 5XX                                           | \*/\*                                              |

## GetOpen

Retrieve the details of the open balance of the organization. This will return a settlement object representing your
organization's balance.

For a complete reference of the settlement object, refer to the [Get settlement endpoint](get-settlement)
documentation.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the
[balance transactions](list-balance-transactions) endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-open-settlement" method="get" path="/settlements/open" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetOpenAsync();

// handle response
```

### Response

**[GetOpenSettlementResponse](../../Models/Requests/GetOpenSettlementResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |

## GetNext

Retrieve the details of the current settlement, that has not yet been paid out.

For a complete reference of the settlement object, refer to the [Get settlement endpoint](get-settlement)
documentation.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the
[balance transactions](list-balance-transactions) endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-next-settlement" method="get" path="/settlements/next" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetNextAsync();

// handle response
```

### Response

**[GetNextSettlementResponse](../../Models/Requests/GetNextSettlementResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |

## ListPayments

Retrieve all payments included in the given settlement.

The response is in the same format as the response of the [List payments endpoint](list-payments).

For capture-based payment methods such as Klarna, the payments are not listed here. Refer to the
[List captures endpoint](list-captures) endpoint instead.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-settlement-payments" method="get" path="/settlements/{settlementId}/payments" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementPaymentsRequest req = new ListSettlementPaymentsRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "tr_5B8cwPMGnU",
    ProfileId = "pfl_5B8cwPMGnU",
    Testmode = false,
};

var res = await sdk.Settlements.ListPaymentsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [ListSettlementPaymentsRequest](../../Models/Requests/ListSettlementPaymentsRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[ListSettlementPaymentsResponse](../../Models/Requests/ListSettlementPaymentsResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Mollie.Models.Errors.ListSettlementPaymentsHalJSONException | 400                                                         | application/hal+json                                        |
| Mollie.Models.Errors.APIException                           | 4XX, 5XX                                                    | \*/\*                                                       |

## ListCaptures

Retrieve all captures included in the given settlement.

The response is in the same format as the response of the [List captures endpoint](list-captures).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-settlement-captures" method="get" path="/settlements/{settlementId}/captures" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementCapturesRequest req = new ListSettlementCapturesRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Embed = ListSettlementCapturesEmbed.Payment,
    Testmode = false,
};

var res = await sdk.Settlements.ListCapturesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [ListSettlementCapturesRequest](../../Models/Requests/ListSettlementCapturesRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[ListSettlementCapturesResponse](../../Models/Requests/ListSettlementCapturesResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Mollie.Models.Errors.ListSettlementCapturesBadRequestHalJSONException | 400                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.ListSettlementCapturesNotFoundHalJSONException   | 404                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.APIException                                     | 4XX, 5XX                                                              | \*/\*                                                                 |

## ListRefunds

Retrieve all refunds 'deducted' from the given settlement.

The response is in the same format as the response of the [List refunds endpoint](list-refunds).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-settlement-refunds" method="get" path="/settlements/{settlementId}/refunds" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementRefundsRequest req = new ListSettlementRefundsRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "re_5B8cwPMGnU",
    Include = ListSettlementRefundsInclude.Payment,
    Testmode = false,
};

var res = await sdk.Settlements.ListRefundsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [ListSettlementRefundsRequest](../../Models/Requests/ListSettlementRefundsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[ListSettlementRefundsResponse](../../Models/Requests/ListSettlementRefundsResponse.md)**

### Errors

| Error Type                                                           | Status Code                                                          | Content Type                                                         |
| -------------------------------------------------------------------- | -------------------------------------------------------------------- | -------------------------------------------------------------------- |
| Mollie.Models.Errors.ListSettlementRefundsBadRequestHalJSONException | 400                                                                  | application/hal+json                                                 |
| Mollie.Models.Errors.ListSettlementRefundsNotFoundHalJSONException   | 404                                                                  | application/hal+json                                                 |
| Mollie.Models.Errors.APIException                                    | 4XX, 5XX                                                             | \*/\*                                                                |

## ListChargebacks

Retrieve all chargebacks 'deducted' from the given settlement.

The response is in the same format as the response of the [List chargebacks endpoint](list-chargebacks).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-settlement-chargebacks" method="get" path="/settlements/{settlementId}/chargebacks" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementChargebacksRequest req = new ListSettlementChargebacksRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Embed = ListSettlementChargebacksEmbed.Payment,
    Testmode = false,
};

var res = await sdk.Settlements.ListChargebacksAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `request`                                                                                     | [ListSettlementChargebacksRequest](../../Models/Requests/ListSettlementChargebacksRequest.md) | :heavy_check_mark:                                                                            | The request object to use for the request.                                                    |

### Response

**[ListSettlementChargebacksResponse](../../Models/Requests/ListSettlementChargebacksResponse.md)**

### Errors

| Error Type                                                               | Status Code                                                              | Content Type                                                             |
| ------------------------------------------------------------------------ | ------------------------------------------------------------------------ | ------------------------------------------------------------------------ |
| Mollie.Models.Errors.ListSettlementChargebacksBadRequestHalJSONException | 400                                                                      | application/hal+json                                                     |
| Mollie.Models.Errors.ListSettlementChargebacksNotFoundHalJSONException   | 404                                                                      | application/hal+json                                                     |
| Mollie.Models.Errors.APIException                                        | 4XX, 5XX                                                                 | \*/\*                                                                    |