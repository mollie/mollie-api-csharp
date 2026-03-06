# PaymentDetailsWalletResponse

The wallet used when creating the payment.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsWalletResponse.Applepay;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsWalletResponse.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Applepay` | applepay   |