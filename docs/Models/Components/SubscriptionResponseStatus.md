# SubscriptionResponseStatus

The subscription's current status is directly related to the status of the underlying customer or mandate that is
enabling the subscription.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SubscriptionResponseStatus.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = SubscriptionResponseStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Pending`   | pending     |
| `Active`    | active      |
| `Canceled`  | canceled    |
| `Suspended` | suspended   |
| `Completed` | completed   |