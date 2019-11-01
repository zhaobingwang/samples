using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeSnippets.UnitTests.Unclassified
{
    [Trait("未分类", "Json")]
    public class JsonTest
    {
        [Fact(DisplayName = "序列化为Json-成功")]
        public void SerializeShouldSuccess()
        {
            JsonSampleModel model = new JsonSampleModel { ID = 1, Name = "张三", RegTime = DateTimeOffset.Now, IsOnline = true, Status = JsonSampleStatus.Activated, TagId = null };
            var json = JsonOperator<JsonSampleModel>.ToJson(model);
            Assert.NotNull(json);
        }

        [Fact(DisplayName = "反序列化为Model-成功")]
        public void DeserializeShouldSuccess()
        {
            string json = "{\"ID\":1,\"Name\":\"\u5F20\u4E09\",\"RegTime\":\"2019-11-01T10:54:05.8940775+08:00\",\"IsOnline\":true,\"Status\":1,\"TagId\":null}";
            var model = JsonOperator<JsonSampleModel>.ToObject(json);
            Assert.NotNull(model);
            Assert.True(model.ID == 0);
            Assert.Null(model.TagId);
        }
    }
}
