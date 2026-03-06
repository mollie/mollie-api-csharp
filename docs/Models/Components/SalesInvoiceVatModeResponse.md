# SalesInvoiceVatModeResponse

The VAT mode to use for VAT calculation. `exclusive` mode means we will apply the relevant VAT on top of the
price. `inclusive` means the prices you are providing to us already contain the VAT you want to apply.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceVatModeResponse.Exclusive;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceVatModeResponse.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Exclusive` | exclusive   |
| `Inclusive` | inclusive   |