using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        //Papers 
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        //IdentityResources - Claim group names
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        //API Scope - Resources that a client can access
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(name:"geek_shopping", "GeekShopping Server"),
                new ApiScope(name:"read", "Read Data"),
                new ApiScope(name:"write", "Write Data"),
                new ApiScope(name:"delete", "Delete data")
            };

        //Client - software component that requests a token
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client{
                    ClientId = "client",
                    ClientSecrets = { new Secret("nigt@c#52489700".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client{
                    ClientId = "geek_shopping",
                    ClientSecrets = { new Secret("nigt@c#52489700".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:19818/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:19818/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "geek_shopping"
                    }
                },

            };



    }
}
