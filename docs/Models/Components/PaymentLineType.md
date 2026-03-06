# PaymentLineType

The type of product purchased. For example, a physical or a digital product.

The `tip` payment line type is not available when creating a payment.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = PaymentLineType.Physical;
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Physical`    | physical      |
| `Digital`     | digital       |
| `ShippingFee` | shipping_fee  |
| `Discount`    | discount      |
| `StoreCredit` | store_credit  |
| `GiftCard`    | gift_card     |
| `Surcharge`   | surcharge     |
| `Tip`         | tip           |