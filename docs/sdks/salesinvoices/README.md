# SalesInvoices
(*SalesInvoices*)

## Overview

### Available Operations

* [Create](#create) - Create sales invoice
* [List](#list) - List sales invoices
* [Get](#get) - Get sales invoice
* [Update](#update) - Update sales invoice
* [Delete](#delete) - Delete sales invoice

## Create

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

With the Sales Invoice API you can generate sales invoices to send to your customers.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **sales-invoices.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateSalesInvoiceRequest req = new CreateSalesInvoiceRequest() {
    Testmode = false,
    ProfileId = "pfl_QkEhN94Ba",
    Status = "draft",
    Memo = "This is a memo!",
    PaymentDetails = new CreateSalesInvoicePaymentDetailsRequest() {
        Source = "payment-link",
        SourceReference = "pl_d9fQur83kFdhH8hIhaZfq",
    },
    EmailDetails = new CreateSalesInvoiceEmailDetailsRequest() {
        Subject = "Your invoice is available",
        Body = "Please find your invoice enclosed.",
    },
    CustomerId = "cst_8wmqcHMN4U",
    MandateId = "mdt_pWUnw6pkBN",
    RecipientIdentifier = "customer-xyz-0123",
    Recipient = new CreateSalesInvoiceRecipientRequest() {
        Type = "consumer",
        Title = "Mrs.",
        GivenName = "Jane",
        FamilyName = "Doe",
        OrganizationName = "Organization Corp.",
        OrganizationNumber = "12345678",
        VatNumber = "NL123456789B01",
        Email = "example@email.com",
        Phone = "+0123456789",
        StreetAndNumber = "Keizersgracht 126",
        StreetAdditional = "4th floor",
        PostalCode = "5678AB",
        City = "Amsterdam",
        Region = "Noord-Holland",
        Country = "NL",
        Locale = "nl_NL",
    },
    Lines = new List<CreateSalesInvoiceLineRequest>() {},
    Discount = new CreateSalesInvoiceDiscountRequest() {
        Type = "amount",
        Value = "10.00",
    },
};

var res = await sdk.SalesInvoices.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [CreateSalesInvoiceRequest](../../Models/Requests/CreateSalesInvoiceRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[CreateSalesInvoiceResponse](../../Models/Requests/CreateSalesInvoiceResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| MollieApi.Models.Errors.CreateSalesInvoiceNotFoundHalJSONException            | 404                                                                           | application/hal+json                                                          |
| MollieApi.Models.Errors.CreateSalesInvoiceUnprocessableEntityHalJSONException | 422                                                                           | application/hal+json                                                          |
| MollieApi.Models.Errors.APIException                                          | 4XX, 5XX                                                                      | \*/\*                                                                         |

## List

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieve a list of all sales invoices created through the API.

The results are paginated.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **sales-invoices.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.SalesInvoices.ListAsync(
    fromP: "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    limit: 50,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `From`                                                                                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the result set.                                                                                                                                                                                                                                                         | invoice_4Y0eZitmBnQ6IDoMqZQKh                                                                                                                                                                                                                                                                                                                                                          |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | The maximum number of items to return. Defaults to 50 items.                                                                                                                                                                                                                                                                                                                           | 50                                                                                                                                                                                                                                                                                                                                                                                     |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[ListSalesInvoicesResponse](../../Models/Requests/ListSalesInvoicesResponse.md)**

### Errors

| Error Type                                                | Status Code                                               | Content Type                                              |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| MollieApi.Models.Errors.ListSalesInvoicesHalJSONException | 400                                                       | application/hal+json                                      |
| MollieApi.Models.Errors.APIException                      | 4XX, 5XX                                                  | \*/\*                                                     |

## Get

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieve a single sales invoice by its ID.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **sales-invoice.read**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.SalesInvoices.GetAsync(
    id: "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Id`                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the item you want to perform this operation on.                                                                                                                                                                                                                                                                                                                      | invoice_4Y0eZitmBnQ6IDoMqZQKh                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetSalesInvoiceResponse](../../Models/Requests/GetSalesInvoiceResponse.md)**

### Errors

| Error Type                                              | Status Code                                             | Content Type                                            |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| MollieApi.Models.Errors.GetSalesInvoiceHalJSONException | 404                                                     | application/hal+json                                    |
| MollieApi.Models.Errors.APIException                    | 4XX, 5XX                                                | \*/\*                                                   |

## Update

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Certain details of an existing sales invoice can be updated. For `draft` it is all values listed below, but for statuses `paid` and `issued` there are certain additional requirements (`paymentDetails` and `emailDetails`, respectively).

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **sales-invoices.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.SalesInvoices.UpdateAsync(
    id: "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    requestBody: new UpdateSalesInvoiceRequestBody() {
        Testmode = false,
        Status = "paid",
        Memo = "An updated memo!",
        PaymentDetails = new UpdateSalesInvoicePaymentDetailsRequest() {
            Source = "payment-link",
            SourceReference = "pl_d9fQur83kFdhH8hIhaZfq",
        },
        EmailDetails = new UpdateSalesInvoiceEmailDetailsRequest() {
            Subject = "Your invoice is available",
            Body = "Please find your invoice enclosed.",
        },
        RecipientIdentifier = "customer-xyz-0123",
        Recipient = new UpdateSalesInvoiceRecipientRequest() {
            Type = "consumer",
            Title = "Mrs.",
            GivenName = "Jane",
            FamilyName = "Doe",
            OrganizationName = "Organization Corp.",
            OrganizationNumber = "12345678",
            VatNumber = "NL123456789B01",
            Email = "example@email.com",
            Phone = "+0123456789",
            StreetAndNumber = "Keizersgracht 126",
            StreetAdditional = "4th floor",
            PostalCode = "5678AB",
            City = "Amsterdam",
            Region = "Noord-Holland",
            Country = "NL",
            Locale = "nl_NL",
        },
        Lines = new List<UpdateSalesInvoiceLineRequest>() {
            new UpdateSalesInvoiceLineRequest() {
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                VatRate = "21.00",
                UnitPrice = new UpdateSalesInvoiceUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Discount = new UpdateSalesInvoiceLineDiscountRequest() {
                    Type = "amount",
                    Value = "10.00",
                },
            },
        },
        Discount = new UpdateSalesInvoiceDiscountRequest() {
            Type = "amount",
            Value = "10.00",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `Id`                                                                                    | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the item you want to perform this operation on.                       | invoice_4Y0eZitmBnQ6IDoMqZQKh                                                           |
| `RequestBody`                                                                           | [UpdateSalesInvoiceRequestBody](../../Models/Requests/UpdateSalesInvoiceRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[UpdateSalesInvoiceResponse](../../Models/Requests/UpdateSalesInvoiceResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| MollieApi.Models.Errors.UpdateSalesInvoiceNotFoundHalJSONException            | 404                                                                           | application/hal+json                                                          |
| MollieApi.Models.Errors.UpdateSalesInvoiceUnprocessableEntityHalJSONException | 422                                                                           | application/hal+json                                                          |
| MollieApi.Models.Errors.APIException                                          | 4XX, 5XX                                                                      | \*/\*                                                                         |

## Delete

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Sales invoices which are in status `draft` can be deleted. For all other statuses, please use the [Update sales invoice](update-sales-invoice) endpoint instead.

> 🔑 Access with
>
> [API key](/reference/authentication)
>
> [Access token with **sales-invoices.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.SalesInvoices.DeleteAsync(
    id: "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    requestBody: new DeleteSalesInvoiceRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `Id`                                                                                    | *string*                                                                                | :heavy_check_mark:                                                                      | Provide the ID of the item you want to perform this operation on.                       | invoice_4Y0eZitmBnQ6IDoMqZQKh                                                           |
| `RequestBody`                                                                           | [DeleteSalesInvoiceRequestBody](../../Models/Requests/DeleteSalesInvoiceRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |                                                                                         |

### Response

**[DeleteSalesInvoiceResponse](../../Models/Requests/DeleteSalesInvoiceResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| MollieApi.Models.Errors.DeleteSalesInvoiceNotFoundHalJSONException            | 404                                                                           | application/hal+json                                                          |
| MollieApi.Models.Errors.DeleteSalesInvoiceUnprocessableEntityHalJSONException | 422                                                                           | application/hal+json                                                          |
| MollieApi.Models.Errors.APIException                                          | 4XX, 5XX                                                                      | \*/\*                                                                         |