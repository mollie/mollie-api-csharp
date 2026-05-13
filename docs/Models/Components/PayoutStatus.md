# PayoutStatus

The status of the payout.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PayoutStatus.Requested;

// Open enum: use .Of() to create instances from custom string values
var custom = PayoutStatus.Of("custom_value");
```


## Values

| Name               | Value              |
| ------------------ | ------------------ |
| `Requested`        | requested          |
| `Initiated`        | initiated          |
| `ProcessingAtBank` | processing-at-bank |
| `Completed`        | completed          |
| `Failed`           | failed             |
| `Canceled`         | canceled           |