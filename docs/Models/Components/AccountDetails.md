# AccountDetails

The account holder details and bank account information for the business account.


## Fields

| Field                                                        | Type                                                         | Required                                                     | Description                                                  | Example                                                      |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| `AccountHolderName`                                          | *string*                                                     | :heavy_check_mark:                                           | The name of the account holder.                              | Mollie B.V.                                                  |
| `Name`                                                       | *string*                                                     | :heavy_minus_sign:                                           | A name of the account.                                       | Main Checking Account                                        |
| `Currency`                                                   | *string*                                                     | :heavy_check_mark:                                           | The currency of the account in ISO 4217 format.              | EUR                                                          |
| `Iban`                                                       | *string*                                                     | :heavy_check_mark:                                           | The IBAN (International Bank Account Number) of the account. | NL02MLLE123456780                                            |
| `Bic`                                                        | *string*                                                     | :heavy_minus_sign:                                           | The BIC (Bank Identifier Code) of the account.               | MLLENL2AXXX                                                  |