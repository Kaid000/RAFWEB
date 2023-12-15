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

       
        

        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile(),
        new IdentityResource("roles", new[] { "role" })
    };
    }
}
