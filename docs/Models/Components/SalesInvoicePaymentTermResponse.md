# SalesInvoicePaymentTermResponse

The payment term to be set on the invoice.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoicePaymentTermResponse.Sevendays;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoicePaymentTermResponse.Of("custom_value");
```


## Values

| Name                      | Value                     |
| ------------------------- | ------------------------- |
| `Sevendays`               | 7 days                    |
| `Fourteendays`            | 14 days                   |
| `Thirtydays`              | 30 days                   |
| `FortyFivedays`           | 45 days                   |
| `Sixtydays`               | 60 days                   |
| `Ninetydays`              | 90 days                   |
| `OneHundredAndTwentydays` | 120 days                  |