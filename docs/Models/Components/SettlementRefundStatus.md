# SettlementRefundStatus

The refund's status. Settlement refunds always have a status of `refunded`.

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