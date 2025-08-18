# ListSubscriptionsLinks

Links to help navigate through the lists of items. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ListSubscriptionsSelf](../../Models/Requests/ListSubscriptionsSelf.md)                    | :heavy_check_mark:                                                                         | The URL to the current set of items.                                                       |
| `Previous`                                                                                 | [ListSubscriptionsPrevious](../../Models/Requests/ListSubscriptionsPrevious.md)            | :heavy_check_mark:                                                                         | The previous set of items, if available.                                                   |
| `Next`                                                                                     | [ListSubscriptionsNext](../../Models/Requests/ListSubscriptionsNext.md)                    | :heavy_check_mark:                                                                         | The next set of items, if available.                                                       |
| `Documentation`                                                                            | [ListSubscriptionsDocumentation](../../Models/Requests/ListSubscriptionsDocumentation.md)  | :heavy_check_mark:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |