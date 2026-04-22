using AwesomeAssertions;
using Soenneker.Tests.Unit;
using System.Collections.Generic;
using System.Security.Claims;

namespace Soenneker.Extensions.List.Claims.Tests;

public sealed class ListClaimsExtensionTests : UnitTest
{
    [Test]
    public void ToClaimsPrincipal_should_set_IsAuthenticated_true_when_authenticationType_is_provided()
    {
        var claims = new List<Claim> {new(ClaimTypes.NameIdentifier, "123")};

        ClaimsPrincipal principal = claims.ToClaimsPrincipal("TestAuthType");

        principal.Identity.Should().NotBeNull();
        principal.Identity!.IsAuthenticated.Should().BeTrue();
        principal.Claims.Should().Contain(c => c.Type == ClaimTypes.NameIdentifier && c.Value == "123");
    }

    [Test]
    public void ToClaimsPrincipal_should_set_IsAuthenticated_false_when_authenticationType_is_empty()
    {
        var claims = new List<Claim> {new(ClaimTypes.NameIdentifier, "123")};

        ClaimsPrincipal principal = claims.ToClaimsPrincipal("");

        principal.Identity.Should().NotBeNull();
        principal.Identity!.IsAuthenticated.Should().BeFalse();
    }

    [Test]
    public void ToClaimsPrincipal_should_return_empty_principal_when_claims_are_empty()
    {
        var claims = new List<Claim>();

        ClaimsPrincipal principal = claims.ToClaimsPrincipal("TestAuthType");

        principal.Identity.Should().BeNull();
        principal.Identities.Should().BeEmpty();
        principal.Claims.Should().BeEmpty();
    }
}
