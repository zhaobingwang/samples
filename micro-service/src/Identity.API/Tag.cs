using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API
{
    public class Tag
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string value { get; set; }
    }
}
