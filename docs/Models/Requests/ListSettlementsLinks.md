# ListSettlementsLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListSettlementsSelf](../../Models/Requests/ListSettlementsSelf.md)                        | :heavy_check_mark:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListSettlementsPrevious](../../Models/Requests/ListSettlementsPrevious.md)                | :heavy_check_mark:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListSettlementsNext](../../Models/Requests/ListSettlementsNext.md)                        | :heavy_check_mark:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListSettlementsDocumentation](../../Models/Requests/ListSettlementsDocumentation.md)      | :heavy_check_mark:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |