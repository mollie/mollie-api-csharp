# Chargebacks
(*Chargebacks*)

## Overview

### Available Operations

* [List](#list) - List payment chargebacks
* [Get](#get) - Get payment chargeback
* [All](#all) - List all chargebacks

## List

Retrieve the chargebacks initiated for a specific payment.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payments.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListChargebacksRequest req = new ListChargebacksRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Embed = ListChargebacksEmbed.Payment,
    Testmode = false,
};

var res = await sdk.Chargebacks.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [ListChargebacksRequest](../../Models/Requests/ListChargebacksRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[ListChargebacksResponse](../../Models/Requests/ListChargebacksResponse.md)**

### Errors

| Error Type                                                        | Status Code                                                       | Content Type                                                      |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| MollieApi.Models.Errors.ListChargebacksBadRequestHalJSONException | 400                                                               | application/hal+json                                              |
| MollieApi.Models.Errors.ListChargebacksNotFoundHalJSONException   | 404                                                               | application/hal+json                                              |
| MollieApi.Models.Errors.APIException                              | 4XX, 5XX                                                          | \*/\*                                                             |

## Get

Retrieve a single payment chargeback by its ID and the ID of its parent payment.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payments.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Chargebacks.GetAsync(
    paymentId: "tr_5B8cwPMGnU",
    chargebackId: "chb_xFzwUN4ci8HAmSGUACS4J",
    embed: GetChargebackEmbed.Payment,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment.                                                                                                                                                                                                                                                                                                                                                 | tr_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `ChargebackId`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related chargeback.                                                                                                                                                                                                                                                                                                                                              | chb_xFzwUN4ci8HAmSGUACS4J                                                                                                                                                                                                                                                                                                                                                              |
| `Embed`                                                                                                                                                                                                                                                                                                                                                                                | [GetChargebackEmbed](../../Models/Requests/GetChargebackEmbed.md)                                                                                                                                                                                                                                                                                                                      | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | This endpoint allows you to embed additional information via the `embed` query string parameter.                                                                                                                                                                                                                                                                                       | payment                                                                                                                                                                                                                                                                                                                                                                                |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetChargebackResponse](../../Models/Requests/GetChargebackResponse.md)**

### Errors

| Error Type                                            | Status Code                                           | Content Type                                          |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| MollieApi.Models.Errors.GetChargebackHalJSONException | 404                                                   | application/hal+json                                  |
| MollieApi.Models.Errors.APIException                  | 4XX, 5XX                                              | \*/\*                                                 |

## All

Retrieve all chargebacks initiated for all your payments.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **payments.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListAllChargebacksRequest req = new ListAllChargebacksRequest() {
    From = "chb_xFzwUN4ci8HAmSGUACS4J",
    Embed = ListAllChargebacksEmbed.Payment,
    Sort = "desc",
    ProfileId = "pfl_5B8cwPMGnU",
    Testmode = false,
};

var res = await sdk.Chargebacks.AllAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [ListAllChargebacksRequest](../../Models/Requests/ListAllChargebacksRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[ListAllChargebacksResponse](../../Models/Requests/ListAllChargebacksResponse.md)**

### Errors

| Error Type                                                           | Status Code                                                          | Content Type                                                         |
| -------------------------------------------------------------------- | -------------------------------------------------------------------- | -------------------------------------------------------------------- |
| MollieApi.Models.Errors.ListAllChargebacksBadRequestHalJSONException | 400                                                                  | application/hal+json                                                 |
| MollieApi.Models.Errors.ListAllChargebacksNotFoundHalJSONException   | 404                                                                  | application/hal+json                                                 |
| MollieApi.Models.Errors.APIException                                 | 4XX, 5XX                                                             | \*/\*                                                                |