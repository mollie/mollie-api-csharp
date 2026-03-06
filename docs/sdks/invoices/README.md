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

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/invoices" example="list-invoices-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Invoices.ListAsync(req);

// handle response
```
### Example Usage: list-invoices-200-2

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/invoices" example="list-invoices-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Invoices.ListAsync(req);

// handle response
```
### Example Usage: list-invoices-200-3

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/invoices" example="list-invoices-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Invoices.ListAsync(req);

// handle response
```
### Example Usage: list-invoices-200-4

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/invoices" example="list-invoices-200-4" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    From = "inv_xBEbP9rvAq",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Invoices.ListAsync(req);

// handle response
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
| Mollie.Models.Errors.ErrorResponse | 400, 404                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single invoice by its ID.

If you want to retrieve the details of an invoice by its invoice number,
call the [List invoices](list-invoices) endpoint with the `reference` parameter.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-invoice" method="get" path="/invoices/{invoiceId}" example="get-invoice-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

var res = await sdk.Invoices.GetAsync(
    invoiceId: "inv_aHbjjdrUdm",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `InvoiceId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related invoice.                                           | inv_aHbjjdrUdm                                                                   |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetInvoiceResponse](../../Models/Requests/GetInvoiceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |