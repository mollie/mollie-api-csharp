# ListRefundResponseStatus

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListRefundResponseStatus.Queued;

// Open enum: use .Of() to create instances from custom string values
var custom = ListRefundResponseStatus.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Queued`     | queued       |
| `Pending`    | pending      |
| `Processing` | processing   |
| `Refunded`   | refunded     |
| `Failed`     | failed       |
| `Canceled`   | canceled     |