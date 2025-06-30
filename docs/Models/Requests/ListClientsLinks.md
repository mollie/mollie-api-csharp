# ListClientsLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListClientsSelf](../../Models/Requests/ListClientsSelf.md)                                | :heavy_minus_sign:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListClientsPrevious](../../Models/Requests/ListClientsPrevious.md)                        | :heavy_minus_sign:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListClientsNext](../../Models/Requests/ListClientsNext.md)                                | :heavy_minus_sign:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListClientsDocumentation](../../Models/Requests/ListClientsDocumentation.md)              | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |