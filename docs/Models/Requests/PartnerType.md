# PartnerType

Indicates the type of partner. Will be `null` if the currently authenticated organization is not
enrolled as a partner.

## Example Usage

```csharp
using Mollie.Models.Requests;

var value = PartnerType.Oauth;
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Oauth`      | oauth        |
| `Signuplink` | signuplink   |
| `Useragent`  | useragent    |