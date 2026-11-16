# Webhooks

## Overview

### Available Operations

* [Create](#create) - Create a webhook
* [List](#list) - List all webhooks
* [Update](#update) - Update a webhook
* [Get](#get) - Get a webhook
* [Delete](#delete) - Delete a webhook
* [Test](#test) - Test a webhook

## Create

A webhook must have a name, an url and a list of event types. You can also create webhooks in the webhooks settings section of the Dashboard.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-webhook" method="post" path="/v2/webhooks" example="create-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Webhooks.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z",
    requestBody: new CreateWebhookRequestBody() {
        Name = "Webhook #1",
        Url = "https://mollie.com/",
        EventTypesList = EventTypesList.CreateWebhookEventTypes(
            WebhookEventTypes.PaymentLinkPaid
        ),
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |
| `RequestBody`                                                                                                                                                                           | [CreateWebhookRequestBody](../../Models/Requests/CreateWebhookRequestBody.md)                                                                                                           | :heavy_minus_sign:                                                                                                                                                                      | N/A                                                                                                                                                                                     |                                                                                                                                                                                         |

### Response

**[CreateWebhookResponse](../../Models/Requests/CreateWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Returns a paginated list of your webhooks. If no webhook endpoints are available, the resulting array will be empty. This request should never throw an error.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-webhooks" method="get" path="/v2/webhooks" example="list-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListWebhooksRequest req = new ListWebhooksRequest() {
    From = "hook_B2EyhTH5N4KWUnoYPcgiH",
    Limit = 50,
    Sort = Sorting.Desc,
    EventTypes = WebhookEventTypes.PaymentLinkPaid,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListWebhooksResponse? res = await sdk.Webhooks.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListWebhooksRequest](../../Models/Requests/ListWebhooksRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListWebhooksResponse](../../Models/Requests/ListWebhooksResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Updates the webhook. You may edit the name, url and the list of subscribed event types.

### Example Usage: create-webhook-200

<!-- UsageSnippet language="csharp" operationID="update-webhook" method="patch" path="/v2/webhooks/{webhookId}" example="create-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateWebhookRequest req = new UpdateWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    RequestBody = new UpdateWebhookRequestBody() {
        Name = "Webhook #1",
        Url = "https://mollie.com/",
        EventTypes = EventTypes.CreateWebhookEventTypes(
            WebhookEventTypes.PaymentLinkPaid
        ),
        Testmode = false,
    },
};

var res = await sdk.Webhooks.UpdateAsync(req);

// handle response
```
### Example Usage: get-webhook-200

<!-- UsageSnippet language="csharp" operationID="update-webhook" method="patch" path="/v2/webhooks/{webhookId}" example="get-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateWebhookRequest req = new UpdateWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdateWebhookRequestBody() {
        Name = "Webhook #1",
        Url = "https://mollie.com/",
        EventTypes = EventTypes.CreateWebhookEventTypes(
            WebhookEventTypes.PaymentLinkPaid
        ),
        Testmode = false,
    },
};

var res = await sdk.Webhooks.UpdateAsync(req);

// handle response
```
### Example Usage: get-webhook-200-1

<!-- UsageSnippet language="csharp" operationID="update-webhook" method="patch" path="/v2/webhooks/{webhookId}" example="get-webhook-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateWebhookRequest req = new UpdateWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdateWebhookRequestBody() {
        Name = "Webhook #1",
        Url = "https://mollie.com/",
        EventTypes = EventTypes.CreateWebhookEventTypes(
            WebhookEventTypes.PaymentLinkPaid
        ),
        Testmode = false,
    },
};

var res = await sdk.Webhooks.UpdateAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [UpdateWebhookRequest](../../Models/Requests/UpdateWebhookRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[UpdateWebhookResponse](../../Models/Requests/UpdateWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single webhook object by its ID.

### Example Usage: get-webhook-200

<!-- UsageSnippet language="csharp" operationID="get-webhook" method="get" path="/v2/webhooks/{webhookId}" example="get-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetWebhookRequest req = new GetWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Webhooks.GetAsync(req);

// handle response
```
### Example Usage: get-webhook-200-1

<!-- UsageSnippet language="csharp" operationID="get-webhook" method="get" path="/v2/webhooks/{webhookId}" example="get-webhook-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetWebhookRequest req = new GetWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Webhooks.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [GetWebhookRequest](../../Models/Requests/GetWebhookRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[GetWebhookResponse](../../Models/Requests/GetWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Delete

Delete a single webhook object by its webhook ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-webhook" method="delete" path="/v2/webhooks/{webhookId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

DeleteWebhookRequest req = new DeleteWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new DeleteWebhookRequestBody() {
        Testmode = false,
    },
};

var res = await sdk.Webhooks.DeleteAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [DeleteWebhookRequest](../../Models/Requests/DeleteWebhookRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[DeleteWebhookResponse](../../Models/Requests/DeleteWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Test

Sends a test event to the webhook to verify the endpoint is working as expected.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="test-webhook" method="post" path="/v2/webhooks/{webhookId}/ping" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

TestWebhookRequest req = new TestWebhookRequest() {
    WebhookId = "hook_1234567890",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new TestWebhookRequestBody() {
        Testmode = false,
    },
};

var res = await sdk.Webhooks.TestAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [TestWebhookRequest](../../Models/Requests/TestWebhookRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[TestWebhookResponse](../../Models/Requests/TestWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |