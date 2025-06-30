# GetWebhookEventLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [GetWebhookEventSelf](../../Models/Requests/GetWebhookEventSelf.md)                        | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Documentation`                                                                            | [GetWebhookEventDocumentation](../../Models/Requests/GetWebhookEventDocumentation.md)      | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Entity`                                                                                   | [LinksEntity](../../Models/Requests/LinksEntity.md)                                        | :heavy_minus_sign:                                                                         | The API resource URL of the entity that this event belongs to.                             |