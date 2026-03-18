# CapabilityRequirementStatus

The status of the requirement depends on its due date.
If no due date is given, the status will be `requested`.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = CapabilityRequirementStatus.CurrentlyDue;

// Open enum: use .Of() to create instances from custom string values
var custom = CapabilityRequirementStatus.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `CurrentlyDue` | currently-due  |
| `PastDue`      | past-due       |
| `Requested`    | requested      |