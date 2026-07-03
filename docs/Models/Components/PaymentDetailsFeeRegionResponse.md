# PaymentDetailsFeeRegionResponse

The applicable card fee region.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentDetailsFeeRegionResponse.AmericanExpress;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentDetailsFeeRegionResponse.Of("custom_value");
```


## Values

| Name                                 | Value                                |
| ------------------------------------ | ------------------------------------ |
| `AmericanExpress`                    | american-express                     |
| `AmexIntraEea`                       | amex-intra-eea                       |
| `CarteBancaire`                      | carte-bancaire                       |
| `IntraEu`                            | intra-eu                             |
| `IntraEuCorporate`                   | intra-eu-corporate                   |
| `Domestic`                           | domestic                             |
| `Maestro`                            | maestro                              |
| `MastercardCreditBusinessDomestic`   | mastercard-credit-business-domestic  |
| `MastercardCreditConsumerDomestic`   | mastercard-credit-consumer-domestic  |
| `MastercardCreditConsumerIntraEea`   | mastercard-credit-consumer-intra-eea |
| `MastercardDebitBusinessDomestic`    | mastercard-debit-business-domestic   |
| `MastercardDebitBusinessIntraEea`    | mastercard-debit-business-intra-eea  |
| `MastercardDebitConsumerDomestic`    | mastercard-debit-consumer-domestic   |
| `MastercardDebitConsumerIntraEea`    | mastercard-debit-consumer-intra-eea  |
| `Other`                              | other                                |
| `Inter`                              | inter                                |
| `IntraEea`                           | intra_eea                            |
| `VisaCreditBusinessDomestic`         | visa-credit-business-domestic        |
| `VisaCreditConsumerDomestic`         | visa-credit-consumer-domestic        |
| `VisaCreditConsumerIntraEea`         | visa-credit-consumer-intra-eea       |
| `VisaDebitBusinessDomestic`          | visa-debit-business-domestic         |
| `VisaDebitBusinessIntraEea`          | visa-debit-business-intra-eea        |
| `VisaDebitConsumerDomestic`          | visa-debit-consumer-domestic         |