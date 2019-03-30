using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace Sample.Utilities
{
    public class HttpOperator
    {
        private static HttpClient client = new HttpClient();
        public async Task<T> PostAsync<T>(string url, object data) where T : class, new()
        {
            try
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "C# APP");

                var content = JsonConvert.SerializeObject(data);
                content = "";
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(url, byteContent).ConfigureAwait(false);
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    // TODO:success log record
                    return JsonConvert.DeserializeObject<T>(result);
                }
                // TODO:failed log record
                return new T();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    string responseContent = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    throw new Exception($"response:{responseContent}", ex);
                }
                throw;
            }
        }
        public async Task<T> GetAsync<T>(string url, object data) where T : class, new()
        {
            try
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "C# APP");

                string reqeustUrl = $"{url}?{(data == null ? "" : GetQueryString(data))}";
                // TODO:log record
                var response = await client.GetAsync(reqeustUrl).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                // TODO:log record

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    // TODO:failed log record
                    return new T();
                }
                // TODO:success log record
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    string responseContent = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    throw new Exception($"Response:{responseContent}", ex);
                }
                throw;
            }
        }
        private string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select $"{p.Name}={HttpUtility.UrlEncode(p.GetValue(obj, null).ToString())}";
            return string.Join("&", properties.ToArray());
        }
    }
}
