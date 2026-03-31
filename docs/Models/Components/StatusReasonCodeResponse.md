# StatusReasonCodeResponse

A machine-readable code indicating the reason for the transfer's terminal status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = StatusReasonCodeResponse.InsufficientFunds;

// Open enum: use .Of() to create instances from custom string values
var custom = StatusReasonCodeResponse.Of("custom_value");
```


## Values

| Name                | Value               |
| ------------------- | ------------------- |
| `InsufficientFunds` | insufficient-funds  |
| `Rejected`          | rejected            |
| `Error`             | error               |