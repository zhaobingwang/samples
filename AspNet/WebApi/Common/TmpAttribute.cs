using System;

namespace WebApi
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TmpAttribute : Attribute
    {
        public string ActionCode { get; set; }
        public TmpAttribute()
        {

        }
    }
}
