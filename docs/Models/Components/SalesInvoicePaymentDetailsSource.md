# SalesInvoicePaymentDetailsSource

The way through which the invoice is to be set to paid.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoicePaymentDetailsSource.Manual;
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Manual`      | manual        |
| `PaymentLink` | payment-link  |
| `Payment`     | payment       |