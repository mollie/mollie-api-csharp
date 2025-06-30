# ClientLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [ClientSelf](../../Models/Requests/ClientSelf.md)                                          | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Organization`                                                                             | [ListClientsLinksOrganization](../../Models/Requests/ListClientsLinksOrganization.md)      | :heavy_minus_sign:                                                                         | The API resource URL of the client's organization.                                         |
| `Onboarding`                                                                               | [ListClientsLinksOnboarding](../../Models/Requests/ListClientsLinksOnboarding.md)          | :heavy_minus_sign:                                                                         | The API resource URL of the client's onboarding status.                                    |
| `Documentation`                                                                            | [ClientDocumentation](../../Models/Requests/ClientDocumentation.md)                        | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |