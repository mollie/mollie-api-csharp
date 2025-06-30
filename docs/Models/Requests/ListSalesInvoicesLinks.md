# ListSalesInvoicesLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListSalesInvoicesSelf](../../Models/Requests/ListSalesInvoicesSelf.md)                    | :heavy_minus_sign:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListSalesInvoicesPrevious](../../Models/Requests/ListSalesInvoicesPrevious.md)            | :heavy_minus_sign:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListSalesInvoicesNext](../../Models/Requests/ListSalesInvoicesNext.md)                    | :heavy_minus_sign:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListSalesInvoicesDocumentation](../../Models/Requests/ListSalesInvoicesDocumentation.md)  | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |