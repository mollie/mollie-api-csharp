# WebhookEventTypes

The list of events to enable for this webhook. You may specify `'*'` to add all events, except those
that require explicit selection.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = WebhookEventTypes.PaymentPaid;
```


## Values

| Name                                     | Value                                    |
| ---------------------------------------- | ---------------------------------------- |
| `PaymentPaid`                            | payment.paid                             |
| `PaymentAuthorized`                      | payment.authorized                       |
| `PaymentFailed`                          | payment.failed                           |
| `PaymentCanceled`                        | payment.canceled                         |
| `PaymentExpired`                         | payment.expired                          |
| `PaymentPending`                         | payment.pending                          |
| `RefundQueued`                           | refund.queued                            |
| `RefundPending`                          | refund.pending                           |
| `RefundProcessing`                       | refund.processing                        |
| `RefundRefunded`                         | refund.refunded                          |
| `RefundFailed`                           | refund.failed                            |
| `RefundCanceled`                         | refund.canceled                          |
| `PaymentLinkPaid`                        | payment-link.paid                        |
| `BalanceTransactionCreated`              | balance-transaction.created              |
| `PayoutInitiated`                        | payout.initiated                         |
| `PayoutProcessingAtBank`                 | payout.processing-at-bank                |
| `PayoutCompleted`                        | payout.completed                         |
| `PayoutCanceled`                         | payout.canceled                          |
| `PayoutFailed`                           | payout.failed                            |
| `SalesInvoiceCreated`                    | sales-invoice.created                    |
| `SalesInvoiceIssued`                     | sales-invoice.issued                     |
| `SalesInvoiceCanceled`                   | sales-invoice.canceled                   |
| `SalesInvoicePaid`                       | sales-invoice.paid                       |
| `SalesInvoiceEInvoiceFailed`             | sales-invoice.e-invoice-failed           |
| `SalesInvoiceEInvoiceIssued`             | sales-invoice.e-invoice-issued           |
| `BusinessAccountTransferRequested`       | business-account-transfer.requested      |
| `BusinessAccountTransferInitiated`       | business-account-transfer.initiated      |
| `BusinessAccountTransferPendingReview`   | business-account-transfer.pending-review |
| `BusinessAccountTransferProcessed`       | business-account-transfer.processed      |
| `BusinessAccountTransferFailed`          | business-account-transfer.failed         |
| `BusinessAccountTransferBlocked`         | business-account-transfer.blocked        |
| `BusinessAccountTransferReturned`        | business-account-transfer.returned       |
| `Wildcard`                               | *                                        |