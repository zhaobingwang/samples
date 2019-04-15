using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    public class Log
    {
        public string Id { get; set; }
        public string Application { get; set; }
        public string Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
        public string Url { get; set; }
        public string Action { get; set; }
    }
}
