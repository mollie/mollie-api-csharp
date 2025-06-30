# GetOrganizationLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [GetOrganizationSelf](../../Models/Requests/GetOrganizationSelf.md)                        | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Dashboard`                                                                                | [GetOrganizationDashboard](../../Models/Requests/GetOrganizationDashboard.md)              | :heavy_minus_sign:                                                                         | Direct link to the organization's Mollie dashboard.                                        |
| `Documentation`                                                                            | [GetOrganizationDocumentation](../../Models/Requests/GetOrganizationDocumentation.md)      | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |