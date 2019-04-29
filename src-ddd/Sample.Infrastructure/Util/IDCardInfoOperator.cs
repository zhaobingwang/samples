using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Util
{
    /// <summary>
    /// 身份证信息获取
    /// </summary>
    public static class IDCardInfoOperator
    {
        public static string GetAddressCode(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException($"{nameof(id)}");
            return id.Substring(0, 6);
        }
        public static string GetBirthdayCode(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException($"{nameof(id)}");
            return id.Substring(6, 8);
        }
        public static string GetAddressName(string id)
        {
            return null;
        }
    }
}
