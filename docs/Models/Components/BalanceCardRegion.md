# BalanceCardRegion

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceCardRegion.IntraEea;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceCardRegion.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `IntraEea` | intra-eea  |
| `IntraEu`  | intra-eu   |
| `Domestic` | domestic   |
| `Other`    | other      |