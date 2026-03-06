# PaymentDetailsFeeRegionResponse

The applicable card fee region.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsFeeRegionResponse.AmericanExpress;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsFeeRegionResponse.Of("custom_value");
```


## Values

| Name               | Value              |
| ------------------ | ------------------ |
| `AmericanExpress`  | american-express   |
| `AmexIntraEea`     | amex-intra-eea     |
| `CarteBancaire`    | carte-bancaire     |
| `IntraEu`          | intra-eu           |
| `IntraEuCorporate` | intra-eu-corporate |
| `Domestic`         | domestic           |
| `Maestro`          | maestro            |
| `Other`            | other              |
| `Inter`            | inter              |
| `IntraEea`         | intra_eea          |