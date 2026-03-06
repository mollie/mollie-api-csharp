# MandateDetailsCardLabelResponse

The card's label. Available for card mandates, if the card label could be detected.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = MandateDetailsCardLabelResponse.AmericanExpress;

// Open enum: use .Of() to create instances from custom string values
var custom = MandateDetailsCardLabelResponse.Of("custom_value");
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