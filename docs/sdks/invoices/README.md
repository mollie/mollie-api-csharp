# Invoices

## Overview

### Available Operations

* [List](#list) - List invoices
* [Get](#get) - Get invoice

## List

Retrieve a list of all your invoices, optionally filtered by year or by
invoice reference.

The results are paginated.

### Example Usage: list-invoices-200-1

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/v2/invoices" example="list-invoices-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListInvoicesResponse? res = await sdk.Invoices.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-invoices-200-2

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/v2/invoices" example="list-invoices-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListInvoicesResponse? res = await sdk.Invoices.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-invoices-200-3

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/v2/invoices" example="list-invoices-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListInvoicesResponse? res = await sdk.Invoices.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-invoices-200-4

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/v2/invoices" example="list-invoices-200-4" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListInvoicesResponse? res = await sdk.Invoices.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListInvoicesRequest](../../Models/Requests/ListInvoicesRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListInvoicesResponse](../../Models/Requests/ListInvoicesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single invoice by its ID.

If you want to retrieve the details of an invoice by its invoice number,
call the [List invoices](list-invoices) endpoint with the `reference` parameter.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-invoice" method="get" path="/v2/invoices/{invoiceId}" example="get-invoice-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Invoices.GetAsync(
    invoiceId: "inv_aHbjjdrUdm",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `InvoiceId`                                                                                                                                                                             | *string*                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                      | Provide the ID of the related invoice.                                                                                                                                                  | inv_aHbjjdrUdm                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |

### Response

**[GetInvoiceResponse](../../Models/Requests/GetInvoiceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |