using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodeSnippets.CSharp.ExpressionTrees
{
    public partial class ExpressionSnippets
    {
        public static void Run()
        {
            LoopExpression loop = Expression.Loop(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                    Expression.Constant("Hello"))
            );
            BlockExpression block = Expression.Block(loop);
            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            lambdaExpression.Compile().Invoke();
        }
    }
}
