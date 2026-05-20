# Sessions

## Overview

### Available Operations

* [Create](#create) - Create session
* [Get](#get) - Get session

## Create

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change.

Create a session to start a checkout process with Mollie Components.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-session" method="post" path="/v2/sessions" example="create-session-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Sessions.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    sessionRequest: new SessionRequest() {
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Order #12345",
        Lines = new List<SessionLineItem>() {},
        RedirectUrl = "https://example.org/redirect",
        BillingAddress = new PaymentAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        ShippingAddress = new PaymentAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
            OrganizationName = "Mollie B.V.",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "Apt. 1",
            PostalCode = "1234AB",
            Email = "piet@example.org",
            Phone = "31208202070",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
        },
        CustomerId = "cst_5B8cwPMGnU",
        SequenceType = SessionSequenceType.Oneoff,
        Payment = new SessionRequestPayment() {
            WebhookUrl = "https://example.org/webhook",
        },
        ProfileId = "pfl_5B8cwPMGnU",
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `SessionRequest`                                                                 | [SessionRequest](../../Models/Components/SessionRequest.md)                      | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[CreateSessionResponse](../../Models/Requests/CreateSessionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change.

Retrieve a session to view its details and status to inform your customers about the checkout process.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-session" method="get" path="/v2/sessions/{sessionId}" example="get-session-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Sessions.GetAsync(
    sessionId: "sess_82jFYDTrLcCQV68NLDvMJ",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `SessionId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related session.                                           | sess_82jFYDTrLcCQV68NLDvMJ                                                       |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetSessionResponse](../../Models/Requests/GetSessionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 429                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |