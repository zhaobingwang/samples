using System;
using System.Collections.Generic;
using System.Text;
using Demo.ClassLibrary;

namespace Concurrency.TPL.ConsoleApp
{
    public class BaseClass
    {
        public List<ExampleClass> GetFakeExampleClassList(int count)
        {
            return FakeData.GetExampleData(count);
        }
    }
}
