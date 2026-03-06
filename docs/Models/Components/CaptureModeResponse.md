# CaptureModeResponse

Indicate if the funds should be captured immediately or if you want to [place a hold](https://docs.mollie.com/docs/place-a-hold-for-a-payment#/) 
and capture at a later time.

This field needs to be set to `manual` for method `riverty`.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = CaptureModeResponse.Automatic;

// Open enum: use .Of() to create instances from custom string values
var custom = CaptureModeResponse.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Automatic` | automatic   |
| `Manual`    | manual      |