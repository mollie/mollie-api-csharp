# Action

The action performed on the unmatched credit transfer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = Action.Match;

// Open enum: use .Of() to create instances from custom string values
var custom = Action.Of("custom_value");
```


## Values

| Name     | Value    |
| -------- | -------- |
| `Match`  | match    |
| `Return` | return   |