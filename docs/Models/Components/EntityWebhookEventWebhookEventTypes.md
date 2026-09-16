# EntityWebhookEventWebhookEventTypes

The list of events to enable for this webhook. You may specify `'*'` to add all events, except those
that require explicit selection.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityWebhookEventWebhookEventTypes.PaymentPaid;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityWebhookEventWebhookEventTypes.Of("custom_value");
```


## Values

| Name                                       | Value                                      |
| ------------------------------------------ | ------------------------------------------ |
| `PaymentPaid`                              | payment.paid                               |
| `PaymentAuthorized`                        | payment.authorized                         |
| `PaymentFailed`                            | payment.failed                             |
| `PaymentCanceled`                          | payment.canceled                           |
| `PaymentExpired`                           | payment.expired                            |
| `PaymentPending`                           | payment.pending                            |
| `RefundQueued`                             | refund.queued                              |
| `RefundPending`                            | refund.pending                             |
| `RefundProcessing`                         | refund.processing                          |
| `RefundRefunded`                           | refund.refunded                            |
| `RefundFailed`                             | refund.failed                              |
| `RefundCanceled`                           | refund.canceled                            |
| `ChargebackReceived`                       | chargeback.received                        |
| `ChargebackReversed`                       | chargeback.reversed                        |
| `CaptureSucceeded`                         | capture.succeeded                          |
| `CaptureFailed`                            | capture.failed                             |
| `PaymentLinkPaid`                          | payment-link.paid                          |
| `BalanceTransactionCreated`                | balance-transaction.created                |
| `PayoutInitiated`                          | payout.initiated                           |
| `PayoutProcessingAtBank`                   | payout.processing-at-bank                  |
| `PayoutCompleted`                          | payout.completed                           |
| `PayoutCanceled`                           | payout.canceled                            |
| `PayoutFailed`                             | payout.failed                              |
| `SalesInvoiceCreated`                      | sales-invoice.created                      |
| `SalesInvoiceIssued`                       | sales-invoice.issued                       |
| `SalesInvoiceCanceled`                     | sales-invoice.canceled                     |
| `SalesInvoicePaid`                         | sales-invoice.paid                         |
| `SalesInvoiceEInvoiceFailed`               | sales-invoice.e-invoice-failed             |
| `SalesInvoiceEInvoiceIssued`               | sales-invoice.e-invoice-issued             |
| `BusinessAccountTransferRequested`         | business-account-transfer.requested        |
| `BusinessAccountTransferInitiated`         | business-account-transfer.initiated        |
| `BusinessAccountTransferPendingReview`     | business-account-transfer.pending-review   |
| `BusinessAccountTransferProcessed`         | business-account-transfer.processed        |
| `BusinessAccountTransferFailed`            | business-account-transfer.failed           |
| `BusinessAccountTransferBlocked`           | business-account-transfer.blocked          |
| `BusinessAccountTransferReturned`          | business-account-transfer.returned         |
| `BusinessAccountDraftTransferCreated`      | business-account-draft-transfer.created    |
| `BusinessAccountDraftTransferApproved`     | business-account-draft-transfer.approved   |
| `BusinessAccountDraftTransferDeclined`     | business-account-draft-transfer.declined   |
| `UnmatchedCreditTransferReceived`          | unmatched-credit-transfer.received         |
| `UnmatchedCreditTransferMatched`           | unmatched-credit-transfer.matched          |
| `UnmatchedCreditTransferReturned`          | unmatched-credit-transfer.returned         |
| `UnmatchedCreditTransferExpired`           | unmatched-credit-transfer.expired          |
| `UnmatchedCreditTransferMatchCompleted`    | unmatched-credit-transfer.match.completed  |
| `UnmatchedCreditTransferMatchFailed`       | unmatched-credit-transfer.match.failed     |
| `UnmatchedCreditTransferReturnCompleted`   | unmatched-credit-transfer.return.completed |
| `UnmatchedCreditTransferReturnFailed`      | unmatched-credit-transfer.return.failed    |
| `Wildcard`                                 | *                                          |