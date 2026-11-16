# Mandates

## Overview

### Available Operations

* [Create](#create) - Create mandate
* [List](#list) - List mandates
* [Get](#get) - Get mandate
* [Revoke](#revoke) - Revoke mandate

## Create

Create a mandate for a specific customer. Mandates allow you to charge a customer's card, PayPal account or bank
account recurrently.

It is only possible to create mandates for IBANs and PayPal billing agreements with this endpoint. To create
mandates for cards, your customers need to perform a 'first payment' with their card.

### Example Usage: create-mandate-201-1

<!-- UsageSnippet language="csharp" operationID="create-mandate" method="post" path="/v2/customers/{customerId}/mandates" example="create-mandate-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateMandateRequest req = new CreateMandateRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    MandateRequest = new MandateRequest() {
        Id = "mdt_5B8cwPMGnU",
        Method = MandateMethod.Directdebit,
        ConsumerName = "John Doe",
        ConsumerAccount = "NL55INGB0000000000",
        ConsumerBic = "BANKBIC",
        ConsumerEmail = "example@email.com",
        SignatureDate = "2025-01-01",
        MandateReference = "ID-1023892",
        PaypalBillingAgreementId = "B-12A34567B8901234CD",
        PayPalVaultId = "8kk8451t",
        Testmode = false,
    },
};

var res = await sdk.Mandates.CreateAsync(req);

// handle response
```
### Example Usage: create-mandate-201-2

<!-- UsageSnippet language="csharp" operationID="create-mandate" method="post" path="/v2/customers/{customerId}/mandates" example="create-mandate-201-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateMandateRequest req = new CreateMandateRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    MandateRequest = new MandateRequest() {
        Id = "mdt_5B8cwPMGnU",
        Method = MandateMethod.Directdebit,
        ConsumerName = "John Doe",
        ConsumerAccount = "NL55INGB0000000000",
        ConsumerBic = "BANKBIC",
        ConsumerEmail = "example@email.com",
        SignatureDate = "2025-01-01",
        MandateReference = "ID-1023892",
        PaypalBillingAgreementId = "B-12A34567B8901234CD",
        PayPalVaultId = "8kk8451t",
        Testmode = false,
    },
};

var res = await sdk.Mandates.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [CreateMandateRequest](../../Models/Requests/CreateMandateRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[CreateMandateResponse](../../Models/Requests/CreateMandateResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all mandates.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-mandates" method="get" path="/v2/customers/{customerId}/mandates" example="list-mandates-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListMandatesRequest req = new ListMandatesRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    From = "mdt_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    Scopes = new List<MandateScopes>() {
        MandateScopes.CustomerPresent,
    },
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListMandatesResponse? res = await sdk.Mandates.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListMandatesRequest](../../Models/Requests/ListMandatesRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListMandatesResponse](../../Models/Requests/ListMandatesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single mandate by its ID. Depending on the type of mandate, the object will contain the customer's bank
account details, card details, or PayPal account details.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-mandate" method="get" path="/v2/customers/{customerId}/mandates/{mandateId}" example="get-mandate-200-1" -->
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

GetMandateRequest req = new GetMandateRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    MandateId = "mdt_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Mandates.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [GetMandateRequest](../../Models/Requests/GetMandateRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[GetMandateResponse](../../Models/Requests/GetMandateResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Revoke

Revoke a customer's mandate. You will no longer be able to charge the customer's bank account or card with this
mandate, and all connected subscriptions will be canceled.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="revoke-mandate" method="delete" path="/v2/customers/{customerId}/mandates/{mandateId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

RevokeMandateRequest req = new RevokeMandateRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    MandateId = "mdt_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new RevokeMandateRequestBody() {
        Testmode = false,
    },
};

var res = await sdk.Mandates.RevokeAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [RevokeMandateRequest](../../Models/Requests/RevokeMandateRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[RevokeMandateResponse](../../Models/Requests/RevokeMandateResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |