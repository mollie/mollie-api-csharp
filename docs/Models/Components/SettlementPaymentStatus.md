# SettlementPaymentStatus

The payment's status. Settlement payments always have a status of `paid`.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SettlementPaymentStatus.Paid;

// Open enum: use .Of() to create instances from custom string values
var custom = SettlementPaymentStatus.Of("custom_value");
```


## Values

| Name   | Value  |
| ------ | ------ |
| `Paid` | paid   |