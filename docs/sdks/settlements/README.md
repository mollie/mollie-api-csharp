# Settlements
(*Settlements*)

## Overview

### Available Operations

* [List](#list) - List settlements
* [Get](#get) - Get settlement
* [GetOpen](#getopen) - Get open settlement
* [GetNext](#getnext) - Get next settlement
* [ListPayments](#listpayments) - Get settlement payments
* [ListCaptures](#listcaptures) - Get settlement captures
* [ListRefunds](#listrefunds) - Get settlement refunds
* [ListChargebacks](#listchargebacks) - Get settlement chargebacks

## List

Retrieve a list of all your settlements.

The results are paginated.

> 🔑 Access with
>
> [Access token with **settlements.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListSettlementsRequest req = new ListSettlementsRequest() {
    From = "stl_jDk30akdN",
    BalanceId = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Year = "2025",
    Month = "1",
    Currencies = "EUR",
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

| Error Type                                                        | Status Code                                                       | Content Type                                                      |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| MollieApi.Models.Errors.ListSettlementsBadRequestHalJSONException | 400                                                               | application/hal+json                                              |
| MollieApi.Models.Errors.ListSettlementsNotFoundHalJSONException   | 404                                                               | application/hal+json                                              |
| MollieApi.Models.Errors.APIException                              | 4XX, 5XX                                                          | \*/\*                                                             |

## Get

Retrieve a single settlement by its ID.

To lookup settlements by their bank reference, replace the ID in the URL by a reference. For example: `1234567.2404.03`.

A settlement represents a transfer of your balance funds to your external bank account.

Settlements will typically include a report that details what balance transactions have taken place between this settlement and the previous one.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the [balance transactions](list-balance-transactions) endpoint.

> 🔑 Access with
>
> [Access token with **settlements.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

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

| Error Type                                            | Status Code                                           | Content Type                                          |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| MollieApi.Models.Errors.GetSettlementHalJSONException | 404                                                   | application/hal+json                                  |
| MollieApi.Models.Errors.APIException                  | 4XX, 5XX                                              | \*/\*                                                 |

## GetOpen

Retrieve the details of the open balance of the organization. This will return a settlement object representing your organization's balance.

For a complete reference of the settlement object, refer to the [Get settlement endpoint](get-settlement) documentation.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the [balance transactions](list-balance-transactions) endpoint.

> 🔑 Access with
>
> [Access token with **settlements.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetOpenAsync();

// handle response
```

### Response

**[GetOpenSettlementResponse](../../Models/Requests/GetOpenSettlementResponse.md)**

### Errors

| Error Type                           | Status Code                          | Content Type                         |
| ------------------------------------ | ------------------------------------ | ------------------------------------ |
| MollieApi.Models.Errors.APIException | 4XX, 5XX                             | \*/\*                                |

## GetNext

Retrieve the details of the current settlement, that has not yet been paid out.

For a complete reference of the settlement object, refer to the [Get settlement endpoint](get-settlement) documentation.

For more accurate bookkeeping, refer to the [balance report](get-balance-report) endpoint or the [balance transactions](list-balance-transactions) endpoint.

> 🔑 Access with
>
> [Access token with **settlements.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Settlements.GetNextAsync();

// handle response
```

### Response

**[GetNextSettlementResponse](../../Models/Requests/GetNextSettlementResponse.md)**

### Errors

| Error Type                           | Status Code                          | Content Type                         |
| ------------------------------------ | ------------------------------------ | ------------------------------------ |
| MollieApi.Models.Errors.APIException | 4XX, 5XX                             | \*/\*                                |

## ListPayments

Retrieve all payments included in the given settlement.

The response is in the same format as the response of the [List payments endpoint](list-payments).

For capture-based payment methods such as Klarna, the payments are not listed here. Refer to the [List captures endpoint](list-captures) endpoint instead.

> 🔑 Access with
>
> [Access token with **settlements.read** **payments.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

GetSettlementPaymentsRequest req = new GetSettlementPaymentsRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "tr_5B8cwPMGnU",
    Sort = "desc",
    ProfileId = "pfl_5B8cwPMGnU",
    Testmode = false,
};

var res = await sdk.Settlements.ListPaymentsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [GetSettlementPaymentsRequest](../../Models/Requests/GetSettlementPaymentsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[GetSettlementPaymentsResponse](../../Models/Requests/GetSettlementPaymentsResponse.md)**

### Errors

| Error Type                                                    | Status Code                                                   | Content Type                                                  |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| MollieApi.Models.Errors.GetSettlementPaymentsHalJSONException | 400                                                           | application/hal+json                                          |
| MollieApi.Models.Errors.APIException                          | 4XX, 5XX                                                      | \*/\*                                                         |

## ListCaptures

Retrieve all captures included in the given settlement.

The response is in the same format as the response of the [List captures endpoint](list-captures).

> 🔑 Access with
>
> [Access token with **settlements.read** **payments.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

GetSettlementCapturesRequest req = new GetSettlementCapturesRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Embed = GetSettlementCapturesEmbed.Payment,
    Testmode = false,
};

var res = await sdk.Settlements.ListCapturesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [GetSettlementCapturesRequest](../../Models/Requests/GetSettlementCapturesRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[GetSettlementCapturesResponse](../../Models/Requests/GetSettlementCapturesResponse.md)**

### Errors

| Error Type                                                              | Status Code                                                             | Content Type                                                            |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| MollieApi.Models.Errors.GetSettlementCapturesBadRequestHalJSONException | 400                                                                     | application/hal+json                                                    |
| MollieApi.Models.Errors.GetSettlementCapturesNotFoundHalJSONException   | 404                                                                     | application/hal+json                                                    |
| MollieApi.Models.Errors.APIException                                    | 4XX, 5XX                                                                | \*/\*                                                                   |

## ListRefunds

Retrieve all refunds 'deducted' from the given settlement.

The response is in the same format as the response of the [List refunds endpoint](list-refunds).

> 🔑 Access with
>
> [Access token with **settlements.read** **refunds.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

GetSettlementRefundsRequest req = new GetSettlementRefundsRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "re_5B8cwPMGnU",
    Include = GetSettlementRefundsInclude.Payment,
    Testmode = false,
};

var res = await sdk.Settlements.ListRefundsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [GetSettlementRefundsRequest](../../Models/Requests/GetSettlementRefundsRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[GetSettlementRefundsResponse](../../Models/Requests/GetSettlementRefundsResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| MollieApi.Models.Errors.GetSettlementRefundsBadRequestHalJSONException | 400                                                                    | application/hal+json                                                   |
| MollieApi.Models.Errors.GetSettlementRefundsNotFoundHalJSONException   | 404                                                                    | application/hal+json                                                   |
| MollieApi.Models.Errors.APIException                                   | 4XX, 5XX                                                               | \*/\*                                                                  |

## ListChargebacks

Retrieve all chargebacks 'deducted' from the given settlement.

The response is in the same format as the response of the [List chargebacks endpoint](list-chargebacks).

> 🔑 Access with
>
> [Access token with **settlements.read** **payments.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

GetSettlementChargebacksRequest req = new GetSettlementChargebacksRequest() {
    SettlementId = "stl_jDk30akdN",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Embed = GetSettlementChargebacksEmbed.Payment,
    Testmode = false,
};

var res = await sdk.Settlements.ListChargebacksAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [GetSettlementChargebacksRequest](../../Models/Requests/GetSettlementChargebacksRequest.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |

### Response

**[GetSettlementChargebacksResponse](../../Models/Requests/GetSettlementChargebacksResponse.md)**

### Errors

| Error Type                                                                 | Status Code                                                                | Content Type                                                               |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- |
| MollieApi.Models.Errors.GetSettlementChargebacksBadRequestHalJSONException | 400                                                                        | application/hal+json                                                       |
| MollieApi.Models.Errors.GetSettlementChargebacksNotFoundHalJSONException   | 404                                                                        | application/hal+json                                                       |
| MollieApi.Models.Errors.APIException                                       | 4XX, 5XX                                                                   | \*/\*                                                                      |