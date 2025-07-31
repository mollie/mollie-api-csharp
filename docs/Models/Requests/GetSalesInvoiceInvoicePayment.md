# GetSalesInvoiceInvoicePayment

The URL your customer should visit to make payment for the invoice. This is where you should redirect the
customer to unless the `status` is set to `paid`.


## Fields

| Field                                                       | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `Href`                                                      | *string*                                                    | :heavy_check_mark:                                          | The actual URL string.                                      | https://...                                                 |
| `Type`                                                      | *string*                                                    | :heavy_check_mark:                                          | The content type of the page or endpoint the URL points to. | application/hal+json                                        |