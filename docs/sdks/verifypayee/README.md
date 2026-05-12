# VerifyPayee

## Overview

### Available Operations

* [Create](#create) - Verify Payee

## Create

> 🚧 Beta feature
>
> This feature is currently in beta testing, and the final specification may still change.

Perform a Verification of Payee (VoP) check. This allows you to verify the account holder name against the
records held by the receiving bank before initiating a transfer.

The verification result indicates whether the provided name matches, closely matches, or does not match the
name on file at the receiving bank. This helps prevent misdirected payments.

### Simulating verification scenarios in test mode

In test mode, you can simulate various verification outcomes by adjusting the creditor name in the
`creditorBankAccount.accountHolderName` property. This allows you to test all possible Verification of Payee
results without needing special properties. The names are case insensitive.

| Account holder name                    | Scenario                                      | Verification result | Suggested name |
|----------------------------------------|-----------------------------------------------|---------------------|----------------|
| `John Close Match`                     | Name closely matches the bank records          | `close-match`       | `John Match`   |
| `John No Match`                        | Name does not match the bank records           | `no-match`          | —              |
| `John Unavailable`                     | Verification is not available                  | `not-available`     | —              |
| Any other name                         | Default: name matches the bank records         | `match`             | —              |

### Example Usage: verify-payee-200-close-match

<!-- UsageSnippet language="csharp" operationID="verify-payee" method="post" path="/v2/business-accounts/payee-verifications" example="verify-payee-200-close-match" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.VerifyPayee.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    verificationOfPayeeRequest: new VerificationOfPayeeRequest() {
        CreditorBankAccount = new CreditorBankAccount() {
            AccountHolderName = "Jan Jansen",
            Format = AccountNumberFormat.Iban,
            AccountNumber = "NL02ABNA0123456789",
        },
        Testmode = false,
    }
);

// handle response
```
### Example Usage: verify-payee-200-match

<!-- UsageSnippet language="csharp" operationID="verify-payee" method="post" path="/v2/business-accounts/payee-verifications" example="verify-payee-200-match" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.VerifyPayee.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    verificationOfPayeeRequest: new VerificationOfPayeeRequest() {
        CreditorBankAccount = new CreditorBankAccount() {
            AccountHolderName = "Jan Jansen",
            Format = AccountNumberFormat.Iban,
            AccountNumber = "NL02ABNA0123456789",
        },
        Testmode = false,
    }
);

// handle response
```
### Example Usage: verify-payee-200-no-match

<!-- UsageSnippet language="csharp" operationID="verify-payee" method="post" path="/v2/business-accounts/payee-verifications" example="verify-payee-200-no-match" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.VerifyPayee.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    verificationOfPayeeRequest: new VerificationOfPayeeRequest() {
        CreditorBankAccount = new CreditorBankAccount() {
            AccountHolderName = "Jan Jansen",
            Format = AccountNumberFormat.Iban,
            AccountNumber = "NL02ABNA0123456789",
        },
        Testmode = false,
    }
);

// handle response
```
### Example Usage: verify-payee-200-not-available

<!-- UsageSnippet language="csharp" operationID="verify-payee" method="post" path="/v2/business-accounts/payee-verifications" example="verify-payee-200-not-available" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.VerifyPayee.CreateAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    verificationOfPayeeRequest: new VerificationOfPayeeRequest() {
        CreditorBankAccount = new CreditorBankAccount() {
            AccountHolderName = "Jan Jansen",
            Format = AccountNumberFormat.Iban,
            AccountNumber = "NL02ABNA0123456789",
        },
        Testmode = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                    | *string*                                                                            | :heavy_minus_sign:                                                                  | A unique key to ensure idempotent requests. This key should be a UUID v4 string.    | 123e4567-e89b-12d3-a456-426                                                         |
| `VerificationOfPayeeRequest`                                                        | [VerificationOfPayeeRequest](../../Models/Components/VerificationOfPayeeRequest.md) | :heavy_minus_sign:                                                                  | N/A                                                                                 |                                                                                     |

### Response

**[VerifyPayeeResponse](../../Models/Requests/VerifyPayeeResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 422, 429                           | application/hal+json               |
| Mollie.Models.Errors.ErrorResponse | 503                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |