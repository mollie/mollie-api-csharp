# Owner

Personal data of your customer.


## Fields

| Field                                                       | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `Email`                                                     | *string*                                                    | :heavy_check_mark:                                          | The email address of your customer.                         | john@example.org                                            |
| `GivenName`                                                 | *string*                                                    | :heavy_check_mark:                                          | The given name (first name) of your customer.               | John                                                        |
| `FamilyName`                                                | *string*                                                    | :heavy_check_mark:                                          | The family name (surname) of your customer.                 | Doe                                                         |
| `Locale`                                                    | [LocaleResponse](../../Models/Components/LocaleResponse.md) | :heavy_minus_sign:                                          | Allows you to preset the language to be used.               | en_US                                                       |