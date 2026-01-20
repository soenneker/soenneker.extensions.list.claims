using Soenneker.Tests.Unit;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace Soenneker.Extensions.List.Claims.Tests;

public sealed class ListClaimsExtensionTests : UnitTest
{
    [Fact]
    public void ToClaimsPrincipal_should_set_IsAuthenticated_true_when_authenticationType_is_provided()
    {
        var claims = new List<Claim> {new(ClaimTypes.NameIdentifier, "123")};

        ClaimsPrincipal principal = claims.ToClaimsPrincipal("TestAuthType");

        Assert.NotNull(principal.Identity);
        Assert.True(principal.Identity!.IsAuthenticated);
        Assert.Contains(principal.Claims, c => c.Type == ClaimTypes.NameIdentifier && c.Value == "123");
    }

    [Fact]
    public void ToClaimsPrincipal_should_set_IsAuthenticated_false_when_authenticationType_is_empty()
    {
        var claims = new List<Claim> {new(ClaimTypes.NameIdentifier, "123")};

        ClaimsPrincipal principal = claims.ToClaimsPrincipal("");

        Assert.NotNull(principal.Identity);
        Assert.False(principal.Identity!.IsAuthenticated);
    }

    [Fact]
    public void ToClaimsPrincipal_should_return_empty_principal_when_claims_are_empty()
    {
        var claims = new List<Claim>();

        ClaimsPrincipal principal = claims.ToClaimsPrincipal("TestAuthType");

        Assert.Null(principal.Identity);
        Assert.Empty(principal.Identities);
        Assert.Empty(principal.Claims);
    }
}
