# SequenceTypeResponse

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SequenceTypeResponse.Oneoff;

// Open enum: use .Of() to create instances from custom string values
var custom = SequenceTypeResponse.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Oneoff`    | oneoff      |
| `First`     | first       |
| `Recurring` | recurring   |