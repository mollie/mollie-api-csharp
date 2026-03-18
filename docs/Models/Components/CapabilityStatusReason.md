# CapabilityStatusReason

## Example Usage

```csharp
using Mollie.Models.Components;

var value = CapabilityStatusReason.RequirementPastDue;

// Open enum: use .Of() to create instances from custom string values
var custom = CapabilityStatusReason.Of("custom_value");
```


## Values

| Name                          | Value                         |
| ----------------------------- | ----------------------------- |
| `RequirementPastDue`          | requirement-past-due          |
| `OnboardingInformationNeeded` | onboarding-information-needed |