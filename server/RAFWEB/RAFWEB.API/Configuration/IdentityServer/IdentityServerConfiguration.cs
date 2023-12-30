using IdentityServer4.Models;
using IdentityServer4;

namespace RAFWEB.API.Configuration.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<ApiResource> GetApis() => new List<ApiResource>
    {
        new(IdentityServerConstants.LocalApi.ScopeName)
        {
            Scopes = new[] { IdentityServerConstants.LocalApi.ScopeName }
        },
        new("roles", "My Roles", new[] { "role" }),
    };

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
        {
            new(IdentityServerConstants.LocalApi.ScopeName),
        };
        }
        public static IEnumerable<Client> GetClients(IdentityServerSettings identityServerSettings) => new List<Client>
        {
        new()
        {
            ClientId = identityServerSettings.AppId,
            RequireClientSecret = false,
            UpdateAccessTokenClaimsOnRefresh = true,
            RequireConsent = false,
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            AllowedScopes =
            {
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "roles"
            },
            RefreshTokenExpiration = TokenExpiration.Sliding,
            RefreshTokenUsage = TokenUsage.ReUse,
            AccessTokenLifetime = identityServerSettings.AccessTokenLifetime,
            IdentityTokenLifetime = identityServerSettings.IdentityTokenLifetime,
            AuthorizationCodeLifetime = identityServerSettings.AuthorizationCodeLifetime,
            SlidingRefreshTokenLifetime = identityServerSettings.SlidingRefreshTokenLifetime,
            AbsoluteRefreshTokenLifetime = identityServerSettings.AbsoluteRefreshTokenLifetime,
            AccessTokenType = AccessTokenType.Jwt,
        },
        };




        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile(),
        new IdentityResource("roles", new[] { "role" })
    };
    }
}
