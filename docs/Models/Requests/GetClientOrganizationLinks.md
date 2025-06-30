# GetClientOrganizationLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                             | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `Self`                                                                                            | [GetClientOrganizationSelf](../../Models/Requests/GetClientOrganizationSelf.md)                   | :heavy_minus_sign:                                                                                | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field.        |
| `Dashboard`                                                                                       | [GetClientOrganizationDashboard](../../Models/Requests/GetClientOrganizationDashboard.md)         | :heavy_minus_sign:                                                                                | Direct link to the organization's Mollie dashboard.                                               |
| `Documentation`                                                                                   | [GetClientOrganizationDocumentation](../../Models/Requests/GetClientOrganizationDocumentation.md) | :heavy_minus_sign:                                                                                | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field.        |