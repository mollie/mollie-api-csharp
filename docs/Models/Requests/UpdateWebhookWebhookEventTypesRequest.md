# UpdateWebhookWebhookEventTypesRequest

The list of events to enable for this webhook. You may specify `'*'` to add all events, except those
that require explicit selection. Separate multiple event types with a comma.


## Values

| Name                        | Value                       |
| --------------------------- | --------------------------- |
| `PaymentLinkPaid`           | payment-link.paid           |
| `BalanceTransactionCreated` | balance-transaction.created |
| `SalesInvoiceCreated`       | sales-invoice.created       |
| `SalesInvoiceIssued`        | sales-invoice.issued        |
| `SalesInvoiceCanceled`      | sales-invoice.canceled      |
| `SalesInvoicePaid`          | sales-invoice.paid          |
| `Wildcard`                  | *                           |