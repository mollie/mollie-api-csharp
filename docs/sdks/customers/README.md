# Customers
(*Customers*)

## Overview

### Available Operations

* [Create](#create) - Create customer
* [List](#list) - List customers
* [Get](#get) - Get customer
* [Update](#update) - Update customer
* [Delete](#delete) - Delete customer
* [CreatePayment](#createpayment) - Create customer payment
* [ListPayments](#listpayments) - List customer payments

## Create

Creates a simple minimal representation of a customer. Payments, recurring mandates, and subscriptions can be linked
to this customer object, which simplifies management of recurring payments.

Once registered, customers will also appear in your Mollie dashboard.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-customer" method="post" path="/customers" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateCustomerRequest req = new CreateCustomerRequest() {
    Name = "John Doe",
    Email = "example@email.com",
    Locale = CreateCustomerLocaleRequest.EnUS,
    Testmode = false,
};

var res = await sdk.Customers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [CreateCustomerRequest](../../Models/Requests/CreateCustomerRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[CreateCustomerResponse](../../Models/Requests/CreateCustomerResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| Mollie.Models.Errors.CreateCustomerHalJSONException | 404                                                 | application/hal+json                                |
| Mollie.Models.Errors.APIException                   | 4XX, 5XX                                            | \*/\*                                               |

## List

Retrieve a list of all customers.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-customers" method="get" path="/customers" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.ListAsync(
    fromP: "cst_5B8cwPMGnU",
    limit: 50,
    sort: ListCustomersSort.Desc,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `From`                                                                                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the<br/>result set.                                                                                                                                                                                                                                                     | cst_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                         |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | The maximum number of items to return. Defaults to 50 items.                                                                                                                                                                                                                                                                                                                           | 50                                                                                                                                                                                                                                                                                                                                                                                     |
| `Sort`                                                                                                                                                                                                                                                                                                                                                                                 | [ListCustomersSort](../../Models/Requests/ListCustomersSort.md)                                                                                                                                                                                                                                                                                                                        | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Used for setting the direction of the result set. Defaults to descending order, meaning the results are ordered from<br/>newest to oldest.                                                                                                                                                                                                                                             | desc                                                                                                                                                                                                                                                                                                                                                                                   |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[ListCustomersResponse](../../Models/Requests/ListCustomersResponse.md)**

### Errors

| Error Type                                                   | Status Code                                                  | Content Type                                                 |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Mollie.Models.Errors.ListCustomersBadRequestHalJSONException | 400                                                          | application/hal+json                                         |
| Mollie.Models.Errors.ListCustomersNotFoundHalJSONException   | 404                                                          | application/hal+json                                         |
| Mollie.Models.Errors.APIException                            | 4XX, 5XX                                                     | \*/\*                                                        |

## Get

Retrieve a single customer by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-customer" method="get" path="/customers/{customerId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.GetAsync(
    customerId: "cst_5B8cwPMGnU",
    include: GetCustomerInclude.Events,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `CustomerId`                                                                                                                                                                                                                                                                                                                                                                           | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related customer.                                                                                                                                                                                                                                                                                                                                                | cst_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                         |
| `Include`                                                                                                                                                                                                                                                                                                                                                                              | [GetCustomerInclude](../../Models/Requests/GetCustomerInclude.md)                                                                                                                                                                                                                                                                                                                      | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | This endpoint allows you to include additional information via the `include` query string parameter.                                                                                                                                                                                                                                                                                   | events                                                                                                                                                                                                                                                                                                                                                                                 |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetCustomerResponse](../../Models/Requests/GetCustomerResponse.md)**

### Errors

| Error Type                                       | Status Code                                      | Content Type                                     |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| Mollie.Models.Errors.GetCustomerHalJSONException | 404                                              | application/hal+json                             |
| Mollie.Models.Errors.APIException                | 4XX, 5XX                                         | \*/\*                                            |

## Update

Update an existing customer.

For an in-depth explanation of each parameter, refer to the [Create customer](create-customer) endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-customer" method="patch" path="/customers/{customerId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.UpdateAsync(
    customerId: "cst_5B8cwPMGnU",
    requestBody: new UpdateCustomerRequestBody() {
        Name = "John Doe",
        Email = "example@email.com",
        Locale = UpdateCustomerLocaleRequest.EnUS,
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     | Example                                                                         |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `CustomerId`                                                                    | *string*                                                                        | :heavy_check_mark:                                                              | Provide the ID of the related customer.                                         | cst_5B8cwPMGnU                                                                  |
| `RequestBody`                                                                   | [UpdateCustomerRequestBody](../../Models/Requests/UpdateCustomerRequestBody.md) | :heavy_minus_sign:                                                              | N/A                                                                             |                                                                                 |

### Response

**[UpdateCustomerResponse](../../Models/Requests/UpdateCustomerResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| Mollie.Models.Errors.UpdateCustomerHalJSONException | 404                                                 | application/hal+json                                |
| Mollie.Models.Errors.APIException                   | 4XX, 5XX                                            | \*/\*                                               |

## Delete

Delete a customer. All mandates and subscriptions created for this customer will be canceled as well.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-customer" method="delete" path="/customers/{customerId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.DeleteAsync(
    customerId: "cst_5B8cwPMGnU",
    requestBody: new DeleteCustomerRequestBody() {
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     | Example                                                                         |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `CustomerId`                                                                    | *string*                                                                        | :heavy_check_mark:                                                              | Provide the ID of the related customer.                                         | cst_5B8cwPMGnU                                                                  |
| `RequestBody`                                                                   | [DeleteCustomerRequestBody](../../Models/Requests/DeleteCustomerRequestBody.md) | :heavy_minus_sign:                                                              | N/A                                                                             |                                                                                 |

### Response

**[DeleteCustomerResponse](../../Models/Requests/DeleteCustomerResponse.md)**

### Errors

| Error Type                                          | Status Code                                         | Content Type                                        |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| Mollie.Models.Errors.DeleteCustomerHalJSONException | 404                                                 | application/hal+json                                |
| Mollie.Models.Errors.APIException                   | 4XX, 5XX                                            | \*/\*                                               |

## CreatePayment

Creates a payment for the customer.

Linking customers to payments enables you to:

* Keep track of payment preferences for your customers
* Allow your customers to charge a previously used credit card with a single click in our hosted checkout
* Improve payment insights in the Mollie dashboard
* Use recurring payments

This endpoint is effectively an alias of the [Create payment endpoint](create-payment) with the `customerId`
parameter predefined.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.CreatePaymentAsync(
    customerId: "cst_5B8cwPMGnU",
    requestBody: new CreateCustomerPaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreateCustomerPaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreateCustomerPaymentLineRequest>() {
            new CreateCustomerPaymentLineRequest() {
                Type = CreateCustomerPaymentLineTypeRequest.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreateCustomerPaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreateCustomerPaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreateCustomerPaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreateCustomerPaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreateCustomerPaymentCategoryRequest>() {
                    CreateCustomerPaymentCategoryRequest.Meal,
                    CreateCustomerPaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreateCustomerPaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = CreateCustomerPaymentIntervalRequest.DotDotDotMonths,
                    Amount = new CreateCustomerPaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreateCustomerPaymentBillingAddressRequest() {
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
        ShippingAddress = new CreateCustomerPaymentShippingAddressRequest() {
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
        Locale = CreateCustomerPaymentLocaleRequest.EnUS,
        Method = CreateCustomerPaymentMethodRequest.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CreateCustomerPaymentCaptureModeRequest.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new CreateCustomerPaymentApplicationFeeRequest() {
            Amount = new CreateCustomerPaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreateCustomerPaymentRoutingRequest>() {
            new CreateCustomerPaymentRoutingRequest() {
                Amount = new CreateCustomerPaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreateCustomerPaymentDestinationRequest() {
                    Type = CreateCustomerPaymentRoutingTypeRequest.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreateCustomerPaymentLinksRequest() {
                    Self = new CreateCustomerPaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreateCustomerPaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = CreateCustomerPaymentSequenceTypeRequest.Oneoff,
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   | Example                                                                                       |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `CustomerId`                                                                                  | *string*                                                                                      | :heavy_check_mark:                                                                            | Provide the ID of the related customer.                                                       | cst_5B8cwPMGnU                                                                                |
| `RequestBody`                                                                                 | [CreateCustomerPaymentRequestBody](../../Models/Requests/CreateCustomerPaymentRequestBody.md) | :heavy_minus_sign:                                                                            | N/A                                                                                           |                                                                                               |

### Response

**[CreateCustomerPaymentResponse](../../Models/Requests/CreateCustomerPaymentResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| Mollie.Models.Errors.CreateCustomerPaymentUnprocessableEntityHalJSONException | 422                                                                           | application/hal+json                                                          |
| Mollie.Models.Errors.CreateCustomerPaymentServiceUnavailableHalJSONException  | 503                                                                           | application/hal+json                                                          |
| Mollie.Models.Errors.APIException                                             | 4XX, 5XX                                                                      | \*/\*                                                                         |

## ListPayments

Retrieve all payments linked to the customer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-customer-payments" method="get" path="/customers/{customerId}/payments" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

ListCustomerPaymentsRequest req = new ListCustomerPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = ListCustomerPaymentsSort.Desc,
    ProfileId = "pfl_5B8cwPMGnU",
    Testmode = false,
};

var res = await sdk.Customers.ListPaymentsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [ListCustomerPaymentsRequest](../../Models/Requests/ListCustomerPaymentsRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[ListCustomerPaymentsResponse](../../Models/Requests/ListCustomerPaymentsResponse.md)**

### Errors

| Error Type                                                | Status Code                                               | Content Type                                              |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| Mollie.Models.Errors.ListCustomerPaymentsHalJSONException | 400                                                       | application/hal+json                                      |
| Mollie.Models.Errors.APIException                         | 4XX, 5XX                                                  | \*/\*                                                     |