# EntityWebhookEventWebhookEventTypes

The list of events to enable for this webhook. You may specify `'*'` to add all events, except those
that require explicit selection.

## Example Usage

```csharp
using Mollie.Models.Components;

var value = EntityWebhookEventWebhookEventTypes.PaymentLinkPaid;

// Open enum: use .Of() to create instances from custom string values
var custom = EntityWebhookEventWebhookEventTypes.Of("custom_value");
```


## Values

| Name                                     | Value                                    |
| ---------------------------------------- | ---------------------------------------- |
| `PaymentLinkPaid`                        | payment-link.paid                        |
| `BalanceTransactionCreated`              | balance-transaction.created              |
| `SalesInvoiceCreated`                    | sales-invoice.created                    |
| `SalesInvoiceIssued`                     | sales-invoice.issued                     |
| `SalesInvoiceCanceled`                   | sales-invoice.canceled                   |
| `SalesInvoicePaid`                       | sales-invoice.paid                       |
| `BusinessAccountTransferRequested`       | business-account-transfer.requested      |
| `BusinessAccountTransferInitiated`       | business-account-transfer.initiated      |
| `BusinessAccountTransferPendingReview`   | business-account-transfer.pending-review |
| `BusinessAccountTransferProcessed`       | business-account-transfer.processed      |
| `BusinessAccountTransferFailed`          | business-account-transfer.failed         |
| `BusinessAccountTransferBlocked`         | business-account-transfer.blocked        |
| `BusinessAccountTransferReturned`        | business-account-transfer.returned       |
| `Wildcard`                               | *                                        |