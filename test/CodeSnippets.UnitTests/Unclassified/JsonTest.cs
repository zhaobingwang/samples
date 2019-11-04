using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
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
            var json = JsonOperator.ToJson<JsonSampleModel>(model);
            Assert.NotNull(json);
        }

        [Fact(DisplayName = "反序列化为Model-成功")]
        public void DeserializeShouldSuccess()
        {
            string json = "{\"ID\":1,\"Name\":\"\u5F20\u4E09\",\"RegTime\":\"2019-11-01T10:54:05.8940775+08:00\",\"IsOnline\":true,\"Status\":1,\"TagId\":null}";
            var model = JsonOperator.ToObject<JsonSampleModel>(json);
            Assert.NotNull(model);
            Assert.True(model.ID == 0);
            Assert.Null(model.TagId);
        }

        [Fact(DisplayName = "Json文件转JsonDocument")]
        public void ParseShouldSuccess()
        {
            using (var stream = File.OpenRead("Files/Sample.json"))
            using (var result = JsonOperator.Parse(stream))
            {
                var root = result.RootElement;
                Assert.NotNull(result);
                Assert.True(root.GetProperty("menu").GetProperty("id").GetString() == "file");
            }
        }
    }

    public class JsonSampleModel
    {
        [JsonIgnore]
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTimeOffset RegTime { get; set; }
        public bool IsOnline { get; set; }
        public JsonSampleStatus Status { get; set; }
        public long? TagId { get; set; }
    }
    public enum JsonSampleStatus
    {
        Activated = 1,
        NonActivated = 2
    }
}
