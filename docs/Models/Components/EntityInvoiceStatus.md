# EntityInvoiceStatus

Status of the invoice.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityInvoiceStatus.Open;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityInvoiceStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Open`    | open      |
| `Paid`    | paid      |
| `Overdue` | overdue   |