# ListWebhooksLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListWebhooksSelf](../../Models/Requests/ListWebhooksSelf.md)                              | :heavy_minus_sign:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListWebhooksPrevious](../../Models/Requests/ListWebhooksPrevious.md)                      | :heavy_minus_sign:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListWebhooksNext](../../Models/Requests/ListWebhooksNext.md)                              | :heavy_minus_sign:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListWebhooksDocumentation](../../Models/Requests/ListWebhooksDocumentation.md)            | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |