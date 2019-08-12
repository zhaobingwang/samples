using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sample.DotNet.CSharp.Concepts
{
    [Author("Live100", version = 1.1)]
    [Author("Route8", version = 1.1)]
    public class AttributesSample
    {
        [Conditional("DEBUG")]
        public void ConditionalDebugMethod()
        {
            Console.WriteLine("DEBUG的时候显示该信息。");
        }
        [Conditional("RELEASE")]
        public void ConditionalReleaseMethod()
        {
            Console.WriteLine("RELEASE的时候显示该信息。");
        }
        [Conditional("自定义")]
        public void ConditionalCustomMethod()
        {
            Console.WriteLine("自定义的时候显示该信息。");
        }
    }

    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)] // Multiuse attribute. 
    public class Author : Attribute
    {
        private string name;
        public double version;

        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }
        public string GetName()
        {
            return name;
        }
    }
}
