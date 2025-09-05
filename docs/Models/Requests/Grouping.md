# Grouping

You can retrieve reports in two different formats. With the `status-balances` format, transactions are grouped
by status (e.g. `pending`, `available`), then by transaction type, and then by other sub-groupings where
available (e.g. payment method).

With the `transaction-categories` format, transactions are grouped by
transaction type, then by status, and then again by other sub-groupings where available.


## Values

| Name                    | Value                   |
| ----------------------- | ----------------------- |
| `StatusBalances`        | status-balances         |
| `TransactionCategories` | transaction-categories  |