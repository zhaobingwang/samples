using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.Text;
using System.Web;

namespace Identity.API.Services
{
    public class UserService : IUserService
    {
        private readonly string _userServiceUrl = "http://localhost:5201";
        private HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Tag> CreateTag(int userId, string tag)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("userId", userId.ToString());
            parameters.Add("value", tag);

            //var content = new FormUrlEncodedContent(parameters);
            var content = new StringContent(JsonSerializer.Serialize(parameters), Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync($"{_userServiceUrl}/user/tag/create", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var str = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Tag>(str);
            }
            return null;
        }

        private static string BuildQuery(IDictionary<string, string> parameters)
        {
            var data = new StringBuilder();
            var hasParams = false;
            using (var dem = parameters.GetEnumerator())
            {
                while (dem.MoveNext())
                {
                    var name = dem.Current.Key;
                    var value = dem.Current.Value;
                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                    {
                        if (hasParams)
                            data.Append("&");
                        data.Append(name);
                        data.Append("=");

                        var encodedValue = HttpUtility.UrlEncode(value, Encoding.UTF8);

                        data.Append(encodedValue);
                        hasParams = true;
                    }
                }
                return data.ToString();
            }
        }
    }
}
