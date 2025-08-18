# ListRefundsLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListRefundsSelf](../../Models/Requests/ListRefundsSelf.md)                                | :heavy_check_mark:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListRefundsPrevious](../../Models/Requests/ListRefundsPrevious.md)                        | :heavy_check_mark:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListRefundsNext](../../Models/Requests/ListRefundsNext.md)                                | :heavy_check_mark:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListRefundsDocumentation](../../Models/Requests/ListRefundsDocumentation.md)              | :heavy_check_mark:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |