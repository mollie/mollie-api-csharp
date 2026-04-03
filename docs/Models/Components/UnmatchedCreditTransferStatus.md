# UnmatchedCreditTransferStatus

## Example Usage

```csharp
using Mollie.Models.Components;

var value = UnmatchedCreditTransferStatus.Received;

// Open enum: use .Of() to create instances from custom string values
var custom = UnmatchedCreditTransferStatus.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Received` | received   |
| `Matched`  | matched    |
| `Returned` | returned   |
| `Expired`  | expired    |