# DraftTransferResponseStatus

The status of the draft transfer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = DraftTransferResponseStatus.PendingReview;

// Open enum: use .Of() to create instances from custom string values
var custom = DraftTransferResponseStatus.Of("custom_value");
```


## Values

| Name            | Value           |
| --------------- | --------------- |
| `PendingReview` | pending-review  |
| `Approved`      | approved        |
| `Declined`      | declined        |