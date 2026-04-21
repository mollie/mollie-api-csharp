# TransferStatus

The status of the transfer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = TransferStatus.Requested;

// Open enum: use .Of() to create instances from custom string values
var custom = TransferStatus.Of("custom_value");
```


## Values

| Name            | Value           |
| --------------- | --------------- |
| `Requested`     | requested       |
| `Initiated`     | initiated       |
| `PendingReview` | pending-review  |
| `Processed`     | processed       |
| `Failed`        | failed          |
| `Blocked`       | blocked         |
| `Returned`      | returned        |