using System;
using System.Net.Http;
using System.Text;
using Sample.Utilities;

namespace Sample.Business.Infrastructure
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : base(JsonOperator.ToJson(obj), Encoding.UTF8, "application/json")
        {

        }
    }
}
