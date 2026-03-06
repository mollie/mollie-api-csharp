# SalesInvoiceRecipientTypeResponse

The type of recipient, either `consumer` or `business`. This will determine what further fields are
required on the `recipient` object.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceRecipientTypeResponse.Consumer;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceRecipientTypeResponse.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Consumer` | consumer   |
| `Business` | business   |