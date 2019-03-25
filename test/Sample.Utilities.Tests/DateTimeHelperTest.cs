using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sample.Utilities.Tests
{
    [Trait("工具类", "时间操作")]
    public class DateTimeHelperTest
    {
        [Fact(DisplayName = "获取时间戳")]
        public void GetUnixTimestamp_WithExpectedParameters()
        {
            // arrange
            DateTime source = new DateTime(2019, 3, 25, 11, 15, 30);
            long expectedSecond = 1553483730;
            long expectedMilliSecond = 1553483730000;

            // act
            var resultSecond = DateTimeHelper.GetUnixTimestamp(source, 1000);
            var resultMilliSecond = DateTimeHelper.GetUnixTimestamp(source, 1);

            // assert

            Assert.True(expectedSecond == resultSecond);
            Assert.True(expectedMilliSecond == resultMilliSecond);
        }

        [Fact]
        public void GetDateTime_WithExpectedParameters()
        {
            // arrange
            long msTimestamp = 1553483730000;
            DateTime expectedDateTime = new DateTime(2019, 3, 25, 11, 15, 30).ToUniversalTime();

            // act
            var resultDateTime = DateTimeHelper.GetDateTime(msTimestamp);

            // assert
            Assert.True(expectedDateTime.CompareTo(resultDateTime) == 0);
        }
    }
}
