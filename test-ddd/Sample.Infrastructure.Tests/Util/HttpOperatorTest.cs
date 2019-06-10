using Newtonsoft.Json;
using Sample.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sample.Infrastructure.Tests.Util
{
    [Trait("Utilities", "HTTP")]
    public class HttpOperatorTest
    {
        HttpOperator httpOperator = null;
        public HttpOperatorTest()
        {

        }

        [Fact(DisplayName = nameof(RESTGetShouldSuccess))]
        public void RESTGetShouldSuccess()
        {
            // arrange
            string url = $"{Constants.FAKE_URL}{Constants.FAKE_COMMON_RESOURCE_TODOS}/1";
            httpOperator = new HttpOperator(url);

            // act
            var result = httpOperator.RESTGet();

            // assert
            Assert.NotNull(result);
        }
        [Fact(DisplayName = nameof(RESTGetTShouldSuccess))]
        public void RESTGetTShouldSuccess()
        {
            // arrange
            string url = $"{Constants.FAKE_URL}{Constants.FAKE_COMMON_RESOURCE_TODOS}/1";
            httpOperator = new HttpOperator(url);

            // act;
            var result = httpOperator.RESTGet<Todo>();

            // assert
            Assert.NotNull(result);
            Assert.True(result.id == 1);
        }
    }

    public class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
