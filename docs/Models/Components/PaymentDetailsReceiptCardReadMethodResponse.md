# PaymentDetailsReceiptCardReadMethodResponse

The method by which the card was read by the terminal.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsReceiptCardReadMethodResponse.Chip;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsReceiptCardReadMethodResponse.Of("custom_value");
```


## Values

| Name                     | Value                    |
| ------------------------ | ------------------------ |
| `Chip`                   | chip                     |
| `MagneticStripe`         | magnetic-stripe          |
| `NearFieldCommunication` | near-field-communication |
| `Contactless`            | contactless              |
| `Moto`                   | moto                     |