# ListCaptureResponseStatus

The capture's status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListCaptureResponseStatus.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = ListCaptureResponseStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Pending`   | pending     |
| `Succeeded` | succeeded   |
| `Failed`    | failed      |