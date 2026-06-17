# StatusReasonMerchantResponse

## Example Usage

```csharp
using Mollie.Models.Components;

var value = StatusReasonMerchantResponse.MerchantIdNotFound;

// Open enum: use .Of() to create instances from custom string values
var custom = StatusReasonMerchantResponse.Of("custom_value");
```


## Values

| Name                                  | Value                                 |
| ------------------------------------- | ------------------------------------- |
| `MerchantIdNotFound`                  | merchant_id_not_found                 |
| `MerchantAccountClosed`               | merchant_account_closed               |
| `TerminalIdNotFound`                  | terminal_id_not_found                 |
| `TerminalClosed`                      | terminal_closed                       |
| `InvalidCategoryCode`                 | invalid_category_code                 |
| `InvalidCurrency`                     | invalid_currency                      |
| `MissingCvv2Cvc2`                     | missing_cvv2_cvc2                     |
| `Cvv2NotAllowed`                      | cvv2_not_allowed                      |
| `MerchantNotRegisteredVbv`            | merchant_not_registered_vbv           |
| `MerchantNotRegisteredForAmex`        | merchant_not_registered_for_amex      |
| `TransactionNotPermittedAtTerminal`   | transaction_not_permitted_at_terminal |
| `AgreementTerminalNotRelated`         | agreement_terminal_not_related        |
| `InvalidProcessorId`                  | invalid_processor_id                  |
| `InvalidMerchantData`                 | invalid_merchant_data                 |
| `SubMerchantAccountClosed`            | sub_merchant_account_closed           |