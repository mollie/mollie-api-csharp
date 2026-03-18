# ListPaymentResponseStatus

The payment's status. Refer to the [documentation regarding statuses](https://docs.mollie.com/docs/handling-payment-status) for more info about which
statuses occur at what point.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListPaymentResponseStatus.Open;

// Open enum: use .Of() to create instances from custom string values
var custom = ListPaymentResponseStatus.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Open`       | open         |
| `Pending`    | pending      |
| `Authorized` | authorized   |
| `Paid`       | paid         |
| `Canceled`   | canceled     |
| `Expired`    | expired      |
| `Failed`     | failed       |