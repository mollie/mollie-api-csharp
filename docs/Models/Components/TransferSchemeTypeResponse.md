# TransferSchemeTypeResponse

The transfer scheme to be used for the transfer. The transfer scheme determines the processing time and method of the transfer.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = TransferSchemeTypeResponse.SepaCreditInst;

// Open enum: use .Of() to create instances from custom string values
var custom = TransferSchemeTypeResponse.Of("custom_value");
```


## Values

| Name             | Value            |
| ---------------- | ---------------- |
| `SepaCreditInst` | sepa-credit-inst |
| `SepaCredit`     | sepa-credit      |