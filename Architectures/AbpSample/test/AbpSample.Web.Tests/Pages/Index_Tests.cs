using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpSample.Pages
{
    public class Index_Tests : AbpSampleWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
