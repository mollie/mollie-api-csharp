<!-- Start SDK Example Usage [usage] -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OAuth = "<YOUR_O_AUTH_HERE>",
});

var res = await sdk.Oauth.GenerateAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```
<!-- End SDK Example Usage [usage] -->