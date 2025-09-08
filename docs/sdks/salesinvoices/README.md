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

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-sales-invoice" method="post" path="/sales-invoices" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

EntitySalesInvoice req = new EntitySalesInvoice() {
    Id = "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    Testmode = false,
    ProfileId = "pfl_QkEhN94Ba",
    Status = SalesInvoiceStatus.Draft,
    VatScheme = SalesInvoiceVatScheme.Standard,
    VatMode = SalesInvoiceVatMode.Exclusive,
    Memo = "This is a memo!",
    PaymentTerm = SalesInvoicePaymentTerm.Thirtydays,
    PaymentDetails = new SalesInvoicePaymentDetails() {
        Source = SalesInvoicePaymentDetailsSource.PaymentLink,
        SourceReference = "pl_d9fQur83kFdhH8hIhaZfq",
    },
    EmailDetails = new SalesInvoiceEmailDetails() {
        Subject = "Your invoice is available",
        Body = "Please find your invoice enclosed.",
    },
    CustomerId = "cst_8wmqcHMN4U",
    MandateId = "mdt_pWUnw6pkBN",
    RecipientIdentifier = "customer-xyz-0123",
    Recipient = new SalesInvoiceRecipient() {
        Type = SalesInvoiceRecipientType.Consumer,
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
        Locale = SalesInvoiceRecipientLocale.Nlnl,
    },
    Lines = new List<SalesInvoiceLineItem>() {},
    Discount = new SalesInvoiceDiscount() {
        Type = SalesInvoiceDiscountType.Amount,
        Value = "10.00",
    },
    AmountDue = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    SubtotalAmount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    TotalAmount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    TotalVatAmount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    DiscountedSubtotalAmount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
};

var res = await sdk.SalesInvoices.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [EntitySalesInvoice](../../Models/Components/EntitySalesInvoice.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[CreateSalesInvoiceResponse](../../Models/Requests/CreateSalesInvoiceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieve a list of all sales invoices created through the API.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-sales-invoices" method="get" path="/sales-invoices" -->
```csharp
using Mollie;
using Mollie.Models.Components;

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
| `From`                                                                                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the<br/>result set.                                                                                                                                                                                                                                                     |                                                                                                                                                                                                                                                                                                                                                                                        |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | The maximum number of items to return. Defaults to 50 items.                                                                                                                                                                                                                                                                                                                           | 50                                                                                                                                                                                                                                                                                                                                                                                     |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[ListSalesInvoicesResponse](../../Models/Requests/ListSalesInvoicesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Retrieve a single sales invoice by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-sales-invoice" method="get" path="/sales-invoices/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

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
| `Id`                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the item you want to perform this operation on.                                                                                                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                                                                                        |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetSalesInvoiceResponse](../../Models/Requests/GetSalesInvoiceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Certain details of an existing sales invoice can be updated. For `draft` it is all values listed below, but for
statuses `paid` and `issued` there are certain additional requirements (`paymentDetails` and `emailDetails`,
respectively).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-sales-invoice" method="patch" path="/sales-invoices/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.SalesInvoices.UpdateAsync(
    id: "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    updateValuesSalesInvoice: new UpdateValuesSalesInvoice() {
        Testmode = false,
        Status = SalesInvoiceStatus.Draft,
        Memo = "An updated memo!",
        PaymentTerm = SalesInvoicePaymentTerm.Thirtydays,
        PaymentDetails = new SalesInvoicePaymentDetails() {
            Source = SalesInvoicePaymentDetailsSource.PaymentLink,
            SourceReference = "pl_d9fQur83kFdhH8hIhaZfq",
        },
        EmailDetails = new SalesInvoiceEmailDetails() {
            Subject = "Your invoice is available",
            Body = "Please find your invoice enclosed.",
        },
        RecipientIdentifier = "customer-xyz-0123",
        Recipient = new SalesInvoiceRecipient() {
            Type = SalesInvoiceRecipientType.Consumer,
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
            Locale = SalesInvoiceRecipientLocale.Nlnl,
        },
        Lines = new List<SalesInvoiceLineItem>() {
            new SalesInvoiceLineItem() {
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                VatRate = "21.00",
                UnitPrice = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Discount = new SalesInvoiceDiscount() {
                    Type = SalesInvoiceDiscountType.Amount,
                    Value = "10.00",
                },
            },
        },
        Discount = new SalesInvoiceDiscount() {
            Type = SalesInvoiceDiscountType.Amount,
            Value = "10.00",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Id`                                                                            | *string*                                                                        | :heavy_check_mark:                                                              | Provide the ID of the item you want to perform this operation on.               |
| `UpdateValuesSalesInvoice`                                                      | [UpdateValuesSalesInvoice](../../Models/Components/UpdateValuesSalesInvoice.md) | :heavy_minus_sign:                                                              | N/A                                                                             |

### Response

**[UpdateSalesInvoiceResponse](../../Models/Requests/UpdateSalesInvoiceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Delete

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Sales invoices which are in status `draft` can be deleted. For all other statuses, please use the
[Update sales invoice](update-sales-invoice) endpoint instead.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-sales-invoice" method="delete" path="/sales-invoices/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.SalesInvoices.DeleteAsync(
    id: "invoice_4Y0eZitmBnQ6IDoMqZQKh",
    deleteValuesSalesInvoice: new DeleteValuesSalesInvoice() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Id`                                                                            | *string*                                                                        | :heavy_check_mark:                                                              | Provide the ID of the item you want to perform this operation on.               |
| `DeleteValuesSalesInvoice`                                                      | [DeleteValuesSalesInvoice](../../Models/Components/DeleteValuesSalesInvoice.md) | :heavy_minus_sign:                                                              | N/A                                                                             |

### Response

**[DeleteSalesInvoiceResponse](../../Models/Requests/DeleteSalesInvoiceResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |