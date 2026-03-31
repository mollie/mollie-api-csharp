# CreditDebitIndicator

Indicates whether the transfer is a credit or debit transaction from the perspective of the account holder.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = CreditDebitIndicator.Credit;

// Open enum: use .Of() to create instances from custom string values
var custom = CreditDebitIndicator.Of("custom_value");
```


## Values

| Name     | Value    |
| -------- | -------- |
| `Credit` | credit   |
| `Debit`  | debit    |