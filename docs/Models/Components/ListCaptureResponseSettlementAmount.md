# ~~ListCaptureResponseSettlementAmount~~

**Deprecated.** This field will be removed on January 1st, 2027. Use the [Settlements API](list-settlements) or
the [List balance transactions endpoint](list-balance-transactions) for settlement data.

The amount that will be settled to your account for this capture, converted to the currency your account is
settled in. Only available once the capture is finalized and the final settlement amount has been determined.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Currency`                                                          | *string*                                                            | :heavy_check_mark:                                                  | A three-character ISO 4217 currency code.                           | EUR                                                                 |
| `Value`                                                             | *string*                                                            | :heavy_check_mark:                                                  | A string containing an exact monetary amount in the given currency. | 10.00                                                               |