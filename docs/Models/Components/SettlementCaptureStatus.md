# SettlementCaptureStatus

The capture's status. Settlement captures always have a status of `succeeded`.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SettlementCaptureStatus.Succeeded;

// Open enum: use .Of() to create instances from custom string values
var custom = SettlementCaptureStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Succeeded` | succeeded   |