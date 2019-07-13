using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// https://docs.microsoft.com/zh-cn/dotnet/api/system.icomparable.compareto?view=netframework-4.8
    /// IComparable.CompareTo(Object) Method:
    /// 将当前实例与同一类型的另一个对象进行比较，并返回一个整数，该整数指示当前实例在排序顺序中的位置是位于另一个对象之前、之后还是与其位置相同。
    /// “值”	含义
    ///     小于零 此实例在排序顺序中位于 obj 之前。
    ///     零 此实例在排序顺序中的位置与 obj 相同。
    ///     大于零 此实例在排序顺序中位于 obj 之后。
    /// </summary>
    public class _010Comparer
    {
        public static int Comparer(int a, int b)
        {
            return a.CompareTo(b);
        }
        public static void CompareTemperatures()
        {
            ArrayList temperatures = new ArrayList();
            Random rnd = new Random();
            for (int ctr = 0; ctr < 10; ctr++)
            {
                int degrees = rnd.Next(0, 100);
                Temperature temperature = new Temperature();
                temperature.Celsius = degrees;
                temperatures.Add(temperature);
            }
            // Sort ArrayList
            temperatures.Sort();
            foreach (Temperature item in temperatures)
                Console.WriteLine(item.Celsius);
        }
    }

    public class Temperature : IComparable
    {
        public double Celsius { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            Temperature temperature = obj as Temperature;
            if (temperature != null)
                return Celsius.CompareTo(temperature.Celsius);
            else
                throw new ArgumentException($"Object is not a {nameof(Temperature)}");
        }
    }
}
