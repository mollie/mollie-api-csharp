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

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `RequestBody`                                                                    | [CreateWebhookRequestBody](../../Models/Requests/CreateWebhookRequestBody.md)    | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[CreateWebhookResponse](../../Models/Requests/CreateWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422                                | application/hal+json               |
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
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Updates the webhook. You may edit the name, url and the list of subscribed event types.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-webhook" method="patch" path="/v2/webhooks/{webhookId}" example="create-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Webhooks.UpdateAsync(
    webhookId: "hook_1234567890",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new UpdateWebhookRequestBody() {
        Name = "Webhook #1",
        Url = "https://mollie.com/",
        EventTypes = EventTypes.CreateWebhookEventTypes(
            WebhookEventTypes.PaymentLinkPaid
        ),
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `WebhookId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related webhook.                                           | hook_1234567890                                                                  |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `RequestBody`                                                                    | [UpdateWebhookRequestBody](../../Models/Requests/UpdateWebhookRequestBody.md)    | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[UpdateWebhookResponse](../../Models/Requests/UpdateWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single webhook object by its ID.

### Example Usage: get-webhook-200

<!-- UsageSnippet language="csharp" operationID="get-webhook" method="get" path="/v2/webhooks/{webhookId}" example="get-webhook-200" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Webhooks.GetAsync(
    webhookId: "hook_1234567890",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: get-webhook-200-1

<!-- UsageSnippet language="csharp" operationID="get-webhook" method="get" path="/v2/webhooks/{webhookId}" example="get-webhook-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Webhooks.GetAsync(
    webhookId: "hook_1234567890",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                               | Type                                                                                                                                                                    | Required                                                                                                                                                                | Description                                                                                                                                                             | Example                                                                                                                                                                 |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `WebhookId`                                                                                                                                                             | *string*                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                      | Provide the ID of the related webhook.                                                                                                                                  | hook_1234567890                                                                                                                                                         |
| `Testmode`                                                                                                                                                              | *bool*                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                      | You can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                         |
| `IdempotencyKey`                                                                                                                                                        | *string*                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                             |

### Response

**[GetWebhookResponse](../../Models/Requests/GetWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
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

var res = await sdk.Webhooks.DeleteAsync(
    webhookId: "hook_1234567890",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new DeleteWebhookRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `WebhookId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related webhook.                                           | hook_1234567890                                                                  |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `RequestBody`                                                                    | [DeleteWebhookRequestBody](../../Models/Requests/DeleteWebhookRequestBody.md)    | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[DeleteWebhookResponse](../../Models/Requests/DeleteWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
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

var res = await sdk.Webhooks.TestAsync(
    webhookId: "hook_1234567890",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new TestWebhookRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `WebhookId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related webhook.                                           | hook_1234567890                                                                  |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `RequestBody`                                                                    | [TestWebhookRequestBody](../../Models/Requests/TestWebhookRequestBody.md)        | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[TestWebhookResponse](../../Models/Requests/TestWebhookResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |