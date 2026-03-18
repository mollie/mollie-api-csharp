# SubscriptionMethod

The payment method used for this subscription. If omitted, any of the customer's valid mandates may be used.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SubscriptionMethod.Creditcard;
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Creditcard`  | creditcard    |
| `Directdebit` | directdebit   |
| `Paypal`      | paypal        |