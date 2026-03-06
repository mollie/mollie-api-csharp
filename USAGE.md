<!-- Start SDK Example Usage [usage] -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        OAuth = "<YOUR_O_AUTH_HERE>",
    }
);

ListBalancesRequest req = new ListBalancesRequest() {
    Currency = "EUR",
    From = "bal_gVMhHKqSSRYJyPsuoPNFH",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Balances.ListAsync(req);

// handle response
```
<!-- End SDK Example Usage [usage] -->