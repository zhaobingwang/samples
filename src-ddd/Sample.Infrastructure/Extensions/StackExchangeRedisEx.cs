using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Extensions
{
    public static class StackExchangeRedisEx
    {
        //static readonly string[] strArray = new string[0];  // ToStringArray()使用
        //static readonly RedisValue[] rvArray = new RedisValue[0];   // ToRedisValueArray()使用

        ///// <summary>
        ///// 转为字符串数组
        ///// </summary>
        ///// <param name="values"></param>
        ///// <returns></returns>
        //public static string[] ToStringArray(this RedisValue[] values)
        //{
        //    if (values == null)
        //        return null;
        //    if (values.Length == 0)
        //        return strArray;
        //    return Array.ConvertAll(values, x => (string)x);
        //}

        ///// <summary>
        ///// 转为RedisValue数组
        ///// </summary>
        ///// <param name="values"></param>
        ///// <returns></returns>
        //public static RedisValue[] ToRedisValueArray(this string[] values)
        //{
        //    if (values == null)
        //        return null;
        //    if (values.Length == 0)
        //        return rvArray;
        //    return Array.ConvertAll(values, x => (RedisValue)x);
        //}
    }
}
