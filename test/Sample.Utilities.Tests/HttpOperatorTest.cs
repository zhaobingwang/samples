using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sample.Share.Constants;
using System.Threading.Tasks;

namespace Sample.Utilities.Tests
{
    [Trait("工具类", "Http")]
    public class HttpOperatorTest
    {
        HttpOperator httpOperator;
        string requestUrl;
        public HttpOperatorTest()
        {
            httpOperator = new HttpOperator();
            requestUrl = $"{APIAddress.FAKE_URL}{APIAddress.FAKE_COMMON_RESOURCE_USERS}";
        }
        [Fact(DisplayName = "PostAsync")]
        public async Task PostAsync_WithExpectedParameters()
        {
            // arrange
            var requestParams = "";
            // act
            var result = await httpOperator.PostAsync<PostResult>(requestUrl, requestParams);

            // assert
            Assert.NotNull(result);
            Assert.True(result.id > 0);
        }

        [Fact(DisplayName = "GetAsync")]
        public async Task GetAsync_WithExpectedParameters()
        {
            // arrange
            var requestParams = new { id = 1 };

            // act
            var result = await httpOperator.GetAsync<List<Users>>(requestUrl, requestParams);

            // assert
            Assert.NotNull(result);
            Assert.True(result.Count == 1);
        }

        [Fact(DisplayName = "GetAsync错误请求")]
        public async Task GetAsync_WithUnExpectedParameters()
        {
            // arrange
            var requestParams = new { id = 1 };
            requestUrl += "test";

            // act
            var result = await httpOperator.GetAsync<List<Users>>(requestUrl, requestParams);

            // assert
            Assert.True(result.Count == 0);
        }
    }

    public class PostResult
    {
        public int id { get; set; }
    }

    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }
    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }
    public class Geo
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }
}
