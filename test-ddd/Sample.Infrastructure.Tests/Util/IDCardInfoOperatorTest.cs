using Sample.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sample.Infrastructure.Tests.Util
{
    [Trait("工具类", "身份证信息获取")]
    public class IDCardInfoOperatorTest
    {
        [Fact(DisplayName = "获取身份证地址码")]
        public void GetAddressCode_WithExpectedParameters()
        {
            // arrange
            var id = "330106200001018752";

            // act
            var result = IDCardInfoOperator.GetAddressCode(id);

            // assert
            Assert.True(result == "330106");
        }
    }
}
