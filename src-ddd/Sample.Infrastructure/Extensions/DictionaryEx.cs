using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Infrastructure.Extensions
{
    public static class DictionaryEx
    {
        /// <summary>
        /// 转为StackExchange.Redis的HashEntry[]
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static HashEntry[] ToHashEntry(this Dictionary<string, string> dict)
        {
            var fields = dict.Select(
                pair => new HashEntry(pair.Key, pair.Value)).ToArray();
            
            return fields;
        }
    }
}
