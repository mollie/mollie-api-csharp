# MandateResponseScope

An array defining the eligible use cases for the mandate. For creditcard mandates, this field will always be 
present and can contain one or both of the following values:

## Example Usage

```csharp
using Mollie.Models.Components;

var value = MandateResponseScope.CustomerPresent;

// Open enum: use .Of() to create instances from custom string values
var custom = MandateResponseScope.Of("custom_value");
```


## Values

| Name                 | Value                |
| -------------------- | -------------------- |
| `CustomerPresent`    | customer-present     |
| `CustomerNotPresent` | customer-not-present |