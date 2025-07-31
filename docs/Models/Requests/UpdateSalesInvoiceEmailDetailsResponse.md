# UpdateSalesInvoiceEmailDetailsResponse

Used when setting an invoice to status of either `issued` or `paid`. Will be used to issue the invoice to the
recipient with the provided `subject` and `body`. Required for `issued` status.


## Fields

| Field                                                                          | Type                                                                           | Required                                                                       | Description                                                                    | Example                                                                        |
| ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ |
| `Subject`                                                                      | *string*                                                                       | :heavy_check_mark:                                                             | The subject of the email to be sent.                                           | Your invoice is available                                                      |
| `Body`                                                                         | *string*                                                                       | :heavy_check_mark:                                                             | The body of the email to be sent. To add newline characters, you can use `\n`. | Please find your invoice enclosed.                                             |