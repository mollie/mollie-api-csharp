# EntityBalanceCurrency

The balance's ISO 4217 currency code.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityBalanceCurrency.Eur;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityBalanceCurrency.Of("custom_value");
```


## Values

| Name  | Value |
| ----- | ----- |
| `Eur` | EUR   |
| `Gbp` | GBP   |
| `Chf` | CHF   |
| `Dkk` | DKK   |
| `Nok` | NOK   |
| `Pln` | PLN   |
| `Sek` | SEK   |
| `Usd` | USD   |
| `Czk` | CZK   |
| `Huf` | HUF   |
| `Aud` | AUD   |
| `Cad` | CAD   |
| `Ron` | RON   |