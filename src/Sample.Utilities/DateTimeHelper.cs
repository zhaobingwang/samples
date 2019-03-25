using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Utilities
{
    /// <summary>
    /// 日期时间处理帮助类
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="dateTime">待转换的时间</param>
        /// <param name="ms">返回时间戳的单位，1：毫秒级时间戳，1000：秒级时间戳</param>
        /// <returns>Unix时间戳</returns>
        public static long GetUnixTimestamp(DateTime? dateTime = null, int ms = 1)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff;
            if (dateTime == null)
                diff = DateTime.Now.ToUniversalTime() - origin;
            else
                diff = dateTime.Value.ToUniversalTime() - origin;
            return (long)diff.TotalMilliseconds / ms;
        }

        /// <summary>
        /// 获取UTC时间
        /// </summary>
        /// <param name="timestamp">Unix时间戳</param>
        /// <returns>UTC时间</returns>
        public static DateTime GetDateTime(long timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddMilliseconds(timestamp);
        }
    }
}
