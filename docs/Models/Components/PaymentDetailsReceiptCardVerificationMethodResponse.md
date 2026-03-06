# PaymentDetailsReceiptCardVerificationMethodResponse

The method used to verify the cardholder's identity.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsReceiptCardVerificationMethodResponse.NoCvmRequired;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsReceiptCardVerificationMethodResponse.Of("custom_value");
```


## Values

| Name                     | Value                    |
| ------------------------ | ------------------------ |
| `NoCvmRequired`          | no-cvm-required          |
| `OnlinePin`              | online-pin               |
| `OfflinePin`             | offline-pin              |
| `ConsumerDevice`         | consumer-device          |
| `Signature`              | signature                |
| `SignatureAndOnlinePin`  | signature-and-online-pin |
| `OnlinePinAndSignature`  | online-pin-and-signature |
| `None`                   | none                     |
| `Failed`                 | failed                   |