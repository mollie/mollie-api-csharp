<!-- Start SDK Example Usage [usage] -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Balances.ListAsync(
    currency: "EUR",
    fromP: "bal_gVMhHKqSSRYJyPsuoPNFH",
    limit: 50,
    testmode: false
);

// handle response
```
<!-- End SDK Example Usage [usage] -->