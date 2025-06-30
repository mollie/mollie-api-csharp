# MandateLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Self`                                                                                     | [MandateSelf](../../Models/Requests/MandateSelf.md)                                        | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |
| `Customer`                                                                                 | [ListMandatesCustomer](../../Models/Requests/ListMandatesCustomer.md)                      | :heavy_minus_sign:                                                                         | The API resource URL of the [customer](get-customer) that this mandate belongs to.         |
| `Documentation`                                                                            | [MandateDocumentation](../../Models/Requests/MandateDocumentation.md)                      | :heavy_minus_sign:                                                                         | In v2 endpoints, URLs are commonly represented as objects with an `href` and `type` field. |