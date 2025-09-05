# EntityPaymentRouteDestination

The destination of this portion of the payment.


## Fields

| Field                                                                                     | Type                                                                                      | Required                                                                                  | Description                                                                               | Example                                                                                   |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `Type`                                                                                    | [EntityPaymentRouteType](../../Models/Components/EntityPaymentRouteType.md)               | :heavy_check_mark:                                                                        | The type of destination. Currently only the destination type `organization` is supported. | organization                                                                              |
| `OrganizationId`                                                                          | *string*                                                                                  | :heavy_check_mark:                                                                        | N/A                                                                                       | org_1234567                                                                               |