# CreateCustomerSubscriptions

The API resource URL of the [subscriptions](list-subscriptions) linked to this customer. Omitted if no such
subscriptions exist (yet).


## Fields

| Field                                                       | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `Href`                                                      | *string*                                                    | :heavy_minus_sign:                                          | The actual URL string.                                      | https://...                                                 |
| `Type`                                                      | *string*                                                    | :heavy_minus_sign:                                          | The content type of the page or endpoint the URL points to. | application/hal+json                                        |