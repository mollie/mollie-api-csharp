# EntityOnboardingStatusStatus

The current status of the organization's onboarding process.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityOnboardingStatusStatus.NeedsData;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityOnboardingStatusStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `NeedsData` | needs-data  |
| `InReview`  | in-review   |
| `Completed` | completed   |