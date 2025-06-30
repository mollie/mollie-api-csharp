# GetCurrentOrganizationLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                               | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `Self`                                                                                              | [GetCurrentOrganizationSelf](../../Models/Requests/GetCurrentOrganizationSelf.md)                   | :heavy_minus_sign:                                                                                  | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field.          |
| `Dashboard`                                                                                         | [GetCurrentOrganizationDashboard](../../Models/Requests/GetCurrentOrganizationDashboard.md)         | :heavy_minus_sign:                                                                                  | Direct link to the organization's Mollie dashboard.                                                 |
| `Documentation`                                                                                     | [GetCurrentOrganizationDocumentation](../../Models/Requests/GetCurrentOrganizationDocumentation.md) | :heavy_minus_sign:                                                                                  | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field.          |