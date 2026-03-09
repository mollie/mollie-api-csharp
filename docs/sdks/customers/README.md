# Customers

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

<!-- UsageSnippet language="csharp" operationID="create-customer" method="post" path="/customers" example="create-customer-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    entityCustomer: new EntityCustomer() {
        Name = "John Doe",
        Email = "example@email.com",
        Locale = LocaleResponse.EnUS,
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `EntityCustomer`                                                                 | [EntityCustomer](../../Models/Components/EntityCustomer.md)                      | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

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

<!-- UsageSnippet language="csharp" operationID="list-customers" method="get" path="/customers" example="list-customers" -->
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

ListCustomersRequest req = new ListCustomersRequest() {
    From = "cst_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListCustomersResponse? res = await sdk.Customers.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [ListCustomersRequest](../../Models/Requests/ListCustomersRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

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

<!-- UsageSnippet language="csharp" operationID="get-customer" method="get" path="/customers/{customerId}" example="get-customer-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Customers.GetAsync(
    customerId: "cst_5B8cwPMGnU",
    include: "events",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                                | Type                                                                                                                                                                                                                                                                                                                                                                                     | Required                                                                                                                                                                                                                                                                                                                                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                                                                                                                                                                                                                                                                  |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `CustomerId`                                                                                                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                       | Provide the ID of the related customer.                                                                                                                                                                                                                                                                                                                                                  | cst_5B8cwPMGnU                                                                                                                                                                                                                                                                                                                                                                           |
| `Include`                                                                                                                                                                                                                                                                                                                                                                                | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | This endpoint allows you to include additional information via the `include` query string parameter.                                                                                                                                                                                                                                                                                     |                                                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                               | *bool*                                                                                                                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter must not be sent. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                                                                                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                                                                                                                                                                                                                         | *string*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                       | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                                                                                                                                                                                                                         | 123e4567-e89b-12d3-a456-426                                                                                                                                                                                                                                                                                                                                                              |

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

### Example Usage: update-customer-200-1

<!-- UsageSnippet language="csharp" operationID="update-customer" method="patch" path="/customers/{customerId}" example="update-customer-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.UpdateAsync(
    customerId: "cst_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new UpdateCustomerRequestBody() {
        Name = "John Doe",
        Email = "example@email.com",
        Locale = LocaleResponse.EnUS,
        Testmode = false,
    }
);

// handle response
```
### Example Usage: update-customer-200-2

<!-- UsageSnippet language="csharp" operationID="update-customer" method="patch" path="/customers/{customerId}" example="update-customer-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Customers.UpdateAsync(
    customerId: "cst_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new UpdateCustomerRequestBody() {
        Name = "John Doe",
        Email = "example@email.com",
        Locale = LocaleResponse.EnUS,
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
| `RequestBody`                                                                    | [UpdateCustomerRequestBody](../../Models/Requests/UpdateCustomerRequestBody.md)  | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new DeleteCustomerRequestBody() {
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
| `RequestBody`                                                                    | [DeleteCustomerRequestBody](../../Models/Requests/DeleteCustomerRequestBody.md)  | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

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

### Example Usage: create-payment-201-1

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-1" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-10

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-10" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-11

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-11" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-12

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-12" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-2

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-2" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-3

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-3" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-4

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-4" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-5

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-5" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-6

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-6" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-7

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-7" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-8

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-8" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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
### Example Usage: create-payment-201-9

<!-- UsageSnippet language="csharp" operationID="create-customer-payment" method="post" path="/customers/{customerId}/payments" example="create-payment-201-9" -->
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    paymentRequest: new PaymentRequest() {
        Description = "Chess Board",
        Amount = new Amount() {
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
                Categories = new List<LineCategories>() {
                    LineCategories.Meal,
                    LineCategories.Eco,
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
        BillingAddress = new PaymentRequestBillingAddress() {
            Title = "Mr.",
            GivenName = "Piet",
            FamilyName = "Mondriaan",
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
        Method = Method.CreateMethodEnum(
            MethodEnum.Ideal
        ),
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
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
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

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `CustomerId`                                                                     | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related customer.                                          | cst_5B8cwPMGnU                                                                   |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |
| `PaymentRequest`                                                                 | [PaymentRequest](../../Models/Components/PaymentRequest.md)                      | :heavy_minus_sign:                                                               | N/A                                                                              |                                                                                  |

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

### Example Usage: list-payments-200-1

<!-- UsageSnippet language="csharp" operationID="list-customer-payments" method="get" path="/customers/{customerId}/payments" example="list-payments-200-1" -->
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

ListCustomerPaymentsRequest req = new ListCustomerPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListCustomerPaymentsResponse? res = await sdk.Customers.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-2

<!-- UsageSnippet language="csharp" operationID="list-customer-payments" method="get" path="/customers/{customerId}/payments" example="list-payments-200-2" -->
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

ListCustomerPaymentsRequest req = new ListCustomerPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListCustomerPaymentsResponse? res = await sdk.Customers.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```
### Example Usage: list-payments-200-3

<!-- UsageSnippet language="csharp" operationID="list-customer-payments" method="get" path="/customers/{customerId}/payments" example="list-payments-200-3" -->
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

ListCustomerPaymentsRequest req = new ListCustomerPaymentsRequest() {
    CustomerId = "cst_5B8cwPMGnU",
    From = "tr_5B8cwPMGnU",
    Limit = 50,
    Sort = Sorting.Desc,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

ListCustomerPaymentsResponse? res = await sdk.Customers.ListPaymentsAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
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