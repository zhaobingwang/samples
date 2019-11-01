using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeSnippets
{
    public class JsonOperator<T> where T : class
    {
        public static string ToJson(T model)
        {
            return JsonSerializer.Serialize(model);
        }
        public static T ToObject(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
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