# PayoutStatusReason

The reason for the payout's current status.


## Fields

| Field                                                                          | Type                                                                           | Required                                                                       | Description                                                                    | Example                                                                        |
| ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ |
| `Code`                                                                         | [PayoutStatusReasonCode](../../Models/Components/PayoutStatusReasonCode.md)    | :heavy_check_mark:                                                             | A machine-readable code describing the reason for the payout's current status. | requested                                                                      |
| `Message`                                                                      | *string*                                                                       | :heavy_check_mark:                                                             | A human-readable description of the status reason.                             | The payout has been requested.                                                 |