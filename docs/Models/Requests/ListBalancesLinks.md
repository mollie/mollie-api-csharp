# ListBalancesLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListBalancesSelf](../../Models/Requests/ListBalancesSelf.md)                              | :heavy_minus_sign:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListBalancesPrevious](../../Models/Requests/ListBalancesPrevious.md)                      | :heavy_minus_sign:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListBalancesNext](../../Models/Requests/ListBalancesNext.md)                              | :heavy_minus_sign:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListBalancesDocumentation](../../Models/Requests/ListBalancesDocumentation.md)            | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |