# Methods

## Overview

### Available Operations

* [List](#list) - List payment methods
* [All](#all) - List all payment methods
* [Get](#get) - Get payment method
* [Enable](#enable) - Enable payment method
* [Disable](#disable) - Disable payment method
* [EnableIssuer](#enableissuer) - Enable payment method issuer
* [DisableIssuer](#disableissuer) - Disable payment method issuer

## List

Retrieve all enabled payment methods. The results of this endpoint are
**not** paginated — unlike most other list endpoints in our API.

For test mode, all pending and enabled payment methods are returned. If no
payment methods are requested yet, the most popular payment methods are returned in the test mode. For live
mode, only fully enabled payment methods are returned.

Payment methods can be requested and enabled via the Mollie Dashboard, or
via the [Enable payment method endpoint](enable-method) of the Profiles API.

The list can optionally be filtered using a number of parameters described
below.

By default, only payment methods for the Euro currency are returned. If you
wish to retrieve payment methods which exclusively support other currencies (e.g. Twint), you need to use the
`amount` parameters.

ℹ️ **Note:** This endpoint only returns **online** payment methods. If you wish to retrieve the information about
a non-online payment method, you can use the [Get payment method endpoint](get-method).

### Example Usage: list-method-200-3

<!-- UsageSnippet language="csharp" operationID="list-methods" method="get" path="/v2/methods" example="list-method-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListMethodsRequest req = new ListMethodsRequest() {
    SequenceType = SequenceType.Oneoff,
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Resource = MethodResourceParameter.Payments,
    BillingCountry = "DE",
    IncludeWallets = MethodIncludeWalletsParameter.Applepay,
    OrderLineCategories = LineCategories.Eco,
    Include = "issuers",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.ListAsync(req);

// handle response
```
### Example Usage: list-methods-200-1

<!-- UsageSnippet language="csharp" operationID="list-methods" method="get" path="/v2/methods" example="list-methods-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListMethodsRequest req = new ListMethodsRequest() {
    SequenceType = SequenceType.Oneoff,
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Resource = MethodResourceParameter.Payments,
    BillingCountry = "DE",
    IncludeWallets = MethodIncludeWalletsParameter.Applepay,
    OrderLineCategories = LineCategories.Eco,
    Include = "issuers",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.ListAsync(req);

// handle response
```
### Example Usage: list-methods-200-2

<!-- UsageSnippet language="csharp" operationID="list-methods" method="get" path="/v2/methods" example="list-methods-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListMethodsRequest req = new ListMethodsRequest() {
    SequenceType = SequenceType.Oneoff,
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Resource = MethodResourceParameter.Payments,
    BillingCountry = "DE",
    IncludeWallets = MethodIncludeWalletsParameter.Applepay,
    OrderLineCategories = LineCategories.Eco,
    Include = "issuers",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [ListMethodsRequest](../../Models/Requests/ListMethodsRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[ListMethodsResponse](../../Models/Requests/ListMethodsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## All

Retrieve all payment methods that Mollie offers, regardless of the eligibility of the organization for the specific
method. The results of this endpoint are **not** paginated — unlike most other list endpoints in our API.

The list can optionally be filtered using a number of parameters described below.

ℹ️ **Note:** This endpoint only returns **online** payment methods. If you wish to retrieve the information about
a non-online payment method, you can use the [Get payment method endpoint](get-method).

### Example Usage: list-all-methods-200-1

<!-- UsageSnippet language="csharp" operationID="list-all-methods" method="get" path="/v2/methods/all" example="list-all-methods-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllMethodsRequest req = new ListAllMethodsRequest() {
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Include = "issuers",
    SequenceType = SequenceType.Oneoff,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.AllAsync(req);

// handle response
```
### Example Usage: list-all-methods-200-2

<!-- UsageSnippet language="csharp" operationID="list-all-methods" method="get" path="/v2/methods/all" example="list-all-methods-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllMethodsRequest req = new ListAllMethodsRequest() {
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Include = "issuers",
    SequenceType = SequenceType.Oneoff,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.AllAsync(req);

// handle response
```
### Example Usage: list-all-methods-200-3

<!-- UsageSnippet language="csharp" operationID="list-all-methods" method="get" path="/v2/methods/all" example="list-all-methods-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllMethodsRequest req = new ListAllMethodsRequest() {
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Include = "issuers",
    SequenceType = SequenceType.Oneoff,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.AllAsync(req);

// handle response
```
### Example Usage: list-all-methods-200-4

<!-- UsageSnippet language="csharp" operationID="list-all-methods" method="get" path="/v2/methods/all" example="list-all-methods-200-4" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

ListAllMethodsRequest req = new ListAllMethodsRequest() {
    Locale = Locale.EnUS,
    Amount = new Amount() {
        Currency = "EUR",
        Value = "10.00",
    },
    Include = "issuers",
    SequenceType = SequenceType.Oneoff,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.AllAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [ListAllMethodsRequest](../../Models/Requests/ListAllMethodsRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[ListAllMethodsResponse](../../Models/Requests/ListAllMethodsResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Get

Retrieve a single payment method by its ID.

If a method is not available on this profile, a `404 Not Found` response is
returned. If the method is available but not enabled yet, a status `403 Forbidden` is returned. You can enable
payments methods via the [Enable payment method endpoint](enable-method) of the Profiles API, or via
the Mollie Dashboard.

If you do not know the method's ID, you can use the [methods list
endpoint](list-methods) to retrieve all payment methods that are available.

Additionally, it is possible to check if wallet methods such as Apple Pay
are enabled by passing the wallet ID (`applepay`) as the method ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get-method" method="get" path="/v2/methods/{methodId}" example="get-method-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(
    profileId: "pfl_5B8cwPMGnU",
    testmode: false,
    security: new Security() {
        ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
    }
);

GetMethodRequest req = new GetMethodRequest() {
    MethodId = MethodEnum.Ideal,
    Locale = Locale.EnUS,
    Currency = "EUR",
    Include = "issuers",
    SequenceType = SequenceType.Oneoff,
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
};

var res = await sdk.Methods.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                     | Type                                                          | Required                                                      | Description                                                   |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| `request`                                                     | [GetMethodRequest](../../Models/Requests/GetMethodRequest.md) | :heavy_check_mark:                                            | The request object to use for the request.                    |

### Response

**[GetMethodResponse](../../Models/Requests/GetMethodResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 400, 404, 429                      | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Enable

Enable a payment method on a specific profile.

When using a profile-specific API credential, the alias `me` can be used
instead of the profile ID to refer to the current profile.

Some payment methods require extra steps in order to be activated. In cases
where a step at the payment method provider needs to be completed first, the status will be set to
`pending-external` and the response will contain a link to complete the activation at the provider.

To enable voucher or gift card issuers, refer to the [Enable payment method issuer](enable-method-issuer) endpoint.

### Example Usage: enable-method-200-1

<!-- UsageSnippet language="csharp" operationID="enable-method" method="post" path="/v2/profiles/{profileId}/methods/{methodId}" example="enable-method-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Methods.EnableAsync(
    profileId: "pfl_5B8cwPMGnU",
    methodId: MethodEnum.Ideal,
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: enable-method-200-2

<!-- UsageSnippet language="csharp" operationID="enable-method" method="post" path="/v2/profiles/{profileId}/methods/{methodId}" example="enable-method-200-2" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Methods.EnableAsync(
    profileId: "pfl_5B8cwPMGnU",
    methodId: MethodEnum.Ideal,
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```
### Example Usage: enable-method-200-3

<!-- UsageSnippet language="csharp" operationID="enable-method" method="post" path="/v2/profiles/{profileId}/methods/{methodId}" example="enable-method-200-3" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Methods.EnableAsync(
    profileId: "pfl_5B8cwPMGnU",
    methodId: MethodEnum.Ideal,
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ProfileId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related profile.                                           | pfl_5B8cwPMGnU                                                                   |
| `MethodId`                                                                       | [MethodEnum](../../Models/Components/MethodEnum.md)                              | :heavy_check_mark:                                                               | Provide the ID of the related payment method.                                    | ideal                                                                            |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[EnableMethodResponse](../../Models/Requests/EnableMethodResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## Disable

Disable a payment method on a specific profile.

When using a profile-specific API credential, the alias `me` can be used
instead of the profile ID to refer to the current profile.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="disable-method" method="delete" path="/v2/profiles/{profileId}/methods/{methodId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Methods.DisableAsync(
    profileId: "pfl_5B8cwPMGnU",
    methodId: MethodEnum.Ideal,
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ProfileId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related profile.                                           | pfl_5B8cwPMGnU                                                                   |
| `MethodId`                                                                       | [MethodEnum](../../Models/Components/MethodEnum.md)                              | :heavy_check_mark:                                                               | Provide the ID of the related payment method.                                    | ideal                                                                            |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[DisableMethodResponse](../../Models/Requests/DisableMethodResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## EnableIssuer

Enable an issuer for a payment method on a specific profile.

Currently only the payment methods `voucher` and `giftcard` are supported.

When using a profile-specific API credential, the alias `me` can be used instead of the profile ID to refer to the
current profile.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="enable-method-issuer" method="post" path="/v2/profiles/{profileId}/methods/{methodId}/issuers/{issuerId}" example="enable-method-issuer-200-1" -->
```csharp
using Mollie;
using Mollie.Models.Components;
using Mollie.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

EnableMethodIssuerRequest req = new EnableMethodIssuerRequest() {
    ProfileId = "pfl_5B8cwPMGnU",
    MethodId = MethodIdWithIssuer.Voucher,
    IssuerId = "edenred-france-sports",
    IdempotencyKey = "123e4567-e89b-12d3-a456-426",
    RequestBody = new EnableMethodIssuerRequestBody() {
        ContractId = "ideal",
    },
};

var res = await sdk.Methods.EnableIssuerAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [EnableMethodIssuerRequest](../../Models/Requests/EnableMethodIssuerRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[EnableMethodIssuerResponse](../../Models/Requests/EnableMethodIssuerResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |

## DisableIssuer

Disable an issuer for a payment method on a specific profile.

Currently only the payment methods `voucher` and `giftcard` are supported.

When using a profile-specific API credential, the alias `me` can be used instead of the profile ID to refer to the
current profile.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="disable-method-issuer" method="delete" path="/v2/profiles/{profileId}/methods/{methodId}/issuers/{issuerId}" -->
```csharp
using Mollie;
using Mollie.Models.Components;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

var res = await sdk.Methods.DisableIssuerAsync(
    profileId: "pfl_5B8cwPMGnU",
    methodId: MethodIdWithIssuer.Voucher,
    issuerId: "edenred-france-sports",
    idempotencyKey: "123e4567-e89b-12d3-a456-426"
);

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `ProfileId`                                                                      | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related profile.                                           | pfl_5B8cwPMGnU                                                                   |
| `MethodId`                                                                       | [MethodIdWithIssuer](../../Models/Components/MethodIdWithIssuer.md)              | :heavy_check_mark:                                                               | Provide the ID of the related payment method.                                    | voucher                                                                          |
| `IssuerId`                                                                       | *string*                                                                         | :heavy_check_mark:                                                               | Provide the ID of the related issuer.                                            | edenred-france-sports                                                            |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key to ensure idempotent requests. This key should be a UUID v4 string. | 123e4567-e89b-12d3-a456-426                                                      |

### Response

**[DisableMethodIssuerResponse](../../Models/Requests/DisableMethodIssuerResponse.md)**

### Errors

| Error Type                         | Status Code                        | Content Type                       |
| ---------------------------------- | ---------------------------------- | ---------------------------------- |
| Mollie.Models.Errors.ErrorResponse | 404, 429                           | application/hal+json               |
| Mollie.Models.Errors.APIException  | 4XX, 5XX                           | \*/\*                              |