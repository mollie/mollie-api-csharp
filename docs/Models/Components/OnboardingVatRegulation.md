# OnboardingVatRegulation

Mollie applies Dutch VAT for merchants based in The Netherlands, British VAT for merchants based in
The United Kingdom, and shifted VAT for merchants in the European Union.

The field can be omitted for merchants residing in other countries.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = OnboardingVatRegulation.Dutch;
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Dutch`   | dutch     |
| `British` | british   |
| `Shifted` | shifted   |