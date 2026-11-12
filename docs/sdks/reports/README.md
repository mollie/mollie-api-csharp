# Reports

## Overview

### Available Operations

* [Create](#create) - Create report
* [Get](#get) - Get report

## Create

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change. To
> join the beta program, reach out to [partners@mollie.com](mailto:partners@mollie.com).

Create a report. Mollie generates it in the background, so you get a `pending` status back right away.

Poll [Get report](get-report) to check on progress, and grab a download link once it's ready.

Creating a report with the exact same parameters while one is already pending or completed doesn't create
a new one. You get the existing report back instead, whatever status it currently has.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-report" method="post" path="/v2/reports" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using NodaTime;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Reports.CreateAsync(
    createReportRequest: new Mollie.Models.Components.CreateReportRequest() {
        ReportType = ReportType.TransactionMargin,
        FromDate = LocalDate.FromDateTime(System.DateTime.Parse("2026-08-01")),
        UntilDate = LocalDate.FromDateTime(System.DateTime.Parse("2026-08-31")),
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             | Example                                                                                 |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `CreateReportRequest`                                                                   | [Models.Components.CreateReportRequest](../../Models/Components/CreateReportRequest.md) | :heavy_check_mark:                                                                      | N/A                                                                                     |                                                                                         |
| `IdempotencyKey`                                                                        | *string*                                                                                | :heavy_minus_sign:                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.        | 123e4567-e89b-12d3-a456-426                                                             |

### Response

**[CreateReportResponse](../../Models/Requests/CreateReportResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 403, 422, 429                 | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

> 🚧 Beta feature
>
> This feature is currently in private beta, and the final specification may still change. To
> join the beta program, reach out to [partners@mollie.com](mailto:partners@mollie.com).

Retrieve a single report by its ID. Poll this to check on a report you created, and to grab a download
link once it's ready.

The download link is pre-signed and freshly generated on every call, and expires 15 minutes after you get
it. If it expires before you download the file, just call this endpoint again for a new one. Expiry of
the link doesn't affect the report itself.

### Example Usage: get-report-200-completed

<!-- UsageSnippet language="csharp" operationID="get-report" method="get" path="/v2/reports/{reportId}" example="get-report-200-completed" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Reports.GetAsync(
    reportId: "rpt_XRAG3v9EUyCDcX99pJ2Vc",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: get-report-200-failed

<!-- UsageSnippet language="csharp" operationID="get-report" method="get" path="/v2/reports/{reportId}" example="get-report-200-failed" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Reports.GetAsync(
    reportId: "rpt_XRAG3v9EUyCDcX99pJ2Vc",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: get-report-200-pending

<!-- UsageSnippet language="csharp" operationID="get-report" method="get" path="/v2/reports/{reportId}" example="get-report-200-pending" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Reports.GetAsync(
    reportId: "rpt_XRAG3v9EUyCDcX99pJ2Vc",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ReportId`                                                                       | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related report.                                            | rpt_XRAG3v9EUyCDcX99pJ2Vc                                                        |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetReportResponse](../../Models/Requests/GetReportResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 403, 404, 429                 | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |