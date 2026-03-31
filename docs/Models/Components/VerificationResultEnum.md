# VerificationResultEnum

The result of the Verification of Payee check.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = VerificationResultEnum.Match;

// Open enum: use .Of() to create instances from custom string values
var custom = VerificationResultEnum.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Match`        | match          |
| `NoMatch`      | no-match       |
| `CloseMatch`   | close-match    |
| `NotAvailable` | not-available  |