using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.Infrastructure
{
    public class Temporary
    {
        IConfiguration Configuration { get; }
        public Temporary(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string GetConfigValue(string key)
        {
            return Configuration.GetValue<string>(key);
        }
    }
}
