# ListPaymentLinksLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListPaymentLinksSelf](../../Models/Requests/ListPaymentLinksSelf.md)                      | :heavy_minus_sign:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListPaymentLinksPrevious](../../Models/Requests/ListPaymentLinksPrevious.md)              | :heavy_minus_sign:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListPaymentLinksNext](../../Models/Requests/ListPaymentLinksNext.md)                      | :heavy_minus_sign:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListPaymentLinksDocumentation](../../Models/Requests/ListPaymentLinksDocumentation.md)    | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |