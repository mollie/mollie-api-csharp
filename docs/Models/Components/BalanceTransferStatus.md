# BalanceTransferStatus

The status of the transfer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransferStatus.Created;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceTransferStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Created`   | created     |
| `Failed`    | failed      |
| `Succeeded` | succeeded   |