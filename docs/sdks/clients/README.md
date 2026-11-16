# Clients

## Overview

### Available Operations

* [List](#list) - List clients
* [Get](#get) - Get client

## List

Retrieve a list of all clients linked to your account.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-clients" method="get" path="/v2/clients" example="list-clients-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListClientsRequest req = new ListClientsRequest() {
    Embed = "organization",
    From = "org_12345678",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListClientsResponse? res = await sdk.Clients.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [ListClientsRequest](../../Models/Requests/ListClientsRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[ListClientsResponse](../../Models/Requests/ListClientsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single client by its ID.

### Example Usage: get-client-200-1

<!-- UsageSnippet language="csharp" operationID="get-client" method="get" path="/v2/clients/{organizationId}" example="get-client-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

GetClientRequest req = new GetClientRequest() {
    OrganizationId = "org_1234567",
    Embed = "organization",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Clients.GetAsync(req);

// handle response
```
### Example Usage: get-client-200-2

<!-- UsageSnippet language="csharp" operationID="get-client" method="get" path="/v2/clients/{organizationId}" example="get-client-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

GetClientRequest req = new GetClientRequest() {
    OrganizationId = "org_1234567",
    Embed = "organization",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Clients.GetAsync(req);

// handle response
```
### Example Usage: get-client-200-3

<!-- UsageSnippet language="csharp" operationID="get-client" method="get" path="/v2/clients/{organizationId}" example="get-client-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

GetClientRequest req = new GetClientRequest() {
    OrganizationId = "org_1234567",
    Embed = "organization",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Clients.GetAsync(req);

// handle response
```
### Example Usage: get-client-200-4

<!-- UsageSnippet language="csharp" operationID="get-client" method="get" path="/v2/clients/{organizationId}" example="get-client-200-4" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

GetClientRequest req = new GetClientRequest() {
    OrganizationId = "org_1234567",
    Embed = "organization",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Clients.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                     | Type                                                          | Required                                                      | Description                                                   |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| `request`                                                     | [GetClientRequest](../../Models/Requests/GetClientRequest.md) | :heavy_check_mark:                                            | The request object to use for the request.                    |

### Response

**[GetClientResponse](../../Models/Requests/GetClientResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |