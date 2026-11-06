# ReportTypeResponse

The type of report to generate. Determines which other fields the request needs, and which fields show up
on the resulting report.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ReportTypeResponse.TransactionMargin;

// Open enum: use .Of() to create instances from custom string values
var custom = ReportTypeResponse.Of("custom_value");
```


## Values

| Name                | Value               |
| ------------------- | ------------------- |
| `TransactionMargin` | transaction_margin  |