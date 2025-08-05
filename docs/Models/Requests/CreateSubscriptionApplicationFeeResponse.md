# CreateSubscriptionApplicationFeeResponse

With Mollie Connect you can charge fees on payments that your app is processing on behalf of other Mollie
merchants.

Setting an application fee on the subscription will ensure this fee is charged on each individual payment.

Refer to the `applicationFee` parameter on the [Get payment endpoint](get-payment) documentation for more
information.


## Fields

| Field                                                                                                                     | Type                                                                                                                      | Required                                                                                                                  | Description                                                                                                               | Example                                                                                                                   |
| ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| `Amount`                                                                                                                  | [CreateSubscriptionApplicationFeeAmountResponse](../../Models/Requests/CreateSubscriptionApplicationFeeAmountResponse.md) | :heavy_check_mark:                                                                                                        | In v2 endpoints, monetary amounts are represented as objects with a `currency` and `value` field.                         |                                                                                                                           |
| `Description`                                                                                                             | *string*                                                                                                                  | :heavy_check_mark:                                                                                                        | N/A                                                                                                                       | Platform fee                                                                                                              |