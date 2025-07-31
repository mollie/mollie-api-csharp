# Permissions
(*Permissions*)

## Overview

### Available Operations

* [List](#list) - List permissions
* [Get](#get) - Get permission

## List

Retrieve a list of all permissions available to the current access token.

The results are **not** paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-permissions" method="get" path="/permissions" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Permissions.ListAsync();

// handle response
```

### Response

**[ListPermissionsResponse](../../Models/Requests/ListPermissionsResponse.md)**

### Errors

| Error Type                                           | Status Code                                          | Content Type                                         |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| Mollie.Models.Errors.ListPermissionsHalJSONException | 400                                                  | application/hal+json                                 |
| Mollie.Models.Errors.APIException                    | 4XX, 5XX                                             | \*/\*                                                |

## Get

Retrieve a single permission by its ID, and see if the permission is granted to the current access token.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-permission" method="get" path="/permissions/{permissionId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Permissions.GetAsync(
    permissionId: "payments.read",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PermissionId`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related permission.                                                                                                                                                                                                                                                                                                                                              | payments.read                                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetPermissionResponse](../../Models/Requests/GetPermissionResponse.md)**

### Errors

| Error Type                                         | Status Code                                        | Content Type                                       |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| Mollie.Models.Errors.GetPermissionHalJSONException | 404                                                | application/hal+json                               |
| Mollie.Models.Errors.APIException                  | 4XX, 5XX                                           | \*/\*                                              |