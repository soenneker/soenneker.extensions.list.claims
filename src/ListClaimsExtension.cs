using System.Collections.Generic;
using System.Security.Claims;

namespace Soenneker.Extensions.List.Claims;

/// <summary>
/// A collection of helpful List Claims extension methods.
/// </summary>
public static class ListClaimsExtension
{
    public static ClaimsPrincipal ToClaimsPrincipal(this List<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims);
        return new ClaimsPrincipal(identity);
    }
}
