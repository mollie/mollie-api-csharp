# ListMandatesLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListMandatesSelf](../../Models/Requests/ListMandatesSelf.md)                              | :heavy_minus_sign:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListMandatesPrevious](../../Models/Requests/ListMandatesPrevious.md)                      | :heavy_minus_sign:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListMandatesNext](../../Models/Requests/ListMandatesNext.md)                              | :heavy_minus_sign:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListMandatesDocumentation](../../Models/Requests/ListMandatesDocumentation.md)            | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |