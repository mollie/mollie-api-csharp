<!-- Start SDK Example Usage [usage] -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Payments.CreateAsync(
    include: CreatePaymentInclude.DetailsQrCode,
    requestBody: new CreatePaymentRequestBody() {
        Description = "Chess Board",
        Amount = new CreatePaymentAmountRequest() {
            Currency = "EUR",
            Value = "10.00",
        },
        RedirectUrl = "https://example.org/redirect",
        CancelUrl = "https://example.org/cancel",
        WebhookUrl = "https://example.org/webhooks",
        Lines = new List<CreatePaymentLineRequest>() {
            new CreatePaymentLineRequest() {
                Description = "LEGO 4440 Forest Police Station",
                Quantity = 1,
                QuantityUnit = "pcs",
                UnitPrice = new CreatePaymentUnitPriceRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                DiscountAmount = new CreatePaymentDiscountAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                TotalAmount = new CreatePaymentTotalAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                VatRate = "21.00",
                VatAmount = new CreatePaymentVatAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Sku = "9780241661628",
                Categories = new List<CreatePaymentCategoryRequest>() {
                    CreatePaymentCategoryRequest.Meal,
                    CreatePaymentCategoryRequest.Eco,
                },
                ImageUrl = "https://...",
                ProductUrl = "https://...",
                Recurring = new CreatePaymentRecurringRequest() {
                    Description = "Gym subscription",
                    Interval = "12 months",
                    Amount = new CreatePaymentRecurringAmountRequest() {
                        Currency = "EUR",
                        Value = "10.00",
                    },
                    Times = 1,
                    StartDate = "2024-12-12",
                },
            },
        },
        BillingAddress = new CreatePaymentBillingAddressRequest() {
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
        ShippingAddress = new CreatePaymentShippingAddressRequest() {
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
        Locale = "en_US",
        Method = "ideal",
        Issuer = "ideal_INGBNL2A",
        RestrictPaymentMethodsToCountry = "NL",
        CaptureMode = "manual",
        CaptureDelay = "8 hours",
        ApplicationFee = new CreatePaymentApplicationFeeRequest() {
            Amount = new CreatePaymentApplicationFeeAmountRequest() {
                Currency = "EUR",
                Value = "10.00",
            },
            Description = "10",
        },
        Routing = new List<CreatePaymentRoutingRequest>() {
            new CreatePaymentRoutingRequest() {
                Amount = new CreatePaymentRoutingAmountRequest() {
                    Currency = "EUR",
                    Value = "10.00",
                },
                Destination = new CreatePaymentDestinationRequest() {
                    Type = "organization",
                    OrganizationId = "org_1234567",
                },
                ReleaseDate = "2024-12-12",
                Links = new CreatePaymentLinksRequest() {
                    Self = new CreatePaymentSelfRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                    Payment = new CreatePaymentPaymentRequest() {
                        Href = "https://...",
                        Type = "application/hal+json",
                    },
                },
            },
        },
        SequenceType = "oneoff",
        MandateId = "mdt_5B8cwPMGnU",
        CustomerId = "cst_5B8cwPMGnU",
        ProfileId = "pfl_5B8cwPMGnU",
        DueDate = "2025-01-01",
        Testmode = false,
    }
);

// handle response
```
<!-- End SDK Example Usage [usage] -->