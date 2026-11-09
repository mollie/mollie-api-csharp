# Context

Depending on the type of the balance transaction, we will try to give more context about the specific event that
triggered it. For example, the context object for a payment transaction will look like
`{"paymentId": "tr_5B8cwPMGnU6qLbRvo7qEZo", "paymentDescription": "Description"}`.

Below is a complete list of the context values that each type of transaction will have.

* Type `payment`: `paymentId`, `paymentDescription`
* Type `capture`: `paymentId` `captureId`, `paymentDescription`, `captureDescription`
* Type `capture-commission`: `paymentId`, `paymentDescription`, `organizationId`
* Type `capture-rolling-reserve-release`: `paymentId`, `paymentDescription`, `captureId`, `captureDescription`
* Type `unauthorized-direct-debit`: `paymentId`, `paymentDescription`
* Type `failed-payment`: `paymentId`, `paymentDescription`
* Type `refund`: `paymentId` `refundId`, `paymentDescription`, `refundDescription`
* Type `refund-compensation`: `paymentId` `refundId`, `paymentDescription`, `refundDescription`
* Type `returned-refund`: `paymentId` `refundId`, `paymentDescription`, `refundDescription`
* Type `returned-refund-compensation`: `paymentId` `refundId`, `paymentDescription`, `refundDescription`
* Type `chargeback`: `paymentId` `chargebackId`, `paymentDescription`, `chargebackDescription`
* Type `chargeback-reversal`: `paymentId`, `chargebackId`, `paymentDescription`, `chargebackDescription`
* Type `chargeback-compensation`: `paymentId`, `chargebackId`, `paymentDescription`, `chargebackDescription`
* Type `reversed-chargeback-compensation`: `paymentId`, `chargebackId`, `paymentDescription`, `chargebackDescription`
* Type `outgoing-transfer`: `settlementId` `transferId`
* Type `canceled-outgoing-transfer`: `settlementId` `transferId`
* Type `returned-transfer`: `settlementId` `transferId`
* Type `invoice-compensation`: `invoiceId`
* Type `balance-correction`: none
* Type `application-fee`: `paymentId`, `paymentDescription`, `payingOwner`
* Type `split-payment`: `paymentId`, `paymentDescription`, `paymentOwner`
* Type `platform-payment-refund`: `paymentId` `refundId`, `paymentDescription`, `refundDescription`
* Type `returned-platform-payment-refund`: `paymentId` `refundId`, `paymentDescription`, `refundDescription`
* Type `platform-payment-chargeback`: `paymentId` `chargebackId`, `paymentDescription`, `chargebackDescription`
* Type `reversed-platform-payment-chargeback`: `paymentId` `chargebackId`, `paymentDescription`, `chargebackDescription`
* Type `payment-commission`: `paymentId`, `paymentDescription`, `organizationId`
* Type `reimbursement-fee`: `paymentId`, `paymentDescription`
* Type `failed-payment-fee`: `paymentId`, `paymentDescription`
* Type `payment-fee`: `paymentId`, `paymentDescription`
* Type `cash-advance-loan`: none
* Type `platform-connected-organizations-fee`: none
* Type `managed-fee`: `feeType`, `<name of the fee>Id`
* Type `returned-managed-fee`:  `feeType`, `<name of the fee>Id`
* Type `topup`: none
* Type `balance-reserve`: none
* Type `balance-reserve-return`: none
* Type `movement`: none
* Type `post-payment-split-payment`: `paymentId`
* Type `cash-collateral-issuance`: none
* Type `cash-collateral-release`: none


## Fields

| Field                      | Type                       | Required                   | Description                | Example                    |
| -------------------------- | -------------------------- | -------------------------- | -------------------------- | -------------------------- |
| `PaymentId`                | *string*                   | :heavy_minus_sign:         | N/A                        | tr_5B8cwPMGnU              |
| `PaymentDescription`       | *string*                   | :heavy_minus_sign:         | N/A                        | Payment Description        |
| `CaptureId`                | *string*                   | :heavy_minus_sign:         | N/A                        | cpt_vytxeTZskVKR7C7WgdSP3d |
| `CaptureDescription`       | *string*                   | :heavy_minus_sign:         | N/A                        | Capture Description        |
| `RefundId`                 | *string*                   | :heavy_minus_sign:         | N/A                        | re_5B8cwPMGnU              |
| `RefundDescription`        | *string*                   | :heavy_minus_sign:         | N/A                        | Refund Description         |
| `ChargebackId`             | *string*                   | :heavy_minus_sign:         | N/A                        | chb_xFzwUN4ci8HAmSGUACS4J  |
| `ChargebackDescription`    | *string*                   | :heavy_minus_sign:         | N/A                        | Chargeback Description     |
| `TransferId`               | *string*                   | :heavy_minus_sign:         | N/A                        | trf_nyjwa2                 |
| `SettlementId`             | *string*                   | :heavy_minus_sign:         | N/A                        | stl_5B8cwPMGnU             |
| `InvoiceId`                | *string*                   | :heavy_minus_sign:         | N/A                        | inv_aHbjjdrUdm             |
| `PayingOwner`              | *string*                   | :heavy_minus_sign:         | N/A                        | org_1234567                |
| `PaymentOwner`             | *string*                   | :heavy_minus_sign:         | N/A                        | org_1234567                |
| `OrganizationId`           | *string*                   | :heavy_minus_sign:         | N/A                        | org_1234567                |
| `FeeType`                  | *string*                   | :heavy_minus_sign:         | N/A                        | feeType                    |
| `FeeId`                    | *string*                   | :heavy_minus_sign:         | N/A                        | feeId                      |