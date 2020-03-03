using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeSnippets.Issues
{
    public class PostRequest4ApiIssues
    {
        static HttpClient httpClient = new HttpClient();
        private const string apiUrl = "http://localhost:5000";

        /// <summary>
        /// application/json
        /// </summary>
        /// <returns></returns>
        public static async Task Run4Json()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("value1", ".NET");
            parameters.Add("value2", 5);

            var content = new StringContent(JsonSerializer.Serialize(parameters), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{apiUrl}/params4post/json", content);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine("application/json");
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(result);
        }

        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        /// <returns></returns>
        public static async Task Run4XWFU()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("value1", ".NET");
            parameters.Add("value2", "5");

            var content = new FormUrlEncodedContent(parameters);

            var response = await httpClient.PostAsync($"{apiUrl}/params4post/xwfu", content);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine("application/x-www-form-urlencoded");
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(result);
        }

        /// <summary>
        /// multipart/form-data
        /// </summary>
        /// <returns></returns>
        public static async Task Run4MFD()
        {
            var bytes = await File.ReadAllBytesAsync("fcdb97a845e8b47ee51c39dd2bf2a6ce.jpg");
            var content = new MultipartFormDataContent();
            content.Add(new StringContent("test"), "value2");
            content.Add(new ByteArrayContent(bytes), "value1", "fcdb97a845e8b47ee51c39dd2bf2a6ce.jpg");

            var response = await httpClient.PostAsync($"{apiUrl}/params4post/mfd", content);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine("multipart/form-data");
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(result);
        }
    }
}
