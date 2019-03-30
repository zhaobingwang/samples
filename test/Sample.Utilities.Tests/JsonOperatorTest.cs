using System;
using System.Collections.Generic;
using System.Text;
using Sample.Utilities;
using Xunit;

namespace Sample.Utilities.Tests
{
    [Trait("工具类", "Json")]
    public class JsonOperatorTest
    {
        [Fact(DisplayName = "对象转json[正常入参]")]
        public void ToJson_WithExpectedParameters()
        {
            // arrange
            string fakeUserJson = "{\"Id\":1,\"Name\":\"Jack\",\"RegTime\":\"2019 - 03 - 20T16: 30:50\",\"IsDelete\":false}";

            // act
            var result = JsonOperator.ToObject<User>(fakeUserJson);

            // assert
            Assert.NotNull(result);
            Assert.True(result.Id == 1);
        }

        [Fact(DisplayName = "json转对象[正常入参]")]
        public void ToObject_WithExpectedParameters()
        {
            // arrange
            var fakeUser = GetFakeUser();

            // act
            var result = JsonOperator.ToJson<User>(fakeUser);

            // assert
            Assert.NotNull(result);
        }
        private User GetFakeUser()
        {
            return new User
            {
                Id = 1,
                Name = "Jack",
                RegTime = new DateTime(2019, 3, 20, 16, 30, 50),
                IsDelete = false
            };
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
