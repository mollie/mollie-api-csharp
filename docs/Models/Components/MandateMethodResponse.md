# MandateMethodResponse

Payment method of the mandate.

SEPA Direct Debit and PayPal mandates can be created directly.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = MandateMethodResponse.Creditcard;

// Open enum: use .Of() to create instances from custom string values
var custom = MandateMethodResponse.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Creditcard`  | creditcard    |
| `Directdebit` | directdebit   |
| `Paypal`      | paypal        |