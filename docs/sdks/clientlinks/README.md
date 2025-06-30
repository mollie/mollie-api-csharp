# ClientLinks
(*ClientLinks*)

## Overview

### Available Operations

* [Create](#create) - Create client link

## Create

Link a new or existing organization to your OAuth application, in effect creating a new client. The response contains a `clientLink` where you should redirect your customer to.

The `clientLink` URL behaves similar to the regular OAuth authorization URL. It supports the following parameters from the [Authorize](authorize) endpoint:

* `client_id`
* `state`
* `approval_prompt`
* `scope`

We recommend at least requesting the scopes `onboarding.read onboarding.write` this way.

Error handling is also dealt with similar to the [Authorize](authorize) endpoint: the customer is redirected back to your app's redirect URL with the `error` and `error_description` parameters added to the URL.

> 🔑 Access with
>
> [Access token with **clients.write**](/reference/authentication)

### Example Usage

```csharp
using MollieApi;
using MollieApi.Models.Components;
using MollieApi.Models.Requests;

var sdk = new Client(security: new Security() {
    ApiKey = "<YOUR_BEARER_TOKEN_HERE>",
});

CreateClientLinkRequest req = new CreateClientLinkRequest() {
    Owner = new Owner() {
        Email = "john@example.org",
        GivenName = "John",
        FamilyName = "Doe",
        Locale = "en_US",
    },
    Name = "Acme Corporation",
    Address = new CreateClientLinkAddress() {
        StreetAndNumber = "Main Street 123",
        PostalCode = "1234AB",
        City = "Amsterdam",
        Country = "NL",
    },
    RegistrationNumber = "12345678",
    VatNumber = "123456789B01",
};

var res = await sdk.ClientLinks.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [CreateClientLinkRequest](../../Models/Requests/CreateClientLinkRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[CreateClientLinkResponse](../../Models/Requests/CreateClientLinkResponse.md)**

### Errors

| Error Type                                                                  | Status Code                                                                 | Content Type                                                                |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| MollieApi.Models.Errors.CreateClientLinkNotFoundHalJSONException            | 404                                                                         | application/hal+json                                                        |
| MollieApi.Models.Errors.CreateClientLinkUnprocessableEntityHalJSONException | 422                                                                         | application/hal+json                                                        |
| MollieApi.Models.Errors.APIException                                        | 4XX, 5XX                                                                    | \*/\*                                                                       |