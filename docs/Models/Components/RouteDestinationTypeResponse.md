# RouteDestinationTypeResponse

The type of destination. Currently only the destination type `organization` is supported.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = RouteDestinationTypeResponse.Organization;

// Open enum: use .Of() to create instances from custom string values
var custom = RouteDestinationTypeResponse.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Organization` | organization   |