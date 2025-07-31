# Signuplink

The URL that can be used to have new organizations sign up and be automatically linked to this
partner. Will be omitted if the partner is not of type `signuplink`.


## Fields

| Field                                                       | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `Href`                                                      | *string*                                                    | :heavy_check_mark:                                          | The actual URL string.                                      | https://...                                                 |
| `Type`                                                      | *string*                                                    | :heavy_check_mark:                                          | The content type of the page or endpoint the URL points to. | application/hal+json                                        |