<!-- Start SDK Example Usage [usage] -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

var res = await sdk.Oauth.GenerateAsync(
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
<!-- End SDK Example Usage [usage] -->