# DraftTransferResponseSource

Whether the draft transfer was created via this API, or created in Mollie Apps.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = DraftTransferResponseSource.Api;

// Open enum: use .Of() to create instances from custom string values
var custom = DraftTransferResponseSource.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Api`       | api         |
| `MollieApp` | mollie-app  |