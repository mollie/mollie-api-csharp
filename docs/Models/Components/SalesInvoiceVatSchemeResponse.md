# SalesInvoiceVatSchemeResponse

The VAT scheme to create the invoice for. You must be enrolled with One Stop Shop enabled to use it.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceVatSchemeResponse.Standard;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceVatSchemeResponse.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Standard`    | standard      |
| `OneStopShop` | one-stop-shop |