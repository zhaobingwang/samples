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
                    ClientId="mvc",
                    ClientName="MVC WebApp Client",
                    ClientUri="http://localhost:5001",
                    LogoUri="https://blog.tedd.no/wp-content/uploads/2019/06/128-Bitmap-BIG_ASP.NET-Core-MVC-Logo_2colors_Square_RGB.png",
                    AllowRememberConsent=true,
                    Description="This is a sample.",

                    AllowedGrantTypes=GrantTypes.Implicit,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    RequireConsent=true,
                    RedirectUris={ "http://localhost:5001/signin-oidc"},
                    PostLogoutRedirectUris={ "http://localhost:5001/signout-callback-oidc"},
                    AllowedScopes={
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        //IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                    }
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
