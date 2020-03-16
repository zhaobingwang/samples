using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ClassLibrary
{
    public static class FakeData
    {
        public static List<ExampleClass> GetExampleData(int count)
        {
            List<ExampleClass> list = new List<ExampleClass>();
            for (int i = 1; i <= count; i++)
            {
                list.Add(new ExampleClass
                {
                    Id = i,
                    Name = $"test{i}"
                });
            }
            return list;
        }
    }
}
