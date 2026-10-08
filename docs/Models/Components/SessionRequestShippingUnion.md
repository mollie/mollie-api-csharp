# SessionRequestShippingUnion

> 🚧 Private beta
>
> This property is currently in private beta, and the final specification may still change.

Shipping information for the Checkout Session. Provide either `options` or `callbackUrl`, not both.

The `lines` of the Checkout Session must not contain a line with type `shipping_fee`. When `shipping` is set,
`requiredCustomerDetails` must contain `shipping-address`.


## Supported Types

### SessionRequestShipping1

```csharp
SessionRequestShippingUnion.CreateSessionRequestShipping1(/* values here */);
```

### SessionRequestShipping2

```csharp
SessionRequestShippingUnion.CreateSessionRequestShipping2(/* values here */);
```
