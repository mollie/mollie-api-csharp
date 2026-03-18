# BalanceTransferDestinationType

The default destination of automatic scheduled transfers. Currently only `bank-account` is supported.

* `bank-account` — Transfer the balance amount to an external bank account

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransferDestinationType.BankAccount;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceTransferDestinationType.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `BankAccount` | bank-account  |