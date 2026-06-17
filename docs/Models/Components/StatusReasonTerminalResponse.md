# StatusReasonTerminalResponse

## Example Usage

```csharp
using Mollie.Models.Components;

var value = StatusReasonTerminalResponse.TerminalBusy;

// Open enum: use .Of() to create instances from custom string values
var custom = StatusReasonTerminalResponse.Of("custom_value");
```


## Values

| Name                  | Value                 |
| --------------------- | --------------------- |
| `TerminalBusy`        | terminal_busy         |
| `TerminalUnreachable` | terminal_unreachable  |