# CaptureResponseStatus

The capture's status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = CaptureResponseStatus.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = CaptureResponseStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Pending`   | pending     |
| `Succeeded` | succeeded   |
| `Failed`    | failed      |