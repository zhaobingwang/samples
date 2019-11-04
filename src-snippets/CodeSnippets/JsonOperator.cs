using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeSnippets
{
    /// <summary>
    /// Json操作类
    /// </summary>
    public static class JsonOperator
    {
        /// <summary>
        /// 将流作为代表单个JSON值的UTF-8编码数据解析为JsonDocument
        /// </summary>
        /// <param name="utf8Json">要解析的JSON数据</param>
        /// <param name="options">解析期间控制读取器行为的选项</param>
        /// <returns></returns>
        public static JsonDocument Parse(Stream utf8Json, JsonDocumentOptions options = default)
        {
            return JsonDocument.Parse(utf8Json, options);
        }

        /// <summary>
        /// 将流作为代表单个JSON值的UTF-8编码数据解析为JsonDocument
        /// </summary>
        /// <param name="utf8Json">要解析的JSON数据</param>
        /// <param name="options">解析期间控制读取器行为的选项</param>
        /// <param name="cancellationToken">用于监视取消请求的令牌</param>
        /// <returns></returns>
        public static Task<JsonDocument> ParseAsync(Stream utf8Json, JsonDocumentOptions options = default, System.Threading.CancellationToken cancellationToken = default)
        {
            return JsonDocument.ParseAsync(utf8Json, options, cancellationToken);
        }

        /// <summary>
        /// 将对象转换Json字符串
        /// </summary>
        /// <typeparam name="TValue">对象类型</typeparam>
        /// <param name="value">对象值</param>
        /// <param name="options">解析期间控制读取器行为的选项</param>
        /// <returns></returns>
        public static string ToJson<TValue>(TValue value, JsonSerializerOptions options = default)
        {
            return JsonSerializer.Serialize(value, options);
        }

        /// <summary>
        /// 将Json转为对象
        /// </summary>
        /// <typeparam name="TValue">对象类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <param name="options">解析期间控制读取器行为的选项</param>
        /// <returns></returns>
        public static TValue ToObject<TValue>(string json, JsonSerializerOptions options = default)
        {
            return JsonSerializer.Deserialize<TValue>(json, options);
        }
    }
}