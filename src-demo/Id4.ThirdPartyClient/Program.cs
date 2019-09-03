using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServer4;

namespace Id4.ThirdPartyClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var discovery = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (discovery.IsError)
            {
                Console.WriteLine(discovery.Error);
            }

            var tokenCient = new TokenClient(discovery.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenCient.RequestClientCredentialsAsync("api");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            else
            {
                Console.WriteLine(tokenResponse.Json);
            }

            var httpClient = new HttpClient();
            httpClient.SetBearerToken(tokenResponse.AccessToken);
            var response = await httpClient.GetAsync("http://localhost:5001/api/values");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            Console.ReadLine();
        }
    }
}
