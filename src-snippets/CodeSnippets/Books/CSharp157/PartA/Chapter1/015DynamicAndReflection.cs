using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _015DynamicAndReflection
    {
        public static void Run()
        {
            DynamicSample dynamicSample = new DynamicSample();
            var addMethod = typeof(DynamicSample).GetMethod("Add");
            int result = (int)addMethod.Invoke(dynamicSample, new object[] { 1, 2 });
            Console.WriteLine(result);  // 3

            dynamic dynamicSample2 = new DynamicSample();
            Console.WriteLine(dynamicSample2.Add(1, 2));
            Console.WriteLine(dynamicSample2.Add2(1, 2));   // 'CodeSnippets.Books.CSharp157.DynamicSample' does not contain a definition for 'Add2'
        }
    }
    public class DynamicSample
    {
        public string Name { get; set; }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
