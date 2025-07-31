# Profiles
(*Profiles*)

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

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create-profile" method="post" path="/profiles" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateProfileRequest req = new CreateProfileRequest() {
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
};

var res = await sdk.Profiles.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [CreateProfileRequest](../../Models/Requests/CreateProfileRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[CreateProfileResponse](../../Models/Requests/CreateProfileResponse.md)**

### Errors

| Error Type                                         | Status Code                                        | Content Type                                       |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| Mollie.Models.Errors.CreateProfileHalJSONException | 422                                                | application/hal+json                               |
| Mollie.Models.Errors.APIException                  | 4XX, 5XX                                           | \*/\*                                              |

## List

Retrieve a list of all of your profiles.

The results are paginated.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list-profiles" method="get" path="/profiles" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.ListAsync(
    fromP: "pfl_QkEhN94Ba",
    limit: 50
);

// handle response
```

### Parameters

| Parameter                                                                                                                      | Type                                                                                                                           | Required                                                                                                                       | Description                                                                                                                    | Example                                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| `From`                                                                                                                         | *string*                                                                                                                       | :heavy_minus_sign:                                                                                                             | Provide an ID to start the result set from the item with the given ID and onwards. This allows you to paginate the<br/>result set. | pfl_QkEhN94Ba                                                                                                                  |
| `Limit`                                                                                                                        | *long*                                                                                                                         | :heavy_minus_sign:                                                                                                             | The maximum number of items to return. Defaults to 50 items.                                                                   | 50                                                                                                                             |

### Response

**[ListProfilesResponse](../../Models/Requests/ListProfilesResponse.md)**

### Errors

| Error Type                                        | Status Code                                       | Content Type                                      |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| Mollie.Models.Errors.ListProfilesHalJSONException | 400                                               | application/hal+json                              |
| Mollie.Models.Errors.APIException                 | 4XX, 5XX                                          | \*/\*                                             |

## Get

Retrieve a single profile by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-profile" method="get" path="/profiles/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.GetAsync(
    id: "pfl_QkEhN94Ba",
    testmode: false
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                                                                                              | Type                                                                                                                                                                                                                                                                                                                                                                                   | Required                                                                                                                                                                                                                                                                                                                                                                               | Description                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Id`                                                                                                                                                                                                                                                                                                                                                                                   | *string*                                                                                                                                                                                                                                                                                                                                                                               | :heavy_check_mark:                                                                                                                                                                                                                                                                                                                                                                     | Provide the ID of the item you want to perform this operation on.                                                                                                                                                                                                                                                                                                                      | pfl_QkEhN94Ba                                                                                                                                                                                                                                                                                                                                                                          |
| `Testmode`                                                                                                                                                                                                                                                                                                                                                                             | *bool*                                                                                                                                                                                                                                                                                                                                                                                 | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                                                                                     | Most API credentials are specifically created for either live mode or test mode. In those cases the `testmode` query<br/>parameter can be omitted. For organization-level credentials such as OAuth access tokens, you can enable test mode by<br/>setting the `testmode` query parameter to `true`.<br/><br/>Test entities cannot be retrieved when the endpoint is set to live mode, and vice versa. | false                                                                                                                                                                                                                                                                                                                                                                                  |

### Response

**[GetProfileResponse](../../Models/Requests/GetProfileResponse.md)**

### Errors

| Error Type                                              | Status Code                                             | Content Type                                            |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| Mollie.Models.Errors.GetProfileNotFoundHalJSONException | 404                                                     | application/hal+json                                    |
| Mollie.Models.Errors.GetProfileGoneHalJSONException     | 410                                                     | application/hal+json                                    |
| Mollie.Models.Errors.APIException                       | 4XX, 5XX                                                | \*/\*                                                   |

## Update

Update an existing profile.

Profiles are required for payment processing. Normally they are created and updated via the Mollie dashboard.
Alternatively, you can use this endpoint to automate profile management.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update-profile" method="patch" path="/profiles/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;
using System.Collections.Generic;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.UpdateAsync(
    id: "pfl_QkEhN94Ba",
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
        Mode = ModeRequest.Live,
    }
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `Id`                                                                          | *string*                                                                      | :heavy_check_mark:                                                            | Provide the ID of the item you want to perform this operation on.             | pfl_QkEhN94Ba                                                                 |
| `RequestBody`                                                                 | [UpdateProfileRequestBody](../../Models/Requests/UpdateProfileRequestBody.md) | :heavy_check_mark:                                                            | N/A                                                                           |                                                                               |

### Response

**[UpdateProfileResponse](../../Models/Requests/UpdateProfileResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Mollie.Models.Errors.UpdateProfileNotFoundHalJSONException            | 404                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.UpdateProfileGoneHalJSONException                | 410                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.UpdateProfileUnprocessableEntityHalJSONException | 422                                                                   | application/hal+json                                                  |
| Mollie.Models.Errors.APIException                                     | 4XX, 5XX                                                              | \*/\*                                                                 |

## Delete

Delete a profile. A deleted profile and its related credentials can no longer be used for accepting payments.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete-profile" method="delete" path="/profiles/{id}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.DeleteAsync(id: "pfl_QkEhN94Ba");

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Id`                                                              | *string*                                                          | :heavy_check_mark:                                                | Provide the ID of the item you want to perform this operation on. | pfl_QkEhN94Ba                                                     |

### Response

**[DeleteProfileResponse](../../Models/Requests/DeleteProfileResponse.md)**

### Errors

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| Mollie.Models.Errors.DeleteProfileNotFoundHalJSONException | 404                                                        | application/hal+json                                       |
| Mollie.Models.Errors.DeleteProfileGoneHalJSONException     | 410                                                        | application/hal+json                                       |
| Mollie.Models.Errors.APIException                          | 4XX, 5XX                                                   | \*/\*                                                      |

## GetCurrent

Retrieve the currently authenticated profile. A convenient alias of the [Get profile](get-profile)
endpoint.

For a complete reference of the profile object, refer to the [Get profile](get-profile) endpoint
documentation.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-current-profile" method="get" path="/profiles/me" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Profiles.GetCurrentAsync();

// handle response
```

### Response

**[GetCurrentProfileResponse](../../Models/Requests/GetCurrentProfileResponse.md)**

### Errors

| Error Type                        | Status Code                       | Content Type                      |
| --------------------------------- | --------------------------------- | --------------------------------- |
| Mollie.Models.Errors.APIException | 4XX, 5XX                          | \*/\*                             |