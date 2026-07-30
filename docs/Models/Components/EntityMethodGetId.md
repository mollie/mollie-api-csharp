# EntityMethodGetId

The unique identifier of the payment method. When used during [payment creation](create-payment), the payment
method selection screen will be skipped.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityMethodGetId.Alma;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityMethodGetId.Of("custom_value");
```


## Values

| Name             | Value            |
| ---------------- | ---------------- |
| `Alma`           | alma             |
| `Applepay`       | applepay         |
| `Bacs`           | bacs             |
| `Bancomatpay`    | bancomatpay      |
| `Bancontact`     | bancontact       |
| `Banktransfer`   | banktransfer     |
| `Belfius`        | belfius          |
| `Billie`         | billie           |
| `Billink`        | billink          |
| `Bizum`          | bizum            |
| `Blik`           | blik             |
| `Creditcard`     | creditcard       |
| `Directdebit`    | directdebit      |
| `Eps`            | eps              |
| `Giftcard`       | giftcard         |
| `Ideal`          | ideal            |
| `In3`            | in3              |
| `Kbc`            | kbc              |
| `Klarna`         | klarna           |
| `Mbway`          | mbway            |
| `Mobilepay`      | mobilepay        |
| `Multibanco`     | multibanco       |
| `Mybank`         | mybank           |
| `Paybybank`      | paybybank        |
| `Paypal`         | paypal           |
| `Paysafecard`    | paysafecard      |
| `Pointofsale`    | pointofsale      |
| `Przelewy24`     | przelewy24       |
| `Riverty`        | riverty          |
| `Satispay`       | satispay         |
| `Swish`          | swish            |
| `Trustly`        | trustly          |
| `Twint`          | twint            |
| `Vipps`          | vipps            |
| `Voucher`        | voucher          |
| `Klarnapaylater` | klarnapaylater   |
| `Klarnapaynow`   | klarnapaynow     |
| `Klarnasliceit`  | klarnasliceit    |
| `Payconiq`       | payconiq         |