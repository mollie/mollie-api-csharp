# Oauth

## Overview

### Available Operations

* [Generate](#generate) - Generate tokens
* [Revoke](#revoke) - Revoke tokens

## Generate

Exchange the authorization code you received from the [Authorize endpoint](oauth-authorize) for an 'access token'
API credential, with which you can communicate with the Mollie API on behalf of the consenting merchant.

This endpoint can only be accessed using **OAuth client credentials**.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="oauth-generate-tokens" method="post" path="/oauth2/tokens" example="oauth-generate-tokens" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client();

var res = await sdk.Oauth.GenerateAsync(
    security: new OauthGenerateTokensSecurity() {
        Username = "",
        Password = "",
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new OauthGenerateTokensRequestBody() {
        GrantType = OauthGrantType.AuthorizationCode,
        Code = "auth_...",
        RefreshToken = "refresh_...",
        RedirectUri = "https://example.com/redirect",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               | Example                                                                                   |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `security`                                                                                | [OauthGenerateTokensSecurity](../../Models/Requests/OauthGenerateTokensSecurity.md)       | :heavy_check_mark:                                                                        | The security requirements to use for the request.                                         |                                                                                           |
| `IdempotencyKey`                                                                          | *string*                                                                                  | :heavy_minus_sign:                                                                        | A unique key to ensure idempotent requests. This key should be a UUID v4 string.          | 123e4567-e89b-12d3-a456-426                                                               |
| `RequestBody`                                                                             | [OauthGenerateTokensRequestBody](../../Models/Requests/OauthGenerateTokensRequestBody.md) | :heavy_minus_sign:                                                                        | N/A                                                                                       |                                                                                           |
| `serverURL`                                                                               | *string*                                                                                  | :heavy_minus_sign:                                                                        | An optional server URL to use.                                                            | http://localhost:8080                                                                     |

### Response

**[OauthGenerateTokensResponse](../../Models/Requests/OauthGenerateTokensResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 429                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Revoke

Revoke an access token or refresh token. Once revoked, the token can no longer be used.

Revoking a refresh token revokes all access tokens that were created using the same authorization.

This endpoint can only be accessed using **OAuth client credentials**.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="oauth-revoke-tokens" method="delete" path="/oauth2/tokens" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client();

var res = await sdk.Oauth.RevokeAsync(
    security: new OauthRevokeTokensSecurity() {
        Username = "",
        Password = "",
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    requestBody: new OauthRevokeTokensRequestBody() {
        TokenTypeHint = OauthTokenTypeHint.AccessToken,
        Token = "access_...",
    }
);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `security`                                                                            | [OauthRevokeTokensSecurity](../../Models/Requests/OauthRevokeTokensSecurity.md)       | :heavy_check_mark:                                                                    | The security requirements to use for the request.                                     |                                                                                       |
| `IdempotencyKey`                                                                      | *string*                                                                              | :heavy_minus_sign:                                                                    | A unique key to ensure idempotent requests. This key should be a UUID v4 string.      | 123e4567-e89b-12d3-a456-426                                                           |
| `RequestBody`                                                                         | [OauthRevokeTokensRequestBody](../../Models/Requests/OauthRevokeTokensRequestBody.md) | :heavy_minus_sign:                                                                    | N/A                                                                                   |                                                                                       |
| `serverURL`                                                                           | *string*                                                                              | :heavy_minus_sign:                                                                    | An optional server URL to use.                                                        | http://localhost:8080                                                                 |

### Response

**[OauthRevokeTokensResponse](../../Models/Requests/OauthRevokeTokensResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 429                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |