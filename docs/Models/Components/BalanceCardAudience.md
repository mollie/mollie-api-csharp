# BalanceCardAudience

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceCardAudience.Corporate;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceCardAudience.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Corporate` | corporate   |
| `Other`     | other       |