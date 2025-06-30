# Methods
(*Methods*)

## Overview

### Available Operations

* [List](#list) - List payment methods
* [All](#all) - List all payment methods
* [Get](#get) - Get payment method

## List

Retrieve all enabled payment methods. The results of this endpoint are **not** paginated — unlike most other list endpoints in our API.

For test mode, all pending and enabled payment methods are returned. If no payment methods are requested yet, the most popular payment methods are returned in the test mode. For live mode, only fully enabled payment methods are returned.

Payment methods can be requested and enabled via the Mollie Dashboard, or via the [Enable payment method endpoint](enable-method) of the Profiles API.

The list can optionally be filtered using a number of parameters described below.

By default, only payment methods for the Euro currency are returned. If you wish to retrieve payment methods which exclusively support other currencies (e.g. Twint), you need to use the `amount` parameters.

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

ListMethodsRequest req = new ListMethodsRequest() {
    Locale = "en_US",
    Amount = new ListMethodsAmount() {
        Currency = "EUR",
        Value = "10.00",
    },
    BillingCountry = "DE",
    IncludeWallets = "applepay",
    OrderLineCategories = "eco",
    ProfileId = "pfl_5B8cwPMGnU",
    Include = ListMethodsInclude.Issuers,
    Testmode = false,
};

var res = await sdk.Methods.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [ListMethodsRequest](../../Models/Requests/ListMethodsRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[ListMethodsResponse](../../Models/Requests/ListMethodsResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| MollieApi.Models.Errors.ListMethodsHalJSONException | 400                                                 | application/hal+json                                |
| MollieApi.Models.Errors.APIException                | 4XX, 5XX                                            | \*/\*                                               |

## All

Retrieve all payment methods that Mollie offers, regardless of the eligibility of the organization for the specific method. The results of this endpoint are **not** paginated — unlike most other list endpoints in our API.

The list can optionally be filtered using a number of parameters described below.

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

ListAllMethodsRequest req = new ListAllMethodsRequest() {
    Locale = "en_US",
    Amount = new ListAllMethodsAmount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Include = ListAllMethodsInclude.Issuers,
    ProfileId = "pfl_5B8cwPMGnU",
    Testmode = false,
};

var res = await sdk.Methods.AllAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [ListAllMethodsRequest](../../Models/Requests/ListAllMethodsRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[ListAllMethodsResponse](../../Models/Requests/ListAllMethodsResponse.md)**

### Errors

| Error Type                                             | Status Code                                            | Content Type                                           |
| ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ |
| MollieApi.Models.Errors.ListAllMethodsHalJSONException | 400                                                    | application/hal+json                                   |
| MollieApi.Models.Errors.APIException                   | 4XX, 5XX                                               | \*/\*                                                  |

## Get

Retrieve a single payment method by its ID.

If a method is not available on this profile, a `404 Not Found` response is returned. If the method is available but not enabled yet, a status `403 Forbidden` is returned. You can enable payments methods via the [Enable payment method endpoint](enable-method) of the Profiles API, or via the Mollie Dashboard.

If you do not know the method's ID, you can use the [methods list endpoint](list-methods) to retrieve all payment methods that are available.

Additionally, it is possible to check if wallet methods such as Apple Pay are enabled by passing the wallet ID (`applepay`) as the method ID.

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

GetMethodRequest req = new GetMethodRequest() {
    Id = "ideal",
    Locale = "en_US",
    Currency = "EUR",
    ProfileId = "pfl_5B8cwPMGnU",
    Include = GetMethodInclude.Issuers,
    Testmode = false,
};

var res = await sdk.Methods.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                     | Type                                                          | Required                                                      | Description                                                   |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| `request`                                                     | [GetMethodRequest](../../Models/Requests/GetMethodRequest.md) | :heavy_check_mark:                                            | The request object to use for the request.                    |

### Response

**[GetMethodResponse](../../Models/Requests/GetMethodResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| MollieApi.Models.Errors.GetMethodBadRequestHalJSONException | 400                                                         | application/hal+json                                        |
| MollieApi.Models.Errors.GetMethodNotFoundHalJSONException   | 404                                                         | application/hal+json                                        |
| MollieApi.Models.Errors.APIException                        | 4XX, 5XX                                                    | \*/\*                                                       |