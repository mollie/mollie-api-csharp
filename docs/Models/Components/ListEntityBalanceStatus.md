# ListEntityBalanceStatus

The status of the balance.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListEntityBalanceStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = ListEntityBalanceStatus.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Active`   | active     |
| `Inactive` | inactive   |