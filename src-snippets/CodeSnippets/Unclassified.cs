using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets
{
    public class Unclassified
    {
        /// <summary>
        /// 范围和索引
        /// </summary>
        public static void RangesAndIndices()
        {
            // 索引
            Index i1 = 2;
            Index i2 = ^3;
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine($"{a[i1]},{a[i2]}");  // Output: 3,7

            // 范围 Output: 3,4,5,6,
            var slice = a[i1..i2];
            foreach (var item in slice)
            {
                Console.Write($"{item},");
            }
        }
    }
}
