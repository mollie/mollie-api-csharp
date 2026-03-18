# Onboarding

## Overview

### Available Operations

* [Get](#get) - Get onboarding status
* [Submit](#submit) - Submit onboarding data

## Get

Retrieve the onboarding status of the currently authenticated organization.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-onboarding-status" method="get" path="/onboarding/me" example="get-onboarding-status-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

var res = await sdk.Onboarding.GetAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetOnboardingStatusResponse](../../Models/Requests/GetOnboardingStatusResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |

## Submit

**⚠️ We no longer recommend implementing this endpoint. Please refer to the Client Links API instead to kick off the
onboarding process for your merchants.**

Submit data that will be prefilled in the merchant's onboarding. The data you submit will only be processed when the
onboarding status is `needs-data`.  
Information that the merchant has entered in their dashboard will not be overwritten.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="submit-onboarding-data" method="post" path="/onboarding/me" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

var res = await sdk.Onboarding.SubmitAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new SubmitOnboardingDataRequestBody() {
        Organization = new Organization() {
            Name = "Mollie B.V.",
            Address = new Address() {
                StreetAndNumber = "Keizersgracht 126",
                PostalCode = "1015 CW",
                City = "Amsterdam",
                Country = "NL",
            },
            RegistrationNumber = "30204462",
            VatNumber = "NL815839091B01",
            VatRegulation = OnboardingVatRegulation.Dutch,
        },
        Profile = new Profile() {
            Name = "Mollie",
            Url = "https://www.mollie.com",
            Email = "info@mollie.com",
            Phone = "+31208202070",
            Description = "Payment service provider",
            BusinessCategory = "MONEY_SERVICES",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 | Example                                                                                     |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                            | *string*                                                                                    | :heavy_minus_sign:                                                                          | A unique key to ensure idempotent requests. This key should be a UUID v4 string.            | 123e4567-e89b-12d3-a456-426                                                                 |
| `RequestBody`                                                                               | [SubmitOnboardingDataRequestBody](../../Models/Requests/SubmitOnboardingDataRequestBody.md) | :heavy_minus_sign:                                                                          | N/A                                                                                         |                                                                                             |

### Response

**[SubmitOnboardingDataResponse](../../Models/Requests/SubmitOnboardingDataResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |