# ListEntityInvoiceVatAmount

VAT amount of the invoice. Only applicable to merchants registered in the Netherlands. For EU merchants, VAT will
be shifted to the recipient (as per article 44 and 196 in the EU VAT Directive 2006/112). For merchants outside
the EU, no VAT will be charged.


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Currency`                                                          | *string*                                                            | :heavy_check_mark:                                                  | A three-character ISO 4217 currency code.                           | EUR                                                                 |
| `Value`                                                             | *string*                                                            | :heavy_check_mark:                                                  | A string containing an exact monetary amount in the given currency. | 10.00                                                               |