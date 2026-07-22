# SessionRequiredCustomerDetailsResponse

Customer details that should be collected during checkout.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SessionRequiredCustomerDetailsResponse.Email;

// Open enum: use .Of() to create instances from custom string values
var custom = SessionRequiredCustomerDetailsResponse.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Email`           | email             |
| `BillingAddress`  | billing-address   |
| `ShippingAddress` | shipping-address  |