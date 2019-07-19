using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _019UseMoreEffectiveObjectInitialization
    {
        public static void Run()
        {
            A a = new A() { ID = 1, Name = "test" };
            List<A> list = new List<A>() { new A { ID = 1, Name = "test" } };
        }
    }
    class A
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
