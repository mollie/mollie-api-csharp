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

<!-- UsageSnippet language="csharp" operationID="create-subscription" method="post" path="/v2/customers/{customerId}/subscriptions" example="get-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateSubscriptionRequest req = new CreateSubscriptionRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    SubscriptionRequest = new SubscriptionRequest() {
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
    },
};

var res = await sdk.Subscriptions.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [CreateSubscriptionRequest](../../Models/Requests/CreateSubscriptionRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[CreateSubscriptionResponse](../../Models/Requests/CreateSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve all subscriptions of a customer.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-subscriptions" method="get" path="/v2/customers/{customerId}/subscriptions" example="list-subscriptions-200-1" -->
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
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListSubscriptionsResponse? res = await sdk.Subscriptions.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
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
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single subscription by its ID and the ID of its parent customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-subscription" method="get" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}" example="get-subscription-200-1" -->
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

GetSubscriptionRequest req = new GetSubscriptionRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Subscriptions.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [GetSubscriptionRequest](../../Models/Requests/GetSubscriptionRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[GetSubscriptionResponse](../../Models/Requests/GetSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Update an existing subscription.

Canceled subscriptions cannot be updated.

For an in-depth explanation of each parameter, refer to the [Create subscription](create-subscription) endpoint.

### Example Usage: update-subscription-200-1

<!-- UsageSnippet language="csharp" operationID="update-subscription" method="patch" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}" example="update-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateSubscriptionRequest req = new UpdateSubscriptionRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdateSubscriptionRequestBody() {
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
    },
};

var res = await sdk.Subscriptions.UpdateAsync(req);

// handle response
```
### Example Usage: update-subscription-200-2

<!-- UsageSnippet language="csharp" operationID="update-subscription" method="patch" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}" example="update-subscription-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateSubscriptionRequest req = new UpdateSubscriptionRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdateSubscriptionRequestBody() {
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
    },
};

var res = await sdk.Subscriptions.UpdateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [UpdateSubscriptionRequest](../../Models/Requests/UpdateSubscriptionRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[UpdateSubscriptionResponse](../../Models/Requests/UpdateSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Cancel

Cancel an existing subscription. Canceling a subscription has no effect on the mandates of the customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="cancel-subscription" method="delete" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}" example="cancel-subscription-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CancelSubscriptionRequest req = new CancelSubscriptionRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    SubscriptionId = "sub_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new CancelSubscriptionRequestBody() {
        Testmode = false,
    },
};

var res = await sdk.Subscriptions.CancelAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [CancelSubscriptionRequest](../../Models/Requests/CancelSubscriptionRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[CancelSubscriptionResponse](../../Models/Requests/CancelSubscriptionResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## All

Retrieve all subscriptions initiated across all your customers.

The results are paginated.

### Example Usage: list-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/v2/subscriptions" example="list-payments-200-1" -->
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

ListAllSubscriptionsResponse? res = await sdk.Subscriptions.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-2

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/v2/subscriptions" example="list-payments-200-2" -->
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

ListAllSubscriptionsResponse? res = await sdk.Subscriptions.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-3

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/v2/subscriptions" example="list-payments-200-3" -->
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

ListAllSubscriptionsResponse? res = await sdk.Subscriptions.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-subscriptions-200-1

<!-- UsageSnippet language="csharp" operationID="list-all-subscriptions" method="get" path="/v2/subscriptions" example="list-subscriptions-200-1" -->
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
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListAllSubscriptionsResponse? res = await sdk.Subscriptions.AllAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
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
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## ListPayments

Retrieve all payments of a specific subscription.

The results are paginated.

### Example Usage: list-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-subscription-payments" method="get" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}/payments" example="list-payments-200-1" -->
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
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListSubscriptionPaymentsResponse? res = await sdk.Subscriptions.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-2

<!-- UsageSnippet language="csharp" operationID="list-subscription-payments" method="get" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}/payments" example="list-payments-200-2" -->
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
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListSubscriptionPaymentsResponse? res = await sdk.Subscriptions.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-3

<!-- UsageSnippet language="csharp" operationID="list-subscription-payments" method="get" path="/v2/customers/{customerId}/subscriptions/{subscriptionId}/payments" example="list-payments-200-3" -->
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
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListSubscriptionPaymentsResponse? res = await sdk.Subscriptions.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
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
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |