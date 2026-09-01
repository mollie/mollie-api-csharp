# SessionResponseStatus

The Checkout Session's status.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = SessionResponseStatus.Open;

// Open enum: use .Of() to create instances from custom string values
var custom = SessionResponseStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Open`      | open        |
| `Completed` | completed   |
| `Expired`   | expired     |