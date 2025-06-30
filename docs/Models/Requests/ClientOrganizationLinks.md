# ClientOrganizationLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                         | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `Self`                                                                                        | [ClientOrganizationSelf](../../Models/Requests/ClientOrganizationSelf.md)                     | :heavy_minus_sign:                                                                            | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field.    |
| `Dashboard`                                                                                   | [ListClientsOrganizationDashboard](../../Models/Requests/ListClientsOrganizationDashboard.md) | :heavy_minus_sign:                                                                            | Direct link to the organization's Mollie dashboard.                                           |
| `Documentation`                                                                               | [ClientOrganizationDocumentation](../../Models/Requests/ClientOrganizationDocumentation.md)   | :heavy_minus_sign:                                                                            | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field.    |