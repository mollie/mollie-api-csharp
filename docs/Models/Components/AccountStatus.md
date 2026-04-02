# AccountStatus

The status of the business account.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = AccountStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = AccountStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Active`  | active    |
| `Blocked` | blocked   |
| `Closed`  | closed    |