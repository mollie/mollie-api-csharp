# BalanceCardIssuer

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceCardIssuer.Amex;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceCardIssuer.Of("custom_value");
```


## Values

| Name            | Value           |
| --------------- | --------------- |
| `Amex`          | amex            |
| `Maestro`       | maestro         |
| `CarteBancaire` | carte-bancaire  |
| `Other`         | other           |