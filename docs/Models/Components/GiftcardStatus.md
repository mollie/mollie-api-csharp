# GiftcardStatus

The status of the issuer.
If the status is `pending-issuer`, an additional action from your side may be required with the issuer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = GiftcardStatus.Activated;

// Open enum: use .Of() to create instances from custom string values
var custom = GiftcardStatus.Of("custom_value");
```


## Values

| Name            | Value           |
| --------------- | --------------- |
| `Activated`     | activated       |
| `PendingIssuer` | pending-issuer  |