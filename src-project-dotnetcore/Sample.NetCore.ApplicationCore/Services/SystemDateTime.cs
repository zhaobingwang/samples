using Sample.NetCore.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.ApplicationCore.Services
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
