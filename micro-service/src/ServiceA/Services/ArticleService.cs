using Consul;
using DnsClient;
using Microsoft.Extensions.Options;
using ServiceA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceA.Services
{
    public class ArticleService : IArticleService
    {
        private HttpClient _httpClient;
        private string _articleService;
        public ArticleService(HttpClient httpClient, IOptions<ServiceDisvoveryOptions> serviceDisvoveryOptions, IDnsQuery dnsQuery)
        {
            _httpClient = httpClient;

            // FIX:Host is NULL
            //var address = dnsQuery.ResolveService("service.consul", serviceDisvoveryOptions.Value.ServiceBName);
            //var addressList = address.First().AddressList;
            //var host = addressList.Any() ? addressList.First().ToString() : address.First().HostName;
            //var port = address.First().Port;
            //_articleService = $"http://{host}:{port}";

            using (var consulClient = new ConsulClient(a => a.Address = new Uri(serviceDisvoveryOptions.Value.Consul.HttpEndpoint)))
            {
                var services = consulClient.Catalog.Service(serviceDisvoveryOptions.Value.ServiceBName).Result.Response;
                if (services != null && services.Any())
                {
                    // XXX: 取第一个，生产环境可选择负载均衡处理
                    var catalogService = services.ElementAt(0);
                    _articleService = $"http://{catalogService.ServiceAddress}:{catalogService.ServicePort}";
                }
            }
        }
        public async Task<List<Article>> GetArticles(int userId)
        {
            var response = await _httpClient.GetStringAsync($"{_articleService}/article/author/get-all?userId={userId}");
            return JsonSerializer.Deserialize<List<Article>>(response);
        }
    }
}
