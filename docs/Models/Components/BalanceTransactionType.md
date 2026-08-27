# BalanceTransactionType

## Example Usage

```csharp
using Mollie.Models.Components;

var value = BalanceTransactionType.ApiPaymentRollingReserveRelease;

// Open enum: use .Of() to create instances from custom string values
var custom = BalanceTransactionType.Of("custom_value");
```


## Values

| Name                                 | Value                                |
| ------------------------------------ | ------------------------------------ |
| `ApiPaymentRollingReserveRelease`    | api-payment-rolling-reserve-release  |
| `ApplicationFee`                     | application-fee                      |
| `BalanceChargeFee`                   | balance-charge-fee                   |
| `BalanceCorrection`                  | balance-correction                   |
| `BalanceReserve`                     | balance-reserve                      |
| `BalanceReserveReturn`               | balance-reserve-return               |
| `BalanceTopup`                       | balance-topup                        |
| `CanceledTransfer`                   | canceled-transfer                    |
| `Capture`                            | capture                              |
| `CashCollateralIssuance`             | cash-collateral-issuance             |
| `CashCollateralRelease`              | cash-collateral-release              |
| `Chargeback`                         | chargeback                           |
| `ChargebackCompensation`             | chargeback-compensation              |
| `ChargebackReversal`                 | chargeback-reversal                  |
| `FailedPayment`                      | failed-payment                       |
| `FailedPlatformSplitPayment`         | failed-platform-split-payment        |
| `FailedSplitPaymentCompensation`     | failed-split-payment-compensation    |
| `FeePrepayment`                      | fee-prepayment                       |
| `HeldRollingReserve`                 | held-rolling-reserve                 |
| `IncomingTransfer`                   | incoming-transfer                    |
| `InvoiceCompensation`                | invoice-compensation                 |
| `InvoiceRoundingCompensation`        | invoice-rounding-compensation        |
| `Loan`                               | loan                                 |
| `Movement`                           | movement                             |
| `OutgoingCustomAmountTransfer`       | outgoing-custom-amount-transfer      |
| `OutgoingTransfer`                   | outgoing-transfer                    |
| `Payment`                            | payment                              |
| `PaymentFee`                         | payment-fee                          |
| `PendingRollingReserve`              | pending-rolling-reserve              |
| `PlatformPaymentChargeback`          | platform-payment-chargeback          |
| `PlatformPaymentRefund`              | platform-payment-refund              |
| `PostPaymentSplitPayment`            | post-payment-split-payment           |
| `Refund`                             | refund                               |
| `RefundCompensation`                 | refund-compensation                  |
| `ReleasedRollingReserve`             | released-rolling-reserve             |
| `Repayment`                          | repayment                            |
| `ReturnedPlatformPaymentRefund`      | returned-platform-payment-refund     |
| `ReturnedRefund`                     | returned-refund                      |
| `ReturnedRefundCompensation`         | returned-refund-compensation         |
| `ReturnedTransfer`                   | returned-transfer                    |
| `ReversedChargebackCompensation`     | reversed-chargeback-compensation     |
| `ReversedPlatformPaymentChargeback`  | reversed-platform-payment-chargeback |
| `RollingReserveHold`                 | rolling-reserve-hold                 |
| `RollingReserveRelease`              | rolling-reserve-release              |
| `SplitPayment`                       | split-payment                        |
| `SplitTransaction`                   | split-transaction                    |
| `ToBeReleasedRollingReserve`         | to-be-released-rolling-reserve       |
| `Topup`                              | topup                                |