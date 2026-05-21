# EntityPairingCodeStatus

The status of the pairing code.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityPairingCodeStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityPairingCodeStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Active`  | active    |
| `Expired` | expired   |
| `Revoked` | revoked   |