# Permissions

## Overview

### Available Operations

* [List](#list) - List permissions
* [Get](#get) - Get permission

## List

Retrieve a list of all permissions available to the current access token.

The results are **not** paginated.

### Example Usage: list-permissions-200-1

<!-- UsageSnippet language="csharp" operationID="list-permissions" method="get" path="/permissions" example="list-permissions-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Permissions.ListAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```
### Example Usage: list-permissions-200-2

<!-- UsageSnippet language="csharp" operationID="list-permissions" method="get" path="/permissions" example="list-permissions-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Permissions.ListAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[ListPermissionsResponse](../../Models/Requests/ListPermissionsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single permission by its ID, and see if the permission is granted to the current access token.

### Example Usage: get-permission-200-1

<!-- UsageSnippet language="csharp" operationID="get-permission" method="get" path="/permissions/{permissionId}" example="get-permission-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Permissions.GetAsync(
    permissionId: "payments.read",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: get-permission-200-2

<!-- UsageSnippet language="csharp" operationID="get-permission" method="get" path="/permissions/{permissionId}" example="get-permission-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Permissions.GetAsync(
    permissionId: "payments.read",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                               | Type                                                                                                                                                                    | Required                                                                                                                                                                | Description                                                                                                                                                             | Example                                                                                                                                                                 |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `PermissionId`                                                                                                                                                          | *string*                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                      | Provide the ID of the related permission.                                                                                                                               | payments.read                                                                                                                                                           |
| `Testmode`                                                                                                                                                              | *bool*                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                      | You can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                         |
| `IdempotencyKey`                                                                                                                                                        | *string*                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                             |

### Response

**[GetPermissionResponse](../../Models/Requests/GetPermissionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |