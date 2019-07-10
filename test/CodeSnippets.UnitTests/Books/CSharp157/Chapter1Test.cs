using CodeSnippets.Books.CSharp157;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeSnippets.UnitTests.Books.CSharp157
{
    [Trait("改善CSharp程序的157个建议", "第一章")]
    public class Chapter1Test
    {
        [Fact(DisplayName = "使用默认的转型方法")]
        public void UseDefaultrConvertTest()
        {
            string ip = "127.0.0.1";
            var result = _02UseDefaultrConvert.IpConvert(ip);
            Assert.True(result == ip);
        }
    }
}
