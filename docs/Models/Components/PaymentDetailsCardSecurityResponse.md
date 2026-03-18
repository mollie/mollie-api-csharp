# PaymentDetailsCardSecurityResponse

The level of security applied during card processing.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsCardSecurityResponse.Normal;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsCardSecurityResponse.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Normal`       | normal         |
| `Threedsecure` | 3dsecure       |