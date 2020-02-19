using CodeSnippets.RSS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeSnippets.IntegrationTests.RSS
{
    public class CNBlogsTest
    {
        [Fact]
        public async Task GetTenDaysTopDiggPostsShouldSuccess()
        {
            var result = await CNBlogs.GetTenDaysTopDiggPostsAsync();
            Assert.NotNull(result);
            Assert.True(result.Entry.Count == 5);
        }
    }
}
