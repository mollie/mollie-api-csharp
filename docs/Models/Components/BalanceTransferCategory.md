# BalanceTransferCategory

The type of the transfer. Different fees may apply to different types of transfers.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransferCategory.InvoiceCollection;
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `InvoiceCollection`    | invoice_collection     |
| `Purchase`             | purchase               |
| `Chargeback`           | chargeback             |
| `Refund`               | refund                 |
| `ServicePenalty`       | service_penalty        |
| `DiscountCompensation` | discount_compensation  |
| `ManualCorrection`     | manual_correction      |
| `OtherFee`             | other_fee              |