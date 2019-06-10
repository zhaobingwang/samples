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
    }

    public class Todo
    {
        public int id { get; set; }
    }
}
