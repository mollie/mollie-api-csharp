# DraftTransferStatusReasonCodeResponse

A machine-readable code that indicates the reason for the draft transfer's current status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = DraftTransferStatusReasonCodeResponse.DeletedByCreator;

// Open enum: use .Of() to create instances from custom string values
var custom = DraftTransferStatusReasonCodeResponse.Of("custom_value");
```


## Values

| Name                  | Value                 |
| --------------------- | --------------------- |
| `DeletedByCreator`    | deleted-by-creator    |
| `DeclinedByInitiator` | declined-by-initiator |
| `AccountClosed`       | account-closed        |