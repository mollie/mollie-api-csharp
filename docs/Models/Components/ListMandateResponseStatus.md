# ListMandateResponseStatus

The status of the mandate. A status can be `pending` for mandates when the first payment is not yet finalized, or
when we did not received the IBAN yet from the first payment.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = ListMandateResponseStatus.Valid;

// Open enum: use .Of() to create instances from custom string values
var custom = ListMandateResponseStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Valid`   | valid     |
| `Pending` | pending   |
| `Invalid` | invalid   |