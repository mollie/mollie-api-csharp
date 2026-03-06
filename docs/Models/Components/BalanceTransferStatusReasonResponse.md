# BalanceTransferStatusReasonResponse

A machine-readable code that indicates the reason for the transfer's status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransferStatusReasonResponse.RequestCreated;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceTransferStatusReasonResponse.Of("custom_value");
```


## Values

| Name                        | Value                       |
| --------------------------- | --------------------------- |
| `RequestCreated`            | request_created             |
| `Success`                   | success                     |
| `SourceNotAllowed`          | source_not_allowed          |
| `DestinationNotAllowed`     | destination_not_allowed     |
| `InsufficientFunds`         | insufficient_funds          |
| `InvalidSourceBalance`      | invalid_source_balance      |
| `InvalidDestinationBalance` | invalid_destination_balance |
| `TransferRequestExpired`    | transfer_request_expired    |
| `TransferLimitReached`      | transfer_limit_reached      |