﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Util
{
    public class HttpOperator
    {
        public string url;
        public HttpOperator(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            this.url = url;
        }

        public string RESTGet()
        {
            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public T RESTGet<T>() where T : class, new()
        {
            var client = new RestSharp.RestClient(url);
            var request = new RestSharp.RestRequest(RestSharp.Method.GET);
            var response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        //public string RESTGet(Dictionary<string, string> keyValuePairs)
        //{
        //    if (keyValuePairs == null)
        //        throw new ArgumentNullException(nameof(keyValuePairs));
        //    var client = new RestSharp.RestClient(url);
        //    var request = new RestSharp.RestRequest(RestSharp.Method.GET);
        //    foreach (var keyValuePair in keyValuePairs)
        //    {
        //        request.AddParameter(keyValuePair.Key, keyValuePair.Value);
        //    }
        //    RestSharp.IRestResponse response = client.Execute(request);
        //    var content = response.Content;
        //    return content;
        //}

        //public async Task<string> GetAsyncByRestSharp(Dictionary<string, string> keyValuePairs)
        //{
        //    var client = new RestSharp.RestClient(url);
        //    var request = new RestSharp.RestRequest(RestSharp.Method.GET);
        //    foreach (var keyValuePair in keyValuePairs)
        //    {
        //        request.AddParameter(keyValuePair.Key, keyValuePair.Value);
        //    }
        //    var response = await client.ExecuteGetTaskAsync(request);
        //    return response.Content;
        //}
    }
}
