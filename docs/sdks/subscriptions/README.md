# Subscriptions

## Overview

### Available Operations

* [Create](#create) - Create subscription
* [List](#list) - List customer subscriptions
* [Get](#get) - Get subscription
* [Update](#update) - Update subscription
* [Cancel](#cancel) - Cancel subscription
* [All](#all) - List all subscriptions
* [ListPayments](#listpayments) - List subscription payments

## Create

With subscriptions, you can schedule recurring payments to take place at regular intervals.

For example, by simply specifying an `amount` and an `interval`, you can create an endless subscription to charge a
monthly fee, until you cancel the subscription.

Or, you could use the times parameter to only charge a limited number of times, for example to split a big
transaction in multiple parts.

A few example usages:

`amount[currency]="EUR"` `amount[value]="5.00"` `interval="2 weeks"`
Your customer will be charged €5 once every two weeks.

`amount[currency]="EUR"` `amount[value]="20.00"` `interval="1 day" times=5`
Your customer will be charged €20 every day, for five consecutive days.

`amount[currency]="EUR"` `amount[value]="10.00"` `interval="1 month"`
`startDate="2018-04-30"`
Your customer will be charged €10 on the last day of each month, starting in April 2018.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-subscription" method="post" path="/customers/{customerId}/subscriptions" example="get-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Subscriptions.CreateAsync(
    customerId: "cst_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    subscriptionRequest: new SubscriptionRequest() {
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Times = 6,
        Interval = "2 days",
        StartDate = "2025-01-01",
        Description = "Subscription of streaming channel",
        Method = SubscriptionMethod.Paypal,
        ApplicationFee = new SubscriptionRequestApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "Platform fee",
        },
        WebhookUrl = "https://example.com/webhook",
        MandateId = "mdt_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `CustomerId`                                                                     | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related customer.                                          | cst_5B8cwPMGnU                                                                   |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `SubscriptionRequest`                                                            | [SubscriptionRequest](../../Models/Components/SubscriptionRequest.md)            | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

### Response

**[CreateSubscriptionResponse](../../Models/Requests/CreateSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve all subscriptions of a customer.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-subscriptions" method="get" path="/customers/{customerId}/subscriptions" example="list-subscriptions-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSubscriptionsRequest req = new ListSubscriptionsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    From = "sub_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Subscriptions.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [ListSubscriptionsRequest](../../Models/Requests/ListSubscriptionsRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[ListSubscriptionsResponse](../../Models/Requests/ListSubscriptionsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single subscription by its ID and the ID of its parent customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-subscription" method="get" path="/customers/{customerId}/subscriptions/{subscriptionId}" example="get-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Subscriptions.GetAsync(
    customerId: "cst_5B8cwPMGnU",
    subscriptionId: "sub_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `CustomerId`                                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the related customer.                                                                                                                                                                                                                                                                                                                                                  | cst_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                           |
| `SubscriptionId`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the related subscription.                                                                                                                                                                                                                                                                                                                                              | sub_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                           |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

### Response

**[GetSubscriptionResponse](../../Models/Requests/GetSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Update an existing subscription.

Canceled subscriptions cannot be updated.

For an in-depth explanation of each parameter, refer to the [Create subscription](create-subscription) endpoint.

### Example Usage: update-subscription-200-1

<!-- UsageSnippet language="csharp" operationID="update-subscription" method="patch" path="/customers/{customerId}/subscriptions/{subscriptionId}" example="update-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Subscriptions.UpdateAsync(
    customerId: "cst_5B8cwPMGnU",
    subscriptionId: "sub_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new UpdateSubscriptionRequestBody() {
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Subscription of streaming channel",
        Interval = "1 months",
        StartDate = "2025-01-01",
        Times = 6,
        WebhookUrl = "https://example.com/webhook",
        MandateId = "mdt_5B8cwPMGnU",
        Testmode = false,
    }
);

// handle response
```
### Example Usage: update-subscription-200-2

<!-- UsageSnippet language="csharp" operationID="update-subscription" method="patch" path="/customers/{customerId}/subscriptions/{subscriptionId}" example="update-subscription-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Subscriptions.UpdateAsync(
    customerId: "cst_5B8cwPMGnU",
    subscriptionId: "sub_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new UpdateSubscriptionRequestBody() {
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        Description = "Subscription of streaming channel",
        Interval = "1 months",
        StartDate = "2025-01-01",
        Times = 6,
        WebhookUrl = "https://example.com/webhook",
        MandateId = "mdt_5B8cwPMGnU",
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `CustomerId`                                                                            | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the related customer.                                                 | cst_5B8cwPMGnU                                                                          |
| `SubscriptionId`                                                                        | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the related subscription.                                             | sub_5B8cwPMGnU                                                                          |
| `IdempotencyKey`                                                                        | *string*                                                                                | :heavy_minus_sign:                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.        | 123e4567-e89b-12d3-a456-426                                                             |
| `RequestBody`                                                                           | [UpdateSubscriptionRequestBody](../../Models/Requests/UpdateSubscriptionRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[UpdateSubscriptionResponse](../../Models/Requests/UpdateSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Cancel

Cancel an existing subscription. Canceling a subscription has no effect on the mandates of the customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-subscription" method="delete" path="/customers/{customerId}/subscriptions/{subscriptionId}" example="cancel-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Subscriptions.CancelAsync(
    customerId: "cst_5B8cwPMGnU",
    subscriptionId: "sub_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new CancelSubscriptionRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `CustomerId`                                                                            | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the related customer.                                                 | cst_5B8cwPMGnU                                                                          |
| `SubscriptionId`                                                                        | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the related subscription.                                             | sub_5B8cwPMGnU                                                                          |
| `IdempotencyKey`                                                                        | *string*                                                                                | :heavy_minus_sign:                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.        | 123e4567-e89b-12d3-a456-426                                                             |
| `RequestBody`                                                                           | [CancelSubscriptionRequestBody](../../Models/Requests/CancelSubscriptionRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[CancelSubscriptionResponse](../../Models/Requests/CancelSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## All

Retrieve all subscriptions initiated across all your customers.

The results are paginated.

### Example Usage: list-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/subscriptions" example="list-payments-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllSubscriptionsRequest req = new ListAllSubscriptionsRequest() {
    From = "tr_5B8cwPMGnU",
    Limit = 50,
};

var res = await sdk.Subscriptions.AllAsync(req);

// handle response
```
### Example Usage: list-payments-200-2

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/subscriptions" example="list-payments-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllSubscriptionsRequest req = new ListAllSubscriptionsRequest() {
    From = "tr_5B8cwPMGnU",
    Limit = 50,
};

var res = await sdk.Subscriptions.AllAsync(req);

// handle response
```
### Example Usage: list-payments-200-3

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/subscriptions" example="list-payments-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllSubscriptionsRequest req = new ListAllSubscriptionsRequest() {
    From = "tr_5B8cwPMGnU",
    Limit = 50,
};

var res = await sdk.Subscriptions.AllAsync(req);

// handle response
```
### Example Usage: list-subscriptions-200-1

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/subscriptions" example="list-subscriptions-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllSubscriptionsRequest req = new ListAllSubscriptionsRequest() {
    From = "sub_rVKGtNd6s3",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Subscriptions.AllAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [ListAllSubscriptionsRequest](../../Models/Requests/ListAllSubscriptionsRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[ListAllSubscriptionsResponse](../../Models/Requests/ListAllSubscriptionsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListPayments

Retrieve all payments of a specific subscription.

The results are paginated.

### Example Usage: list-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-subscription-payments" method="get" path="/customers/{customerId}/subscriptions/{subscriptionId}/payments" example="list-payments-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSubscriptionPaymentsRequest req = new ListSubscriptionPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Subscriptions.ListPaymentsAsync(req);

// handle response
```
### Example Usage: list-payments-200-2

<!-- UsageSnippet language="csharp" operationID="list-subscription-payments" method="get" path="/customers/{customerId}/subscriptions/{subscriptionId}/payments" example="list-payments-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSubscriptionPaymentsRequest req = new ListSubscriptionPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Subscriptions.ListPaymentsAsync(req);

// handle response
```
### Example Usage: list-payments-200-3

<!-- UsageSnippet language="csharp" operationID="list-subscription-payments" method="get" path="/customers/{customerId}/subscriptions/{subscriptionId}/payments" example="list-payments-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListSubscriptionPaymentsRequest req = new ListSubscriptionPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Subscriptions.ListPaymentsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [ListSubscriptionPaymentsRequest](../../Models/Requests/ListSubscriptionPaymentsRequest.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |

### Response

**[ListSubscriptionPaymentsResponse](../../Models/Requests/ListSubscriptionPaymentsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |