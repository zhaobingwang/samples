using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodeSnippets.Issues
{
    public class Model2Dict
    {
        public static void Run()
        {
            Model2DictSampleModel model = new Model2DictSampleModel
            {
                A = 1,
                B = "2"
            };
            var dict = model.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(model, null));
            var aa = 1;
        }
    }
    public class Model2DictSampleModel
    {
        public int A { get; set; }
        public string B { get; set; }
    }
}
