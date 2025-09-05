# RouteCreateRequestDestination

The destination of the route.


## Fields

| Field                                                                                     | Type                                                                                      | Required                                                                                  | Description                                                                               | Example                                                                                   |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `Type`                                                                                    | [RouteCreateRequestType](../../Models/Components/RouteCreateRequestType.md)               | :heavy_check_mark:                                                                        | The type of destination. Currently only the destination type `organization` is supported. | organization                                                                              |
| `OrganizationId`                                                                          | *string*                                                                                  | :heavy_check_mark:                                                                        | N/A                                                                                       | org_1234567                                                                               |