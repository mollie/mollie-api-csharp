# SettlementMode

Whether this entity was created in live mode or in test mode. Settlements are always in live mode.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SettlementMode.Live;

// Open enum: use .Of() to create instances from custom string values
var custom = SettlementMode.Of("custom_value");
```


## Values

| Name   | Value  |
| ------ | ------ |
| `Live` | live   |