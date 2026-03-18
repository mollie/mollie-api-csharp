# PaymentDetailsSellerProtectionResponse

Indicates to what extent the payment is eligible for PayPal's Seller Protection. Only available for PayPal
payments, and if the information is made available by PayPal.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsSellerProtectionResponse.EligibleUpper;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsSellerProtectionResponse.Of("custom_value");
```


## Values

| Name                                    | Value                                   |
| --------------------------------------- | --------------------------------------- |
| `EligibleUpper`                         | ELIGIBLE                                |
| `PartiallyEligibleUpper`                | PARTIALLY_ELIGIBLE                      |
| `NotEligible`                           | NOT_ELIGIBLE                            |
| `EligibleMixed`                         | Eligible                                |
| `Ineligible`                            | Ineligible                              |
| `PartiallyEligibleINROnly`              | Partially Eligible - INR Only           |
| `PartiallyEligibleUnauthOnly`           | Partially Eligible - Unauth Only        |
| `PartiallyEligibleMixed`                | Partially Eligible                      |
| `None`                                  | None                                    |
| `Active`                                | Active                                  |
| `FraudControlUnauthPremiumEligible`     | Fraud Control - Unauth Premium Eligible |