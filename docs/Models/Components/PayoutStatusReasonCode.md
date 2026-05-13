# PayoutStatusReasonCode

A machine-readable code describing the reason for the payout's current status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PayoutStatusReasonCode.Requested;

// Open enum: use .Of() to create instances from custom string values
var custom = PayoutStatusReasonCode.Of("custom_value");
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `Requested`            | requested              |
| `Initiated`            | initiated              |
| `ProcessingAtBank`     | processing_at_bank     |
| `Completed`            | completed              |
| `Canceled`             | canceled               |
| `Failed`               | failed                 |
| `InsufficientFunds`    | insufficient_funds     |
| `Returned`             | returned               |
| `InvalidRequest`       | invalid_request        |
| `OrganizationInactive` | organization_inactive  |
| `PayoutsBlocked`       | payouts_blocked        |
| `BankProcessingFailed` | bank_processing_failed |
| `BalanceNotFound`      | balance_not_found      |
| `Expired`              | expired                |