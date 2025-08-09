# Webhooks
(*Webhooks*)

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

<!-- UsageSnippet language="csharp" operationID="create-webhook" method="post" path="/webhooks" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateWebhookRequest req = new CreateWebhookRequest() {
    Name = "Webhook #1",
    Url = "https://mollie.com/",
    EventTypes = CreateWebhookEventTypes.PaymentLinkPaid,
    Testmode = false,
};

var res = await sdk.Webhooks.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [CreateWebhookRequest](../../Models/Requests/CreateWebhookRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[CreateWebhookResponse](../../Models/Requests/CreateWebhookResponse.md)**

### Errors

| Error Type                                         | Status Code                                        | Content Type                                       |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| Mollie.Models.Errors.CreateWebhookHalJSONException | 422                                                | application/hal+json                               |
| Mollie.Models.Errors.APIException                  | 4XX, 5XX                                           | \*/\*                                              |

## List

Returns a paginated list of your webhooks. If no webhook endpoints are available, the resulting array will be empty. This request should never throw an error.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-webhooks" method="get" path="/webhooks" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListWebhooksRequest req = new ListWebhooksRequest() {
    From = "hook_B2EyhTH5N4KWUnoYPcgiH",
    Limit = 50,
    Sort = ListWebhooksSort.Desc,
    EventTypes = ListWebhooksEventTypes.PaymentLinkPaid,
    Testmode = false,
};

var res = await sdk.Webhooks.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListWebhooksRequest](../../Models/Requests/ListWebhooksRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListWebhooksResponse](../../Models/Requests/ListWebhooksResponse.md)**

### Errors

| Error Type                                        | Status Code                                       | Content Type                                      |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| Mollie.Models.Errors.ListWebhooksHalJSONException | 400                                               | application/hal+json                              |
| Mollie.Models.Errors.APIException                 | 4XX, 5XX                                          | \*/\*                                             |

## Update

Updates the webhook. You may edit the name, url and the list of subscribed event types.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-webhook" method="patch" path="/webhooks/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Webhooks.UpdateAsync(
    id: "hook_B2EyhTH5N4KWUnoYPcgiH",
    requestBody: new UpdateWebhookRequestBody() {
        Name = "Webhook #1",
        Url = "https://mollie.com/",
        EventTypes = UpdateWebhookEventTypes.PaymentLinkPaid,
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `Id`                                                                          | *string*                                                                      | :heavy_check_mark:                                                            | Provide the ID of the item you want to perform this operation on.             | hook_B2EyhTH5N4KWUnoYPcgiH                                                    |
| `RequestBody`                                                                 | [UpdateWebhookRequestBody](../../Models/Requests/UpdateWebhookRequestBody.md) | :heavy_minus_sign:                                                            | N/A                                                                           |                                                                               |

### Response

**[UpdateWebhookResponse](../../Models/Requests/UpdateWebhookResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Mollie.Models.Errors.UpdateWebhookNotFoundHalJSONException            | 404                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.UpdateWebhookUnprocessableEntityHalJSONException | 422                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.APIException                                     | 4XX, 5XX                                                              | \*/\*                                                                 |

## Get

Retrieve a single webhook object by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-webhook" method="get" path="/webhooks/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Webhooks.GetAsync(
    id: "hook_B2EyhTH5N4KWUnoYPcgiH",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Id`                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the item you want to perform this operation on.                                                                                                                                                                                                                                                                                                                      | hook_B2EyhTH5N4KWUnoYPcgiH                                                                                                                                                                                                                                                                                                                                                             |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetWebhookResponse](../../Models/Requests/GetWebhookResponse.md)**

### Errors

| Error Type                                                         | Status Code                                                        | Content Type                                                       |
| ------------------------------------------------------------------ | ------------------------------------------------------------------ | ------------------------------------------------------------------ |
| Mollie.Models.Errors.GetWebhookNotFoundHalJSONException            | 404                                                                | application/hal+json                                               |
| Mollie.Models.Errors.GetWebhookUnprocessableEntityHalJSONException | 422                                                                | application/hal+json                                               |
| Mollie.Models.Errors.APIException                                  | 4XX, 5XX                                                           | \*/\*                                                              |

## Delete

Delete a single webhook object by its webhook ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-webhook" method="delete" path="/webhooks/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Webhooks.DeleteAsync(
    id: "hook_B2EyhTH5N4KWUnoYPcgiH",
    requestBody: new DeleteWebhookRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `Id`                                                                          | *string*                                                                      | :heavy_check_mark:                                                            | Provide the ID of the item you want to perform this operation on.             | hook_B2EyhTH5N4KWUnoYPcgiH                                                    |
| `RequestBody`                                                                 | [DeleteWebhookRequestBody](../../Models/Requests/DeleteWebhookRequestBody.md) | :heavy_minus_sign:                                                            | N/A                                                                           |                                                                               |

### Response

**[DeleteWebhookResponse](../../Models/Requests/DeleteWebhookResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Mollie.Models.Errors.DeleteWebhookNotFoundHalJSONException            | 404                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.DeleteWebhookUnprocessableEntityHalJSONException | 422                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.APIException                                     | 4XX, 5XX                                                              | \*/\*                                                                 |

## Test

Sends a test event to the webhook to verify the endpoint is working as expected.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="test-webhook" method="post" path="/webhooks/{id}/ping" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Webhooks.TestAsync(
    id: "hook_B2EyhTH5N4KWUnoYPcgiH",
    requestBody: new TestWebhookRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `Id`                                                                      | *string*                                                                  | :heavy_check_mark:                                                        | Provide the ID of the item you want to perform this operation on.         | hook_B2EyhTH5N4KWUnoYPcgiH                                                |
| `RequestBody`                                                             | [TestWebhookRequestBody](../../Models/Requests/TestWebhookRequestBody.md) | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |

### Response

**[TestWebhookResponse](../../Models/Requests/TestWebhookResponse.md)**

### Errors

| Error Type                                                          | Status Code                                                         | Content Type                                                        |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| Mollie.Models.Errors.TestWebhookNotFoundHalJSONException            | 404                                                                 | application/hal+json                                                |
| Mollie.Models.Errors.TestWebhookUnprocessableEntityHalJSONException | 422                                                                 | application/hal+json                                                |
| Mollie.Models.Errors.APIException                                   | 4XX, 5XX                                                            | \*/\*                                                               |