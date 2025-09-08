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

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

EntityCustomer req = new EntityCustomer() {
    Id = "cst_5B8cwPMGnU",
    Name = "John Doe",
    Email = "example@email.com",
    Locale = LocaleResponse.EnUS,
    Testmode = false,
};

var res = await sdk.Customers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | [EntityCustomer](../../Models/Components/EntityCustomer.md) | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[CreateCustomerResponse](../../Models/Requests/CreateCustomerResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all customers.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-customers" method="get" path="/customers" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.ListAsync(
    fromP: "cst_5B8cwPMGnU",
    limit: 50,
    sort: ListSort.Desc,
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `From`                                                                                                                                                                                                                                                                                                                                                                                 | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the<br/>result set.                                                                                                                                                                                                                                                     | cst_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                         |
| `Limit`                                                                                                                                                                                                                                                                                                                                                                                | *long*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | The maximum number of items to return. Defaults to 50 items.                                                                                                                                                                                                                                                                                                                           | 50                                                                                                                                                                                                                                                                                                                                                                                     |
| `Sort`                                                                                                                                                                                                                                                                                                                                                                                 | [ListSort](../../Models/Components/ListSort.md)                                                                                                                                                                                                                                                                                                                                        | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Used for setting the direction of the result set. Defaults to descending order, meaning the results are ordered from<br/>newest to oldest.                                                                                                                                                                                                                                             | desc                                                                                                                                                                                                                                                                                                                                                                                   |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[ListCustomersResponse](../../Models/Requests/ListCustomersResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single customer by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-customer" method="get" path="/customers/{customerId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.GetAsync(
    customerId: "cst_5B8cwPMGnU",
    include: "events",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `CustomerId`                                                                                                                                                                                                                                                                                                                                                                           | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the related customer.                                                                                                                                                                                                                                                                                                                                                | cst_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                         |
| `Include`                                                                                                                                                                                                                                                                                                                                                                              | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | This endpoint allows you to include additional information via the `include` query string parameter.                                                                                                                                                                                                                                                                                   |                                                                                                                                                                                                                                                                                                                                                                                        |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetCustomerResponse](../../Models/Requests/GetCustomerResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Update an existing customer.

For an in-depth explanation of each parameter, refer to the [Create customer](create-customer) endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-customer" method="patch" path="/customers/{customerId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.UpdateAsync(
    customerId: "cst_5B8cwPMGnU",
    entityCustomer: new EntityCustomer() {
        Id = "cst_5B8cwPMGnU",
        Name = "John Doe",
        Email = "example@email.com",
        Locale = LocaleResponse.EnUS,
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `CustomerId`                                                | *string*                                                    | :heavy_check_mark:                                          | Provide the ID of the related customer.                     | cst_5B8cwPMGnU                                              |
| `EntityCustomer`                                            | [EntityCustomer](../../Models/Components/EntityCustomer.md) | :heavy_minus_sign:                                          | N/A                                                         |                                                             |

### Response

**[UpdateCustomerResponse](../../Models/Requests/UpdateCustomerResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

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

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

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
using NodaTime;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.CreatePaymentAsync(
    customerId: "cst_5B8cwPMGnU",
    paymentRequest: new PaymentRequest() {
        Id = "tr_5B8cwPMGnU",
        Description = "Chess Board",
        Amount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        AmountRefunded = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        AmountRemaining = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        AmountCaptured = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        AmountChargedBack = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        SettlementAmount = new Amount() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<PaymentRequestLine>() {
            new PaymentRequestLine() {
                Type = PaymentLineType.Physical,
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<PaymentRequestCategory>() {
                    PaymentRequestCategory.Meal,
                    PaymentRequestCategory.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new RecurringLineItem() {
                    Description = "Gym subscription",
                    Interval = "... months",
                    Amount = new Amount() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
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
        Locale = Locale.EnUS,
        Method = Method.Ideal,
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = CaptureMode.Manual,
        CaptureDelay = "8 hours",
        ApplicationFee = new PaymentRequestApplicationFee() {
            Amount = new Amount() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<EntityPaymentRoute>() {
            new EntityPaymentRoute() {
                Id = "rt_5B8cwPMGnU",
                Amount = new Amount() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new EntityPaymentRouteDestination() {
                    Type = RouteDestinationType.Organization,
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new EntityPaymentRouteLinks() {
                    Self = new Url() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new Url() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = SequenceType.Oneoff,
        SubscriptionId = "sub_5B8cwPMGnU",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        SettlementId = "stl_5B8cwPMGnU",
        OrderId = "ord_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
        ApplePayPaymentToken = "{\"paymentData\": {\"version\": \"EC_v1\", \"data\": \"vK3BbrCbI/....\"}}",
        Company = new Company() {
            RegistrationNumber = "12345678",
            VatNumber = "NL123456789B01",
        },
        CardToken = "tkn_12345",
        VoucherNumber = "1234567890",
        VoucherPin = "1234",
        ConsumerDateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2000-01-01")),
        DigitalGoods = true,
        CustomerReference = "1234567890",
        TerminalId = "term_1234567890",
    }
);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `CustomerId`                                                | *string*                                                    | :heavy_check_mark:                                          | Provide the ID of the related customer.                     | cst_5B8cwPMGnU                                              |
| `PaymentRequest`                                            | [PaymentRequest](../../Models/Components/PaymentRequest.md) | :heavy_minus_sign:                                          | N/A                                                         |                                                             |

### Response

**[CreateCustomerPaymentResponse](../../Models/Requests/CreateCustomerPaymentResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422                                | application/hal+json               |
| Mollie.Models.Errors.ErrorResponse | 503                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

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
    Sort = ListSort.Desc,
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

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |