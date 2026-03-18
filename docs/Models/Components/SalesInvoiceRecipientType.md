# SalesInvoiceRecipientType

The type of recipient, either `consumer` or `business`. This will determine what further fields are
required on the `recipient` object.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceRecipientType.Consumer;
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Consumer` | consumer   |
| `Business` | business   |