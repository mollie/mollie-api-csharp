# Capabilities

## Overview

### Available Operations

* [List](#list) - List capabilities

## List

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieve a list of capabilities for an organization.

This API provides detailed insights into the specific requirements and status of each client's onboarding journey.

Capabilities are at the organization level, indicating if the organization can perform a given capability.

For payments, regardless them being at the profile level, the capability is listed at the organization level.
This means that if at least one of the clients's profiles can receive payments,
the payments capability is enabled, communicating that the organization can indeed receive payments.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-capabilities" method="get" path="/capabilities" example="successful-response-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Capabilities.ListAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[ListCapabilitiesResponse](../../Models/Requests/ListCapabilitiesResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |