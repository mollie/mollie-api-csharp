# SalesInvoiceStatusResponse

The current status of the invoice.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceStatusResponse.Draft;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceStatusResponse.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Draft`           | draft             |
| `Issuing`         | issuing           |
| `Issued`          | issued            |
| `PendingPayment`  | pending-payment   |
| `Paid`            | paid              |
| `Overdue`         | overdue           |
| `PaymentReversed` | payment_reversed  |
| `Cancelled`       | cancelled         |
| `Expired`         | expired           |
| `Failed`          | failed            |