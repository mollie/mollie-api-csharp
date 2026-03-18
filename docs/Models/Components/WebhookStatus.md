# WebhookStatus

The subscription's current status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = WebhookStatus.Enabled;

// Open enum: use .Of() to create instances from custom string values
var custom = WebhookStatus.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Enabled`  | enabled    |
| `Blocked`  | blocked    |
| `Disabled` | disabled   |
| `Deleted`  | deleted    |