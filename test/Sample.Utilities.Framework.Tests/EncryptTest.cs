using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Utilities.Framework;
using Xunit;

namespace Sample.Utilities.Framework.Tests
{
    [Trait(".NET Framework Util", "加密方法")]
    public class EncryptTest
    {
        [Fact(DisplayName = "MD5加密正常情况测试")]
        public void MD5Encrypt_WithExpectedParameters()
        {
            // arrange
            string input = "test";
            // act
            var result = Encrypter.MD5Encrypt(input, Encoding.UTF8);
            // assert
            Assert.NotNull(result);
        }
        [Fact(DisplayName = "MD5加密异常情况测试")]
        public void MD5Encrypt_WithUnExpecterParameters()
        {
            // arrange
            string input = null;

            // act
            var result = Encrypter.MD5Encrypt(input, Encoding.UTF8);

            // assert
            Assert.Null(result);
        }
    }
}
