using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeSnippets.BCL.System_Net_Http
{
    public class HttpClientSnippets
    {
        private const string BASE_ADDRESS = "https://jsonplaceholder.typicode.com";
        HttpClient httpClient;
        public HttpClientSnippets()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BASE_ADDRESS)
            };
        }

        public async Task GetAsync()
        {
            httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync($"{BASE_ADDRESS}/users");
            Console.WriteLine(result);
        }

        private async Task<string> GetAsync(string url, IDictionary<string, string> parameters)
        {
            try
            {
                if (parameters != null && parameters.Count > 0)
                {
                    if (url.Contains("?"))
                        url = $"{url}&{BuildQuery(parameters)}";
                    else
                        url = $"{url}?{BuildQuery(parameters)}";
                }
                var query = new Uri(url).Query;
                var result = await httpClient.GetStringAsync(query);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
        }

        private string BuildQuery(IDictionary<string, string> parameters)
        {
            var data = new StringBuilder();
            var hasParams = false;
            using (var dem = parameters.GetEnumerator())
            {
                while (dem.MoveNext())
                {
                    var name = dem.Current.Key;
                    var value = dem.Current.Value;

                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
                        continue;

                    if (hasParams)
                        data.Append("&");
                    data.Append(name);
                    data.Append("=");
                    var encodedValue = HttpUtility.UrlEncode(value, Encoding.GetEncoding("UTF-8"));
                    data.Append(encodedValue);
                    hasParams = true;
                }
                return data.ToString();
            }
        }
    }
}
