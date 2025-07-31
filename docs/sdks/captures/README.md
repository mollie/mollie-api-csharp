# Captures
(*Captures*)

## Overview

### Available Operations

* [Create](#create) - Create capture
* [List](#list) - List captures
* [Get](#get) - Get capture

## Create

Capture an *authorized* payment.

Some payment methods allow you to first collect a customer's authorization,
and capture the amount at a later point.

By default, Mollie captures payments automatically. If however you
configured your payment with `captureMode: manual`, you can capture the payment using this endpoint after
having collected the customer's authorization.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-capture" method="post" path="/payments/{paymentId}/captures" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Captures.CreateAsync(
    paymentId: "tr_5B8cwPMGnU",
    requestBody: new CreateCaptureRequestBody() {
        Description = "Capture for cart #12345",
        Amount = new CreateCaptureAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `PaymentId`                                                                   | *string*                                                                      | :heavy_check_mark:                                                            | Provide the ID of the related payment.                                        | tr_5B8cwPMGnU                                                                 |
| `RequestBody`                                                                 | [CreateCaptureRequestBody](../../Models/Requests/CreateCaptureRequestBody.md) | :heavy_minus_sign:                                                            | N/A                                                                           |                                                                               |

### Response

**[CreateCaptureResponse](../../Models/Requests/CreateCaptureResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Mollie.Models.Errors.CreateCaptureNotFoundHalJSONException            | 404                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.CreateCaptureUnprocessableEntityHalJSONException | 422                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.APIException                                     | 4XX, 5XX                                                              | \*/\*                                                                 |

## List

Retrieve a list of all captures created for a specific payment.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-captures" method="get" path="/payments/{paymentId}/captures" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListCapturesRequest req = new ListCapturesRequest() {
    PaymentId = "tr_5B8cwPMGnU",
    From = "cpt_vytxeTZskVKR7C7WgdSP3d",
    Embed = ListCapturesEmbed.Payment,
    Testmode = false,
};

var res = await sdk.Captures.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListCapturesRequest](../../Models/Requests/ListCapturesRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListCapturesResponse](../../Models/Requests/ListCapturesResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Mollie.Models.Errors.ListCapturesBadRequestHalJSONException | 400                                                         | application/hal+json                                        |
| Mollie.Models.Errors.ListCapturesNotFoundHalJSONException   | 404                                                         | application/hal+json                                        |
| Mollie.Models.Errors.APIException                           | 4XX, 5XX                                                    | \*/\*                                                       |

## Get

Retrieve a single payment capture by its ID and the ID of its parent
payment.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-capture" method="get" path="/payments/{paymentId}/captures/{captureId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Captures.GetAsync(
    paymentId: "tr_5B8cwPMGnU",
    captureId: "cpt_gVMhHKqSSRYJyPsuoPNFH",
    embed: GetCaptureEmbed.Payment,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PaymentId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related payment.                                                                                                                                                                                                                                                                                                                                                 | tr_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                          |
| `CaptureId`                                                                                                                                                                                                                                                                                                                                                                            | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related capture.                                                                                                                                                                                                                                                                                                                                                 | cpt_gVMhHKqSSRYJyPsuoPNFH                                                                                                                                                                                                                                                                                                                                                              |
| `Embed`                                                                                                                                                                                                                                                                                                                                                                                | [GetCaptureEmbed](../../Models/Requests/GetCaptureEmbed.md)                                                                                                                                                                                                                                                                                                                            | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | This endpoint allows you to embed additional resources via the<br/>`embed` query string parameter.                                                                                                                                                                                                                                                                                     | payment                                                                                                                                                                                                                                                                                                                                                                                |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetCaptureResponse](../../Models/Requests/GetCaptureResponse.md)**

### Errors

| Error Type                                      | Status Code                                     | Content Type                                    |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| Mollie.Models.Errors.GetCaptureHalJSONException | 404                                             | application/hal+json                            |
| Mollie.Models.Errors.APIException               | 4XX, 5XX                                        | \*/\*                                           |