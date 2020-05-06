using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearchDemo
{
    public class Log
    {
        public string Exception { get; set; }
        public string Message { get; set; }
        public DateTimeOffset LogDate { get; set; } = DateTime.UtcNow;
    }
}
