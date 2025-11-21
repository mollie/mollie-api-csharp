# EntityChargebackSettlementAmount

This optional field will contain the approximate amount that will be deducted from your account balance, converted
to the currency your account is settled in.

The amount is a **negative** amount.

Since the field contains an estimated amount during chargeback processing, it may change over time. To retrieve
accurate settlement amounts we recommend using the [List balance transactions endpoint](list-balance-transactions)
instead.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Currency`                                                          | *string*                                                            | :heavy_check_mark:                                                  | A three-character ISO 4217 currency code.                           | EUR                                                                 |
| `Value`                                                             | *string*                                                            | :heavy_check_mark:                                                  | A string containing an exact monetary amount in the given currency. | 10.00                                                               |