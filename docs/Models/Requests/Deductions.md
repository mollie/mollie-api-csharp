# Deductions

The total amount of deductions withheld from the movement. For example, if we charge a €0.29 fee on a €10 payment,
the deductions amount will be `{"currency":"EUR", "value":"-0.29"}`.

When moving funds to a balance, we always round the deduction to a 'real' amount. Any differences between these
real-time rounded amounts and the final invoice will be compensated when the invoice is generated.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Currency`                                                          | *string*                                                            | :heavy_check_mark:                                                  | A three-character ISO 4217 currency code.                           | EUR                                                                 |
| `Value`                                                             | *string*                                                            | :heavy_check_mark:                                                  | A string containing an exact monetary amount in the given currency. | 10.00                                                               |