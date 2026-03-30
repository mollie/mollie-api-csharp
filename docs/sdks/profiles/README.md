# Profiles

## Overview

### Available Operations

* [Create](#create) - Create profile
* [List](#list) - List profiles
* [Get](#get) - Get profile
* [Update](#update) - Update profile
* [Delete](#delete) - Delete profile
* [GetCurrent](#getcurrent) - Get current profile

## Create

Create a profile to process payments on.

Profiles are required for payment processing. Normally they are created via the Mollie dashboard. Alternatively, you
can use this endpoint to automate profile creation.

### Example Usage: create-profile-201-1

<!-- UsageSnippet language="csharp" operationID="create-profile" method="post" path="/profiles" example="create-profile-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.CreateAsync(
    profileRequest: new ProfileRequest() {
        Name = "My website name",
        Website = "https://example.com",
        Email = "test@mollie.com",
        Phone = "+31208202070",
        Description = "My website description",
        CountriesOfActivity = new List<string>() {
            "NL",
            "GB",
        },
        BusinessCategory = "OTHER_MERCHANDISE",
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: create-profile-201-2

<!-- UsageSnippet language="csharp" operationID="create-profile" method="post" path="/profiles" example="create-profile-201-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.CreateAsync(
    profileRequest: new ProfileRequest() {
        Name = "My website name",
        Website = "https://example.com",
        Email = "test@mollie.com",
        Phone = "+31208202070",
        Description = "My website description",
        CountriesOfActivity = new List<string>() {
            "NL",
            "GB",
        },
        BusinessCategory = "OTHER_MERCHANDISE",
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ProfileRequest`                                                                 | [ProfileRequest](../../Models/Components/ProfileRequest.md)                      | :heavy_check_mark:                                                               | N/A                                                                              |                                                                                  |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[CreateProfileResponse](../../Models/Requests/CreateProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 403, 422                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all of your profiles.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-profiles" method="get" path="/profiles" example="list-profiles-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListProfilesResponse? res = await sdk.Profiles.ListAsync(
    fromP: "pfl_QkEhN94Ba",
    limit: 50,
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                                                                      | Type                                                                                                                           | Required                                                                                                                       | Description                                                                                                                    | Example                                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| `From`                                                                                                                         | *string*                                                                                                                       | :heavy_minus_sign:                                                                                                             | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the<br/>result set. |                                                                                                                                |
| `Limit`                                                                                                                        | *long*                                                                                                                         | :heavy_minus_sign:                                                                                                             | The maximum number of items to return. Defaults to 50 items.                                                                   | 50                                                                                                                             |
| `IdempotencyKey`                                                                                                               | *string*                                                                                                                       | :heavy_minus_sign:                                                                                                             | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                               | 123e4567-e89b-12d3-a456-426                                                                                                    |

### Response

**[ListProfilesResponse](../../Models/Requests/ListProfilesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single profile by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-profile" method="get" path="/profiles/{profileId}" example="get-profile-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

var res = await sdk.Profiles.GetAsync(
    profileId: "pfl_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                               | Type                                                                                                                                                                    | Required                                                                                                                                                                | Description                                                                                                                                                             | Example                                                                                                                                                                 |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `ProfileId`                                                                                                                                                             | *string*                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                      | Provide the ID of the related profile.                                                                                                                                  | pfl_5B8cwPMGnU                                                                                                                                                          |
| `Testmode`                                                                                                                                                              | *bool*                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                      | You can enable test mode by setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. |                                                                                                                                                                         |
| `IdempotencyKey`                                                                                                                                                        | *string*                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                             |

### Response

**[GetProfileResponse](../../Models/Requests/GetProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 410                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Update an existing profile.

Profiles are required for payment processing. Normally they are created and updated via the Mollie dashboard.
Alternatively, you can use this endpoint to automate profile management.

### Example Usage: update-profile-200-1

<!-- UsageSnippet language="csharp" operationID="update-profile" method="patch" path="/profiles/{profileId}" example="update-profile-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.UpdateAsync(
    profileId: "pfl_5B8cwPMGnU",
    requestBody: new UpdateProfileRequestBody() {
        Name = "My new website name",
        Website = "https://example.com",
        Email = "test@mollie.com",
        Phone = "+31208202071",
        Description = "My website description",
        CountriesOfActivity = new List<string>() {
            "NL",
            "GB",
        },
        BusinessCategory = "OTHER_MERCHANDISE",
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: update-profile-200-2

<!-- UsageSnippet language="csharp" operationID="update-profile" method="patch" path="/profiles/{profileId}" example="update-profile-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.UpdateAsync(
    profileId: "pfl_5B8cwPMGnU",
    requestBody: new UpdateProfileRequestBody() {
        Name = "My new website name",
        Website = "https://example.com",
        Email = "test@mollie.com",
        Phone = "+31208202071",
        Description = "My website description",
        CountriesOfActivity = new List<string>() {
            "NL",
            "GB",
        },
        BusinessCategory = "OTHER_MERCHANDISE",
    },
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ProfileId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related profile.                                           | pfl_5B8cwPMGnU                                                                   |
| `RequestBody`                                                                    | [UpdateProfileRequestBody](../../Models/Requests/UpdateProfileRequestBody.md)    | :heavy_check_mark:                                                               | N/A                                                                              |                                                                                  |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[UpdateProfileResponse](../../Models/Requests/UpdateProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 403, 404, 410, 422                 | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Delete

Delete a profile. A deleted profile and its related credentials can no longer be used for accepting payments.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-profile" method="delete" path="/profiles/{profileId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    OrganizationAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.DeleteAsync(
    profileId: "pfl_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ProfileId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related profile.                                           | pfl_5B8cwPMGnU                                                                   |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[DeleteProfileResponse](../../Models/Requests/DeleteProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 410                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## GetCurrent

Retrieve the currently authenticated profile. A convenient alias of the [Get profile](get-profile)
endpoint.

For a complete reference of the profile object, refer to the [Get profile](get-profile) endpoint
documentation.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-current-profile" method="get" path="/profiles/me" example="get-current-profile-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.GetCurrentAsync(idempotencyKey: "123e4567-e89b-12d3-a456-426");

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[GetCurrentProfileResponse](../../Models/Requests/GetCurrentProfileResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |