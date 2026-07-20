# ListDraftTransferResponseStatus

The status of the draft transfer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListDraftTransferResponseStatus.AwaitingInitiation;

// Open enum: use .Of() to create instances from custom string values
var custom = ListDraftTransferResponseStatus.Of("custom_value");
```


## Values

| Name                 | Value                |
| -------------------- | -------------------- |
| `AwaitingInitiation` | awaiting-initiation  |
| `Initiated`          | initiated            |
| `Declined`           | declined             |