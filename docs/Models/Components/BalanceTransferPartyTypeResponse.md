# BalanceTransferPartyTypeResponse

Defines the type of the party. At the moment, only `organization` is supported.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransferPartyTypeResponse.Organization;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceTransferPartyTypeResponse.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Organization` | organization   |