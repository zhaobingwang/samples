using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Center
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResource()
        {
            return new List<ApiResource> {
                new ApiResource("api","Test Api")
            };

        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client(){
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api"}
                }
            };
        }
    }
}
