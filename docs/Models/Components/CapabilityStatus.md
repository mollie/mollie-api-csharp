# CapabilityStatus

## Example Usage

```csharp
using Mollie.Models.Components;

var value = CapabilityStatus.Unrequested;

// Open enum: use .Of() to create instances from custom string values
var custom = CapabilityStatus.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Unrequested` | unrequested   |
| `Enabled`     | enabled       |
| `Disabled`    | disabled      |
| `Pending`     | pending       |