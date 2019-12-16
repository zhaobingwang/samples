using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CodeSnippets.UnitTests
{
    [Trait("CodeSnippets", "正则表达式")]
    public class RegexSnippetsTest
    {
        [Theory(DisplayName = "是否匹配")]
        [InlineData("hello", @"\blo", false)]
        [InlineData("hello", @"lo\b", true)]
        [InlineData("hello", @"lo\B", false)]
        [InlineData("hello", @"\Bhe", false)]
        [InlineData("hello", @"\Bel", true)]
        [InlineData("hello", @"el\B", true)]
        public void IsMatch(string source, string pattern, bool isMatch)
        {
            var isMatchResult = RegexSnippets.IsMatch(source, pattern);
            Assert.True(isMatchResult == isMatch);
        }
    }
}
