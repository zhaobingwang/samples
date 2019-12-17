using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeSnippets.WebMvc
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResource()
        {
            return new List<ApiResource> {
                new ApiResource("api","API Application")
            };

        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client(){
    ClientId = "mvc",
    ClientSecrets = { new Secret("secret".Sha256()) },

    AllowedGrantTypes = GrantTypes.Code,
    RequireConsent = false,
    RequirePkce = true,

    // where to redirect to after login
    RedirectUris = { "http://localhost:5001/signin-oidc" },

    // where to redirect to after logout
    PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

    AllowedScopes = new List<string>
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "api1"
    },

    AllowOfflineAccess = true
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser{
                    SubjectId="1",
                    Username="admin",
                    Password="123456",
                    Claims=new List<Claim>
                    {
                        new Claim("name","admin"),
                        new Claim("website","https://www.baidu.com")
                    }
                }
            };
        }
    }
}
