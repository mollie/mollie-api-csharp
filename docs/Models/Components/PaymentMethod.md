# PaymentMethod

The payment method, if applicable

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentMethod.Alma;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentMethod.Of("custom_value");
```


## Values

| Name                | Value               |
| ------------------- | ------------------- |
| `Alma`              | alma                |
| `Bacs`              | bacs                |
| `Applepay`          | applepay            |
| `Bancomatpay`       | bancomatpay         |
| `Bancontact`        | bancontact          |
| `Banktransfer`      | banktransfer        |
| `Belfius`           | belfius             |
| `Billie`            | billie              |
| `Billink`           | billink             |
| `Bizum`             | bizum               |
| `Bitcoin`           | bitcoin             |
| `Blik`              | blik                |
| `Creditcard`        | creditcard          |
| `Directdebit`       | directdebit         |
| `Eps`               | eps                 |
| `Giftcard`          | giftcard            |
| `Giropay`           | giropay             |
| `Googlepay`         | googlepay           |
| `Ideal`             | ideal               |
| `In3`               | in3                 |
| `Inghomepay`        | inghomepay          |
| `Kbc`               | kbc                 |
| `Klarnapaylater`    | klarnapaylater      |
| `Klarnapaynow`      | klarnapaynow        |
| `Klarnasliceit`     | klarnasliceit       |
| `Klarna`            | klarna              |
| `Mbway`             | mbway               |
| `Mobilepay`         | mobilepay           |
| `Multibanco`        | multibanco          |
| `Mybank`            | mybank              |
| `Paybybank`         | paybybank           |
| `Paypal`            | paypal              |
| `Paysafecard`       | paysafecard         |
| `Przelewy24`        | przelewy24          |
| `Riverty`           | riverty             |
| `Satispay`          | satispay            |
| `Podiumcadeaukaart` | podiumcadeaukaart   |
| `Pointofsale`       | pointofsale         |
| `Sofort`            | sofort              |
| `Swish`             | swish               |
| `Trustly`           | trustly             |
| `Twint`             | twint               |
| `Vipps`             | vipps               |
| `Voucher`           | voucher             |