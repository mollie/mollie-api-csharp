# Totals

Totals are grouped according to the chosen grouping rule. The example response should give a good idea of what a
typical grouping looks like.

If grouping `status-balances` is chosen, the main grouping is as follows:

* `pendingBalance` containing an `open`, `pending`, `movedToAvailable`, and `close` sub-group
* `availableBalance` containing an `open`, `movedFromPending`, `immediatelyAvailable`, and `close` sub-group

If grouping `transaction-categories` is chosen, the main grouping is as follows:

* `open` and `close` groups, each containing a `pending` and `available` sub-group
* Transaction type groups such as `payments`, `refunds`, `chargebacks`, `capital`, `transfers`, `fee-prepayments`, `corrections`, `topups`
each containing a `pending`, `movedToAvailable`, and
`immediatelyAvailable` sub-group

Each sub-group typically has:

* An `amount` object containing the group's total amount
* A `count` integer if relevant (for example, counting the number of refunds)
* A `subtotals` array containing more sub-group objects if applicable


## Fields

| Field                                                                   | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `PendingBalance`                                                        | [PendingBalance](../../Models/Components/PendingBalance.md)             | :heavy_minus_sign:                                                      | The pending balance. Only available if grouping is `status-balances`.   |
| `AvailableBalance`                                                      | [AvailableBalance](../../Models/Components/AvailableBalance.md)         | :heavy_minus_sign:                                                      | The available balance. Only available if grouping is `status-balances`. |
| `Open`                                                                  | [Open](../../Models/Components/Open.md)                                 | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Close`                                                                 | [Close](../../Models/Components/Close.md)                               | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Payments`                                                              | [Models.Components.Payments](../../Models/Components/Payments.md)       | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Refunds`                                                               | [Models.Components.Refunds](../../Models/Components/Refunds.md)         | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Chargebacks`                                                           | [Models.Components.Chargebacks](../../Models/Components/Chargebacks.md) | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Capital`                                                               | [Capital](../../Models/Components/Capital.md)                           | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Transfers`                                                             | [Transfers](../../Models/Components/Transfers.md)                       | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `FeePrepayments`                                                        | [FeePrepayments](../../Models/Components/FeePrepayments.md)             | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Corrections`                                                           | [Corrections](../../Models/Components/Corrections.md)                   | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |
| `Topups`                                                                | [Topups](../../Models/Components/Topups.md)                             | :heavy_minus_sign:                                                      | Only available on `transaction-categories` grouping.                    |