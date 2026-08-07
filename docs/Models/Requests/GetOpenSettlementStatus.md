# GetOpenSettlementStatus

The status of the settlement.

## Example Usage

```csharp
using Mollie.Models.Requests;

var value = GetOpenSettlementStatus.Open;

// Open enum: use .Of() to create instances from custom string values
var custom = GetOpenSettlementStatus.Of("custom_value");
```


## Values

| Name               | Value              |
| ------------------ | ------------------ |
| `Open`             | open               |
| `Pending`          | pending            |
| `ProcessingAtBank` | processing-at-bank |
| `Paidout`          | paidout            |
| `Failed`           | failed             |