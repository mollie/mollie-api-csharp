# BalancePrepaymentPartType

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalancePrepaymentPartType.Fee;

// Open enum: use .Of() to create instances from custom string values
var custom = BalancePrepaymentPartType.Of("custom_value");
```


## Values

| Name                      | Value                     |
| ------------------------- | ------------------------- |
| `Fee`                     | fee                       |
| `FeeReimbursement`        | fee-reimbursement         |
| `FeeDiscount`             | fee-discount              |
| `FeeVat`                  | fee-vat                   |
| `FeeRoundingCompensation` | fee-rounding-compensation |