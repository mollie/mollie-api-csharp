# SalesInvoiceEInvoiceStatus

The e-invoice submission status for the invoice, if it was configured to be an e-invoice.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceEInvoiceStatus.Issuing;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceEInvoiceStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Issuing` | issuing   |
| `Issued`  | issued    |
| `Failed`  | failed    |