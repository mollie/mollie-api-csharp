# EntityBalanceStatus

The status of the balance.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityBalanceStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityBalanceStatus.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Active`   | active     |
| `Inactive` | inactive   |