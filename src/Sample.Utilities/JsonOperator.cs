using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sample.Utilities
{
    /// <summary>
    /// json操作类
    /// </summary>
    public class JsonOperator
    {
        /// <summary>
        /// 将对象序列化位json字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">待序列化的对象</param>
        /// <returns>json字符串</returns>
        public static string ToJson<T>(T t) where T : class, new()
        {
            return JsonConvert.SerializeObject(t);
        }

        /// <summary>
        /// 将json字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>对象</returns>
        public static T ToObject<T>(string json) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
