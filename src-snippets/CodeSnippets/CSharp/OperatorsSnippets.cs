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
    }
}
