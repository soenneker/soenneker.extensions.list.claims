using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Soenneker.Extensions.List.Claims;

/// <summary>
/// A collection of helpful List Claims extension methods.
/// </summary>
public static class ListClaimsExtension
{
    /// <summary>
    /// Creates a <see cref="ClaimsPrincipal"/> from a collection of <see cref="Claim"/>s.
    /// </summary>
    /// <param name="claims">The claims to wrap into a principal.</param>
    /// <returns>
    /// A <see cref="ClaimsPrincipal"/> whose identity contains the provided claims.
    /// If <paramref name="claims"/> is empty, returns an empty <see cref="ClaimsPrincipal"/> (no identities).
    /// </returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ClaimsPrincipal ToClaimsPrincipal(this List<Claim> claims)
    {
        if (claims is null)
            throw new ArgumentNullException(nameof(claims));

        if (claims.Count == 0)
            return new ClaimsPrincipal();

        return new ClaimsPrincipal(new ClaimsIdentity(claims));
    }
}
