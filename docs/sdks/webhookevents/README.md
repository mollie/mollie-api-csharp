# WebhookEvents
(*WebhookEvents*)

## Overview

### Available Operations

* [Get](#get) - Get a Webhook Event

## Get

Retrieve a single webhook event object by its event ID.

> 🔑 Access with
>
> [Access token with **events.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.WebhookEvents.GetAsync(id: "event_jd9v34P5YqN9pT8n3HJyH");

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Id`                                                              | *string*                                                          | :heavy_check_mark:                                                | Provide the ID of the item you want to perform this operation on. | event_jd9v34P5YqN9pT8n3HJyH                                       |

### Response

**[GetWebhookEventResponse](../../Models/Requests/GetWebhookEventResponse.md)**

### Errors

| Error Type                                              | Status Code                                             | Content Type                                            |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| MollieApi.Models.Errors.GetWebhookEventHalJSONException | 404                                                     | application/hal+json                                    |
| MollieApi.Models.Errors.APIException                    | 4XX, 5XX                                                | \*/\*                                                   |