# GetInvoiceLinks

An object with several relevant URLs. Every URL object will contain an `href` and a `type` field.


## Fields

| Field                                                                       | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `Self`                                                                      | [GetInvoiceSelf](../../Models/Requests/GetInvoiceSelf.md)                   | :heavy_minus_sign:                                                          | URL to the current invoice resource.                                        |
| `Pdf`                                                                       | [Pdf](../../Models/Requests/Pdf.md)                                         | :heavy_minus_sign:                                                          | URL to a downloadable PDF of the invoice.                                   |
| `Documentation`                                                             | [GetInvoiceDocumentation](../../Models/Requests/GetInvoiceDocumentation.md) | :heavy_minus_sign:                                                          | URL to the API documentation.                                               |