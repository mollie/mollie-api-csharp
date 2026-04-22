# OauthRevokeTokensRequestBody


## Fields

| Field                                                                                  | Type                                                                                   | Required                                                                               | Description                                                                            |
| -------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------- |
| `TokenTypeHint`                                                                        | *string*                                                                               | :heavy_check_mark:                                                                     | The type of token you want to revoke.<br/><br/>Possible values: `access_token` `refresh_token` |
| `Token`                                                                                | *string*                                                                               | :heavy_check_mark:                                                                     | The token you want to revoke.                                                          |