# Onboarding
(*Onboarding*)

## Overview

### Available Operations

* [Get](#get) - Get onboarding status
* [Submit](#submit) - Submit onboarding data

## Get

Retrieve the onboarding status of the currently authenticated organization.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-onboarding-status" method="get" path="/onboarding/me" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Onboarding.GetAsync();

// handle response
```

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
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

SubmitOnboardingDataRequest req = new SubmitOnboardingDataRequest() {
    Organization = new Organization() {
        Name = "Mollie B.V.",
        RegistrationNumber = "30204462",
        VatNumber = "NL815839091B01",
        VatRegulation = VatRegulation.Dutch,
    },
    Profile = new Profile() {
        Name = "Mollie",
        Url = "https://www.mollie.com",
        Email = "info@mollie.com",
        Phone = "+31208202070",
        Description = "Payment service provider",
        BusinessCategory = "MONEY_SERVICES",
    },
};

var res = await sdk.Onboarding.SubmitAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [SubmitOnboardingDataRequest](../../Models/Requests/SubmitOnboardingDataRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[SubmitOnboardingDataResponse](../../Models/Requests/SubmitOnboardingDataResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |