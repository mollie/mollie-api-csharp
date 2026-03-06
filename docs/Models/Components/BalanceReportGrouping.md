# BalanceReportGrouping

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceReportGrouping.StatusBalances;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceReportGrouping.Of("custom_value");
```


## Values

| Name                    | Value                   |
| ----------------------- | ----------------------- |
| `StatusBalances`        | status-balances         |
| `TransactionCategories` | transaction-categories  |