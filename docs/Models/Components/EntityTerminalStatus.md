# EntityTerminalStatus

The status of the terminal.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityTerminalStatus.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityTerminalStatus.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Pending`  | pending    |
| `Active`   | active     |
| `Inactive` | inactive   |