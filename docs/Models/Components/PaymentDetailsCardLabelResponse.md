# PaymentDetailsCardLabelResponse

The card's label, if known.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsCardLabelResponse.AmericanExpress;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsCardLabelResponse.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `AmericanExpress` | American Express  |
| `CartaSi`         | Carta Si          |
| `CarteBleue`      | Carte Bleue       |
| `Dankort`         | Dankort           |
| `DinersClub`      | Diners Club       |
| `Discover`        | Discover          |
| `Jcb`             | JCB               |
| `Laser`           | Laser             |
| `Maestro`         | Maestro           |
| `Mastercard`      | Mastercard        |
| `Unionpay`        | Unionpay          |
| `Visa`            | Visa              |
| `Vpay`            | Vpay              |