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
```

`authenticationType` is passed directly to `ClaimsIdentity`. A nonempty value makes `principal.Identity.IsAuthenticated` return `true`; this is a .NET identity-state convention, not proof that a token, credential, issuer, or claim was validated.

Only construct an authenticated principal from claims produced by a trusted authentication process. Calling this method on request-supplied claims with a label such as `"Bearer"` does not authenticate the caller and can create an authorization vulnerability.

The resulting principal contains one identity when the list has at least one claim. An empty claim list returns a principal with no identities, regardless of `authenticationType`:

```csharp
ClaimsPrincipal empty = new List<Claim>().ToClaimsPrincipal("Bearer");
bool hasIdentity = empty.Identity is not null; // false
```

A null list throws `ArgumentNullException`. The method does not deduplicate, normalize, filter, or validate claim types and values.
