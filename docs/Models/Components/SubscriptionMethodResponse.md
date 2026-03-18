# SubscriptionMethodResponse

The payment method used for this subscription. If omitted, any of the customer's valid mandates may be used.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SubscriptionMethodResponse.Creditcard;

// Open enum: use .Of() to create instances from custom string values
var custom = SubscriptionMethodResponse.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Creditcard`  | creditcard    |
| `Directdebit` | directdebit   |
| `Paypal`      | paypal        |