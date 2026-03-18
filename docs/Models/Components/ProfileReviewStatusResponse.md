# ProfileReviewStatusResponse

The status of the requested changes.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ProfileReviewStatusResponse.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = ProfileReviewStatusResponse.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Pending`  | pending    |
| `Rejected` | rejected   |