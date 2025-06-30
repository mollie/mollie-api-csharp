# UpdatePaymentLinkUnitPriceRequest

The price of a single item including VAT.

For example: `{"currency":"EUR", "value":"89.00"}` if the box of LEGO costs €89.00 each.

For types `discount`, `store_credit`, and `gift_card`, the unit price must be negative.

The unit price can be zero in case of free items.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Currency`                                                          | *string*                                                            | :heavy_check_mark:                                                  | A three-character ISO 4217 currency code.                           | EUR                                                                 |
| `Value`                                                             | *string*                                                            | :heavy_check_mark:                                                  | A string containing an exact monetary amount in the given currency. | 10.00                                                               |