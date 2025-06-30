# Capabilities
(*Capabilities*)

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

For payments, regardless them being at the profile level, the capability is listed at the organization level. This means that if at least one of the clients's profiles can receive payments, the payments capability is enabled, communicating that the organization can indeed receive payments.

> 🔑 Access with
>
> [Access token with **onboarding.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Capabilities.ListAsync();

// handle response
```

### Response

**[ListCapabilitiesResponse](../../Models/Requests/ListCapabilitiesResponse.md)**

### Errors

| Error Type                           | Status Code                          | Content Type                         |
| ------------------------------------ | ------------------------------------ | ------------------------------------ |
| MollieApi.Models.Errors.APIException | 4XX, 5XX                             | \*/\*                                |