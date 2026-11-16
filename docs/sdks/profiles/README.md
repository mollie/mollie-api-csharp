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

<!-- UsageSnippet language="csharp" operationID="create-profile" method="post" path="/v2/profiles" example="create-profile-201-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z"
);

// handle response
```
### Example Usage: create-profile-201-2

<!-- UsageSnippet language="csharp" operationID="create-profile" method="post" path="/v2/profiles" example="create-profile-201-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
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
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `ProfileRequest`                                                                                                                                                                        | [ProfileRequest](../../Models/Components/ProfileRequest.md)                                                                                                                             | :heavy_check_mark:                                                                                                                                                                      | N/A                                                                                                                                                                                     |                                                                                                                                                                                         |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |

### Response

**[CreateProfileResponse](../../Models/Requests/CreateProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 403, 422, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## List

Retrieve a list of all of your profiles.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-profiles" method="get" path="/v2/profiles" example="list-profiles-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

ListProfilesRequest req = new ListProfilesRequest() {
    From = "pfl_QkEhN94Ba",
    Limit = 50,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

ListProfilesResponse? res = await sdk.Profiles.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `request`                                                           | [ListProfilesRequest](../../Models/Requests/ListProfilesRequest.md) | :heavy_check_mark:                                                  | The request object to use for the request.                          |

### Response

**[ListProfilesResponse](../../Models/Requests/ListProfilesResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single profile by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-profile" method="get" path="/v2/profiles/{profileId}" example="get-profile-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    testmode: false,
    security: new Security() {
        AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetProfileRequest req = new GetProfileRequest() {
    ProfileId = "pfl_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
};

var res = await sdk.Profiles.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [GetProfileRequest](../../Models/Requests/GetProfileRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[GetProfileResponse](../../Models/Requests/GetProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 410, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Update

Update an existing profile.

Profiles are required for payment processing. Normally they are created and updated via the Mollie dashboard.
Alternatively, you can use this endpoint to automate profile management.

### Example Usage: update-profile-200-1

<!-- UsageSnippet language="csharp" operationID="update-profile" method="patch" path="/v2/profiles/{profileId}" example="update-profile-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateProfileRequest req = new UpdateProfileRequest() {
    ProfileId = "pfl_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdateProfileRequestBody() {
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
};

var res = await sdk.Profiles.UpdateAsync(req);

// handle response
```
### Example Usage: update-profile-200-2

<!-- UsageSnippet language="csharp" operationID="update-profile" method="patch" path="/v2/profiles/{profileId}" example="update-profile-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

UpdateProfileRequest req = new UpdateProfileRequest() {
    ProfileId = "pfl_5B8cwPMGnU",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    XClientSignature = "MEUCIQDx8sJvK3z...",
    XClientSignedAt = "2025-01-01T12:00:00Z",
    RequestBody = new UpdateProfileRequestBody() {
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
};

var res = await sdk.Profiles.UpdateAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [UpdateProfileRequest](../../Models/Requests/UpdateProfileRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[UpdateProfileResponse](../../Models/Requests/UpdateProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 403, 404, 410, 422, 429            | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Delete

Delete a profile. A deleted profile and its related credentials can no longer be used for accepting payments.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-profile" method="delete" path="/v2/profiles/{profileId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    AdvancedAccessToken = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.DeleteAsync(
    profileId: "pfl_5B8cwPMGnU",
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `ProfileId`                                                                                                                                                                             | *string*                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                      | Provide the ID of the related profile.                                                                                                                                                  | pfl_5B8cwPMGnU                                                                                                                                                                          |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |

### Response

**[DeleteProfileResponse](../../Models/Requests/DeleteProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 410, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## GetCurrent

Retrieve the currently authenticated profile. A convenient alias of the [Get profile](get-profile)
endpoint.

For a complete reference of the profile object, refer to the [Get profile](get-profile) endpoint
documentation.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-current-profile" method="get" path="/v2/profiles/me" example="get-current-profile-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.GetCurrentAsync(
    idempotencyKey: "123e4567-e89b-12d3-a456-426",
    xClientSignature: "MEUCIQDx8sJvK3z...",
    xClientSignedAt: "2025-01-01T12:00:00Z"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                               | Type                                                                                                                                                                                    | Required                                                                                                                                                                                | Description                                                                                                                                                                             | Example                                                                                                                                                                                 |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `IdempotencyKey`                                                                                                                                                                        | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A unique key to ensure idempotent requests. This key should be a UUID v4 string.                                                                                                        | 123e4567-e89b-12d3-a456-426                                                                                                                                                             |
| `XClientSignature`                                                                                                                                                                      | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | A cryptographic signature of the request, used to verify that it was sent by you and hasn't been tampered with. Required if you've enabled request signing for your integration.        | MEUCIQDx8sJvK3z...                                                                                                                                                                      |
| `XClientSignedAt`                                                                                                                                                                       | *string*                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                      | The timestamp, in ISO 8601 format, at which you generated the `X-Client-Signature`. Required together with `X-Client-Signature` if you've enabled request signing for your integration. | 2025-01-01T12:00:00Z                                                                                                                                                                    |

### Response

**[GetCurrentProfileResponse](../../Models/Requests/GetCurrentProfileResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 429                                | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |