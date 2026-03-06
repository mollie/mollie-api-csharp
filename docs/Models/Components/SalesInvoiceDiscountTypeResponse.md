# SalesInvoiceDiscountTypeResponse

The type of discount.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SalesInvoiceDiscountTypeResponse.Amount;

// Open enum: use .Of() to create instances from custom string values
var custom = SalesInvoiceDiscountTypeResponse.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Amount`     | amount       |
| `Percentage` | percentage   |