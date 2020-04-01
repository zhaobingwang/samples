using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Core
{
    public interface IKnownException
    {
        string Message { get; }
        int ErrorCode { get; }
        object[] ErrorData { get; }
    }
}
