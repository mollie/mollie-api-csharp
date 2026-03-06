# PaymentDetailsCardFundingResponse

The card type.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsCardFundingResponse.Debit;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsCardFundingResponse.Of("custom_value");
```


## Values

| Name            | Value           |
| --------------- | --------------- |
| `Debit`         | debit           |
| `Credit`        | credit          |
| `Prepaid`       | prepaid         |
| `DeferredDebit` | deferred-debit  |