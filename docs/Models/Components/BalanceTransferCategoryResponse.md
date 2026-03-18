# BalanceTransferCategoryResponse

The type of the transfer. Different fees may apply to different types of transfers.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransferCategoryResponse.InvoiceCollection;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceTransferCategoryResponse.Of("custom_value");
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