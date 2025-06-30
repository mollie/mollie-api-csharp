# GetMandateLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [GetMandateSelf](../../Models/Requests/GetMandateSelf.md)                                  | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Customer`                                                                                 | [GetMandateCustomer](../../Models/Requests/GetMandateCustomer.md)                          | :heavy_minus_sign:                                                                         | The API resource URL of the [customer](get-customer) that this mandate belongs to.         |
| `Documentation`                                                                            | [GetMandateDocumentation](../../Models/Requests/GetMandateDocumentation.md)                | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |