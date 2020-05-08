using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippets.CSharp
{
    public class YieldSnippets
    {
        public static void Run()
        {
            Console.WriteLine("source data: \n");
            for (int i = 0; i < Datas.Count; i++)
            {
                Console.Write(Datas[i] + "\t");
            }
            Console.WriteLine("\nFilter data greater than 5 \n");
            var list1 = FilterGreaterThan5().ToList();
            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write(list1[i] + "\t");
            }
            Console.WriteLine("\nFilter data greater than 5 with yield \n");
            var list2 = FilterGreaterThan5WithYield().ToList();
            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write(list2[i] + "\t");
            }
        }

        private static List<int> Datas
        {
            get
            {
                return new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }
        }
        private static IEnumerable<int> FilterGreaterThan5()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < Datas.Count; i++)
            {
                if (Datas[i] > 5)
                    result.Add(Datas[i]);
            }
            return result;
        }

        public static IEnumerable<int> FilterGreaterThan5WithYield()
        {
            for (int i = 0; i < Datas.Count; i++)
            {
                if (Datas[i] > 5)
                    yield return Datas[i];
            }
        }
    }
}
