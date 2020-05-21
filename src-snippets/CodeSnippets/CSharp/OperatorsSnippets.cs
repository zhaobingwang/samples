using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.CSharp
{
    /// <summary>
    /// C#运算符和表达式代码片段
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/
    /// </summary>
    public static class OperatorsSnippets
    {
        #region Boolean logical operators 

        // logical exclusive OR operators（逻辑异或运算符）
        public static void BooleanLogicalOperators()
        {
            Console.WriteLine(true ^ true);    // output: False
            Console.WriteLine(true ^ false);   // output: True
            Console.WriteLine(false ^ true);   // output: True
            Console.WriteLine(false ^ false);  // output: False
        }
        #endregion

        #region bitwise and shift operators
        public static void LeftShiftOperator()
        {
            Console.WriteLine(3 << 0);  // 3
            Console.WriteLine(3 << 1);  // 6
            Console.WriteLine(3 << 2);  // 12
            Console.WriteLine(3 << 3);  // 24
            Console.WriteLine(3 << 4);  // 48
        }

        public static void RightShiftOperator()
        {
            Console.WriteLine(16 >> 0); // 16
            Console.WriteLine(16 >> 1); // 8
            Console.WriteLine(16 >> 2); // 4
            Console.WriteLine(16 >> 3); // 2
            Console.WriteLine(16 >> 4); // 1
            Console.WriteLine(16 >> 5); // 0
        }
        #endregion
    }
}
