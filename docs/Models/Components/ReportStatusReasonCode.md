# ReportStatusReasonCode

A machine-readable code for the failure reason.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ReportStatusReasonCode.GenerationFailed;

// Open enum: use .Of() to create instances from custom string values
var custom = ReportStatusReasonCode.Of("custom_value");
```


## Values

| Name                     | Value                    |
| ------------------------ | ------------------------ |
| `GenerationFailed`       | generation-failed        |
| `EmptyReport`            | empty-report             |
| `ReportValidationFailed` | report-validation-failed |