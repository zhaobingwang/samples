using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeSnippets.CSharp.LINQ
{
    public static class LINQSnippets
    {
        public static void Run()
        {
            // Specify the data source.
            int[] scores = new int[] { 81, 65, 50, 92 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 60
                select score;

            // Execute the query.
            foreach (var item in scoreQuery)
            {
                Console.WriteLine(item + " ");
            }
        }

        public static void IntroToLINQ()
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (var num in numQuery)
            {
                Console.WriteLine("{0,1}", num);
            }
        }
    }
}
