# Invoices
(*Invoices*)

## Overview

### Available Operations

* [List](#list) - List invoices
* [Get](#get) - Get invoice

## List

Retrieve a list of all your invoices, optionally filtered by year or by invoice reference.

The results are paginated.

> 🔑 Access with
>
> [Access token with **invoices.read**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-invoices" method="get" path="/invoices" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListInvoicesRequest req = new ListInvoicesRequest() {
    Reference = "2024.10000",
    Year = "2024",
    Month = "01",
    From = "inv_xBEbP9rvAq",
    Sort = "desc",
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

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Mollie.Models.Errors.ListInvoicesBadRequestHalJSONException | 400                                                         | application/hal+json                                        |
| Mollie.Models.Errors.ListInvoicesNotFoundHalJSONException   | 404                                                         | application/hal+json                                        |
| Mollie.Models.Errors.APIException                           | 4XX, 5XX                                                    | \*/\*                                                       |

## Get

Retrieve a single invoice by its ID.

If you want to retrieve the details of an invoice by its invoice number, call the [List invoices](list-invoices) endpoint with the `reference` parameter.

> 🔑 Access with
>
> [Access token with **invoices.read**](/reference/authentication)

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-invoice" method="get" path="/invoices/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Invoices.GetAsync(id: "inv_FrvewDA3Pr");

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Id`                                                              | *string*                                                          | :heavy_check_mark:                                                | Provide the ID of the item you want to perform this operation on. | inv_FrvewDA3Pr                                                    |

### Response

**[GetInvoiceResponse](../../Models/Requests/GetInvoiceResponse.md)**

### Errors

| Error Type                                      | Status Code                                     | Content Type                                    |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| Mollie.Models.Errors.GetInvoiceHalJSONException | 404                                             | application/hal+json                            |
| Mollie.Models.Errors.APIException               | 4XX, 5XX                                        | \*/\*                                           |