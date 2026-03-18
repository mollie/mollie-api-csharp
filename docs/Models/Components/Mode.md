# Mode

Whether this entity was created in live mode or in test mode.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = Mode.Live;

// Open enum: use .Of() to create instances from custom string values
var custom = Mode.Of("custom_value");
```


## Values

| Name   | Value  |
| ------ | ------ |
| `Live` | live   |
| `Test` | test   |