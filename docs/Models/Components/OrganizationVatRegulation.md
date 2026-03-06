# OrganizationVatRegulation

Mollie applies Dutch VAT for merchants based in The Netherlands, British VAT for merchants based in The United
Kingdom, and shifted VAT for merchants in the European Union.

The field is not present for merchants residing in other countries.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = OrganizationVatRegulation.Dutch;

// Open enum: use .Of() to create instances from custom string values
var custom = OrganizationVatRegulation.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Dutch`   | dutch     |
| `British` | british   |
| `Shifted` | shifted   |