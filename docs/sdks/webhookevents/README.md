# WebhookEvents

## Overview

### Available Operations

* [Get](#get) - Get a Webhook Event

## Get

Retrieve a single webhook event object by its event ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-webhook-event" method="get" path="/events/{webhookEventId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.WebhookEvents.GetAsync(
    webhookEventId: "event_1234567890",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                               | Type                                                                                                                                                                    | Required                                                                                                                                                                | Description                                                                                                                                                             | Example                                                                                                                                                                 |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `WebhookEventId`                                                                                                                                                        | *string*                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                      | Provide the ID of the related webhook event.                                                                                                                            | event_1234567890                                                                                                                                                        |
| `Testmode`                                                                                                                                                              | *bool*                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                      | You can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                         |
| `IdempotencyKey`                                                                                                                                                        | *string*                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                             |

### Response

**[GetWebhookEventResponse](../../Models/Requests/GetWebhookEventResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |