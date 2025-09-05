# EntityRefundSource

Where the funds will be pulled back from.


## Fields

| Field                                                                           | Type                                                                            | Required                                                                        | Description                                                                     | Example                                                                         |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Type`                                                                          | [RoutingReversalType](../../Models/Components/RoutingReversalType.md)           | :heavy_minus_sign:                                                              | The type of source. Currently only the source type `organization` is supported. | organization                                                                    |
| `OrganizationId`                                                                | *string*                                                                        | :heavy_minus_sign:                                                              | N/A                                                                             | org_1234567                                                                     |