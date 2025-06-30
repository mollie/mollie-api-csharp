# GetInvoiceLine


## Fields

| Field                                                                      | Type                                                                       | Required                                                                   | Description                                                                |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- |
| `Period`                                                                   | *string*                                                                   | :heavy_minus_sign:                                                         | The administrative period in `YYYY-MM` on which the line should be booked. |
| `Description`                                                              | *string*                                                                   | :heavy_minus_sign:                                                         | Description of the product.                                                |
| `Count`                                                                    | *long*                                                                     | :heavy_minus_sign:                                                         | Number of products invoiced. For example, the number of payments.          |
| `VatPercentage`                                                            | *long*                                                                     | :heavy_minus_sign:                                                         | VAT percentage rate that applies to this product.                          |
| `Amount`                                                                   | [GetInvoiceAmount](../../Models/Requests/GetInvoiceAmount.md)              | :heavy_minus_sign:                                                         | Line item amount excluding VAT.                                            |