[![](https://img.shields.io/nuget/v/soenneker.extensions.list.claims.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.list.claims/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.claims/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.claims/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.list.claims.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.list.claims/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.list.claims/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.list.claims/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.List.Claims
Extension methods for turning claim lists into identities, principals, and other authentication-friendly representations.

## Installation

```bash
dotnet add package Soenneker.Extensions.List.Claims
```

## Usage

```csharp
using Soenneker.Extensions.List.Claims;

var claims = new List<Claim>
{
    new(ClaimTypes.NameIdentifier, "customer-123"),
    new(ClaimTypes.Role, "admin")
};

ClaimsPrincipal principal = claims.ToClaimsPrincipal("Bearer");
bool authenticated = principal.Identity!.IsAuthenticated; // true
```

`authenticationType` is passed to `ClaimsIdentity`; a non-empty value is what makes `IsAuthenticated` true. An empty claim list returns a principal with no identities at all, regardless of the authentication type. A null list throws `ArgumentNullException`.
