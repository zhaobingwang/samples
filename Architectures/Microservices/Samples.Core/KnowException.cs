using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Core
{
    public class KnowException : IKnownException
    {
        public string Message { get; private set; }

        public int ErrorCode { get; private set; }

        public object[] ErrorData { get; private set; }

        private readonly static IKnownException Unknown = new KnowException { Message = "未知错误", ErrorCode = 9999 };

        public static IKnownException FromKnownException(IKnownException exception)
        {
            return new KnowException { Message = exception.Message, ErrorCode = exception.ErrorCode, ErrorData = exception.ErrorData };
        }
    }
}
