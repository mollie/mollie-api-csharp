# GetClientLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [GetClientSelf](../../Models/Requests/GetClientSelf.md)                                    | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Organization`                                                                             | [GetClientLinksOrganization](../../Models/Requests/GetClientLinksOrganization.md)          | :heavy_minus_sign:                                                                         | The API resource URL of the client's organization.                                         |
| `Onboarding`                                                                               | [GetClientLinksOnboarding](../../Models/Requests/GetClientLinksOnboarding.md)              | :heavy_minus_sign:                                                                         | The API resource URL of the client's onboarding status.                                    |
| `Documentation`                                                                            | [GetClientDocumentation](../../Models/Requests/GetClientDocumentation.md)                  | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |