# RefundExternalReferenceTypeResponse

Specifies the reference type

## Example Usage

```csharp
using Mollie.Models.Components;

var value = RefundExternalReferenceTypeResponse.AcquirerReference;

// Open enum: use .Of() to create instances from custom string values
var custom = RefundExternalReferenceTypeResponse.Of("custom_value");
```


## Values

| Name                | Value               |
| ------------------- | ------------------- |
| `AcquirerReference` | acquirer-reference  |