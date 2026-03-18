# SalesInvoicePaymentDetailsSourceResponse

The way through which the invoice is to be set to paid.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoicePaymentDetailsSourceResponse.Manual;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoicePaymentDetailsSourceResponse.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Manual`      | manual        |
| `PaymentLink` | payment-link  |
| `Payment`     | payment       |