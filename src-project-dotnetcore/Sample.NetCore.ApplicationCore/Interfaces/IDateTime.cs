using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.ApplicationCore.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}