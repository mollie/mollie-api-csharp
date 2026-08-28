# SettlementRefundStatus

The refund's status. Settlement refunds are normally `refunded`, but can be `failed` if the refund
could not be processed.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SettlementRefundStatus.Refunded;

// Open enum: use .Of() to create instances from custom string values
var custom = SettlementRefundStatus.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Refunded` | refunded   |
| `Failed`   | failed     |