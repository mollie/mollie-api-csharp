# ListEntitySettlementStatus

The status of the settlement.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListEntitySettlementStatus.Open;

// Open enum: use .Of() to create instances from custom string values
var custom = ListEntitySettlementStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Open`    | open      |
| `Pending` | pending   |
| `Paidout` | paidout   |
| `Failed`  | failed    |