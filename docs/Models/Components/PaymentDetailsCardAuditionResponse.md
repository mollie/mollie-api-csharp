# PaymentDetailsCardAuditionResponse

The card's target audience, if known.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsCardAuditionResponse.Consumer;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsCardAuditionResponse.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Consumer` | consumer   |
| `Business` | business   |