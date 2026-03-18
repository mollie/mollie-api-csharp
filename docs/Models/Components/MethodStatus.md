# MethodStatus

The payment method's activation status for this profile.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = MethodStatus.Activated;

// Open enum: use .Of() to create instances from custom string values
var custom = MethodStatus.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Activated`       | activated         |
| `PendingBoarding` | pending-boarding  |
| `PendingReview`   | pending-review    |
| `PendingExternal` | pending-external  |
| `Rejected`        | rejected          |