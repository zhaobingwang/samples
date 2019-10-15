using System;
using System.Collections.Generic;
using System.Text;
using CodeSnippets.DesignPatterns.ProxyPattern;
using Xunit;

namespace CodeSnippets.UnitTests.DesignPatterns
{
    [Trait("设计模式", "代理模式测试")]
    public class ProxyPatternTest
    {
        [Fact(DisplayName = "静态代理-成功")]
        public void StaticProxyShouldSuccess()
        {
            const string HI = "hi";
            ISubject subject = new SubjectProxy();
            var result = subject.SayHi(HI);
            Assert.True(result == HI);
        }
    }
}