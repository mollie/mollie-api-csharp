# Terminals

## Overview

### Available Operations

* [List](#list) - List terminals
* [Get](#get) - Get terminal

## List

Retrieve a list of all physical point-of-sale devices.

The results are paginated.

### Example Usage: list-terminals-200-1

<!-- UsageSnippet language="csharp" operationID="list-terminals" method="get" path="/terminals" example="list-terminals-200-1" -->
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
};

var res = await sdk.Terminals.ListAsync(req);

// handle response
```
### Example Usage: list-terminals-200-2

<!-- UsageSnippet language="csharp" operationID="list-terminals" method="get" path="/terminals" example="list-terminals-200-2" -->
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
};

var res = await sdk.Terminals.ListAsync(req);

// handle response
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
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single terminal by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-terminal" method="get" path="/terminals/{terminalId}" example="get-terminal-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Terminals.GetAsync(
    terminalId: "term_vytxeTZskVKR7C7WgdSP3d",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `TerminalId`                                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the related terminal.                                                                                                                                                                                                                                                                                                                                                  | term_vytxeTZskVKR7C7WgdSP3d                                                                                                                                                                                                                                                                                                                                                              |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

### Response

**[GetTerminalResponse](../../Models/Requests/GetTerminalResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |