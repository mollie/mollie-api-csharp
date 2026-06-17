# StatusReasonVoucherResponse

## Example Usage

```csharp
using Mollie.Models.Components;

var value = StatusReasonVoucherResponse.ServiceFailed;

// Open enum: use .Of() to create instances from custom string values
var custom = StatusReasonVoucherResponse.Of("custom_value");
```


## Values

| Name                          | Value                         |
| ----------------------------- | ----------------------------- |
| `ServiceFailed`               | service_failed                |
| `InvalidOperation`            | invalid_operation             |
| `AuthorizationError`          | authorization_error           |
| `LoginFailedWithoutReason`    | login_failed_without_reason   |
| `InvalidRetailer`             | invalid_retailer              |
| `ReferToCardIssuer`           | refer_to_card_issuer          |
| `CardDoesNotExist`            | card_does_not_exist           |
| `ExpiredCard`                 | expired_card                  |
| `CardIsBlocked`               | card_is_blocked               |
| `InsufficientFunds`           | insufficient_funds            |
| `InvalidCardId`               | invalid_card_id               |
| `CardIsTransferred`           | card_is_transferred           |
| `CardIsNotActive`             | card_is_not_active            |
| `IncorrectPurchaseValue`      | incorrect_purchase_value      |
| `CardNotAvailable`            | card_not_available            |
| `WrongCurrency`               | wrong_currency                |
| `LoginFailedUnknownUser`      | login_failed_unknown_user     |
| `LoginFailedInvalidPassword`  | login_failed_invalid_password |
| `InvalidPin`                  | invalid_pin                   |
| `InvalidEanCode`              | invalid_ean_code              |