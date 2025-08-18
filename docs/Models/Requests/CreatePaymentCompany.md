# CreatePaymentCompany

Billie is a business-to-business (B2B) payment method. It requires extra information to identify the organization
that is completing the payment. It is recommended to include these parameters up front for a seamless flow.
Otherwise, Billie will ask the customer to complete the missing fields during checkout.


## Fields

| Field                                   | Type                                    | Required                                | Description                             | Example                                 |
| --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- |
| `RegistrationNumber`                    | *string*                                | :heavy_minus_sign:                      | The organization's registration number. | 12345678                                |
| `VatNumber`                             | *string*                                | :heavy_minus_sign:                      | The organization's VAT number.          | NL123456789B01                          |
| `EntityType`                            | *string*                                | :heavy_minus_sign:                      | The organization's entity type.         | ...                                     |