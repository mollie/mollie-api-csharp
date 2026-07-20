# DraftTransferStatusHistoryEntryResponse

A single entry in the draft transfer's status history.


## Fields

| Field                                                                                 | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `Status`                                                                              | [DraftTransferStatusResponse](../../Models/Components/DraftTransferStatusResponse.md) | :heavy_check_mark:                                                                    | The status of the draft transfer.                                                     | awaiting-initiation                                                                   |
| `CreatedAt`                                                                           | [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0) | :heavy_check_mark:                                                                    | The date and time the draft transfer entered this status, in ISO 8601 format.         | 2025-01-01T12:00:00+00:00                                                             |