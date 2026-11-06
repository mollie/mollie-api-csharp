# EntityReportStatus

The report's current status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityReportStatus.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityReportStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Pending`   | pending     |
| `Completed` | completed   |
| `Failed`    | failed      |