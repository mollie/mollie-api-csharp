# SalesInvoiceRecipientLocaleResponse

The locale for the recipient, to be used for translations in PDF generation and payment pages.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceRecipientLocaleResponse.EnUS;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceRecipientLocaleResponse.Of("custom_value");
```


## Values

| Name   | Value  |
| ------ | ------ |
| `EnUS` | en_US  |
| `EnGB` | en_GB  |
| `Nlnl` | nl_NL  |
| `NlBE` | nl_BE  |
| `Dede` | de_DE  |
| `DeAT` | de_AT  |
| `DeCH` | de_CH  |
| `Frfr` | fr_FR  |
| `FrBE` | fr_BE  |