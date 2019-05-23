using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sample.DotNet.Csharp
{
    /// <summary>
    /// 表达式树：https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/expression-trees/
    /// </summary>
    public class ExpressionExample
    {
        public void CreatingExpressionTreesFromLambdaExpressions()
        {
            Expression<Func<int, bool>> lambda = num => num < 5;
            Console.WriteLine(lambda.Compile()(3)); // output:True
        }

        public void CreatingExpressionTreesByUsingTheAPI()
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);
            Expression<Func<int, bool>> lambda = Expression.Lambda<Func<int, bool>>(numLessThanFive, new ParameterExpression[] { numParam });

            Console.WriteLine(lambda.Compile()(6)); //output:False
        }
    }
}
