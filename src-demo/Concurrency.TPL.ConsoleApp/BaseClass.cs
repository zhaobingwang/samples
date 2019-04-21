using System;
using System.Collections.Generic;
using System.Text;
using Demo.ClassLibrary;

namespace Concurrency.TPL.ConsoleApp
{
    public class BaseClass
    {
        public int Count { get; set; } = 10;
        public List<ExampleClass> FakeExampleClassList { get; set; }
        public BaseClass()
        {
            FakeExampleClassList = FakeData.GetExampleData(Count);
        }
    }
}
