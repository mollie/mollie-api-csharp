# Terminals

## Overview

### Available Operations

* [List](#list) - List terminals
* [Get](#get) - Get terminal
* [TerminalsRequestPairingCode](#terminalsrequestpairingcode) - Request terminal pairing code
* [TerminalsListPairingCodes](#terminalslistpairingcodes) - List terminal pairing codes
* [TerminalsGetPairingCode](#terminalsgetpairingcode) - Get terminal pairing code
* [TerminalsRevokePairingCode](#terminalsrevokepairingcode) - Revoke terminal pairing code

## List

Retrieve a list of all physical point-of-sale devices.

The results are paginated.

### Example Usage: list-terminals-200-1

<!-- UsageSnippet language="csharp" operationID="list-terminals" method="get" path="/v2/terminals" example="list-terminals-200-1" -->
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

ListTerminalsRequest req = new ListTerminalsRequest() {
    From = "term_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListTerminalsResponse? res = await sdk.Terminals.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-terminals-200-2

<!-- UsageSnippet language="csharp" operationID="list-terminals" method="get" path="/v2/terminals" example="list-terminals-200-2" -->
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

ListTerminalsRequest req = new ListTerminalsRequest() {
    From = "term_vytxeTZskVKR7C7WgdSP3d",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListTerminalsResponse? res = await sdk.Terminals.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [ListTerminalsRequest](../../Models/Requests/ListTerminalsRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[ListTerminalsResponse](../../Models/Requests/ListTerminalsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single terminal by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-terminal" method="get" path="/v2/terminals/{terminalId}" example="get-terminal-200-1" -->
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

GetTerminalRequest req = new GetTerminalRequest() {
    TerminalId = "term_vytxeTZskVKR7C7WgdSP3d",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Terminals.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [GetTerminalRequest](../../Models/Requests/GetTerminalRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[GetTerminalResponse](../../Models/Requests/GetTerminalResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## TerminalsRequestPairingCode

> ℹ️ **Test mode**
>
> This endpoint currently does not support test mode yet.

Request a pairing code to onboard a point-of-sale terminal.

The response includes a human-readable `code` for manual entry on the terminal, and a QR Code as a
base64 encoded SVG data URI for scanning if you specify the query parameter `include` with value `details.qrCode`.

Pairing codes expire after 90 days (see `expiresAt`) and can be used multiple times.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="terminals-request-pairing-code" method="post" path="/v2/terminals/pairing-codes" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

TerminalsRequestPairingCodeRequest req = new TerminalsRequestPairingCodeRequest() {
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new TerminalsRequestPairingCodeRequestBody() {
        ProfileId = "pfl_jA9bC4DkFj3G",
    },
};

var res = await sdk.Terminals.TerminalsRequestPairingCodeAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `request`                                                                                         | [TerminalsRequestPairingCodeRequest](../../Models/Requests/TerminalsRequestPairingCodeRequest.md) | :heavy_check_mark:                                                                                | The request object to use for the request.                                                        |

### Response

**[TerminalsRequestPairingCodeResponse](../../Models/Requests/TerminalsRequestPairingCodeResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 403, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## TerminalsListPairingCodes

> ℹ️ **Test mode**
>
> This endpoint currently does not support test mode yet.

Returns your pairing codes: `active`, `expired`, and `revoked`. Results are paginated.

We keep a pairing code for one month after it is revoked or expires, then delete it. Deleted codes drop out of
this list. Active pairing codes are never deleted.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="terminals-list-pairing-codes" method="get" path="/v2/terminals/pairing-codes" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "<id>",
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

TerminalsListPairingCodesRequest req = new TerminalsListPairingCodesRequest() {
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Terminals.TerminalsListPairingCodesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `request`                                                                                     | [TerminalsListPairingCodesRequest](../../Models/Requests/TerminalsListPairingCodesRequest.md) | :heavy_check_mark:                                                                            | The request object to use for the request.                                                    |

### Response

**[TerminalsListPairingCodesResponse](../../Models/Requests/TerminalsListPairingCodesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## TerminalsGetPairingCode

> ℹ️ **Test mode**
>
> This endpoint currently does not support test mode yet.

Get a pairing code to onboard a point-of-sale terminal.

The response includes a human-readable `code` for manual entry on the terminal and, optionally, a QR Code as a
base64 encoded SVG data URI when you use the `include` query parameter with value `details.qrCode`.

We keep a pairing code for one month after it is revoked or expires, then delete it. Once deleted, this endpoint
returns a 404. Active pairing codes are never deleted.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="terminals-get-pairing-code" method="get" path="/v2/terminals/pairing-codes/{pairingCodeId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

TerminalsGetPairingCodeRequest req = new TerminalsGetPairingCodeRequest() {
    PairingCodeId = "termpc_R7gX5Ea9bC4DkFj3G",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Terminals.TerminalsGetPairingCodeAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [TerminalsGetPairingCodeRequest](../../Models/Requests/TerminalsGetPairingCodeRequest.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[TerminalsGetPairingCodeResponse](../../Models/Requests/TerminalsGetPairingCodeResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## TerminalsRevokePairingCode

> ℹ️ **Test mode**
>
> This endpoint currently does not support test mode yet.

Revoke a pairing code, preventing the onboarding of new point-of-sale terminals.

Terminals that have already paired with this code are not affected.

We keep a revoked pairing code for one month, then delete it. Once deleted, this endpoint returns a 404.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="terminals-revoke-pairing-code" method="delete" path="/v2/terminals/pairing-codes/{pairingCodeId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Terminals.TerminalsRevokePairingCodeAsync(
    pairingCodeId: "termpc_R7gX5Ea9bC4DkFj3G",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PairingCodeId`                                                                                                                                                                         | *string*                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                      | Provide the ID of the terminal pairing code.                                                                                                                                            | termpc_R7gX5Ea9bC4DkFj3G                                                                                                                                                                |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |

### Response

**[TerminalsRevokePairingCodeResponse](../../Models/Requests/TerminalsRevokePairingCodeResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |