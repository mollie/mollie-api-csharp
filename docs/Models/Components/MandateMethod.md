# MandateMethod

Payment method of the mandate.

SEPA Direct Debit and PayPal mandates can be created directly.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = MandateMethod.Creditcard;
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Creditcard`  | creditcard    |
| `Directdebit` | directdebit   |
| `Paypal`      | paypal        |