# TerminalModel

The model of the terminal. For example for a PAX A920, this field's value will be `A920`.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = TerminalModel.A35;

// Open enum: use .Of() to create instances from custom string values
var custom = TerminalModel.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `A35`     | A35       |
| `A77`     | A77       |
| `A920`    | A920      |
| `A920Pro` | A920Pro   |
| `Im30`    | IM30      |
| `Tap`     | Tap       |