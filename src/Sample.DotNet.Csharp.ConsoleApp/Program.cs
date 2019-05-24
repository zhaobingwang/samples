using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sample.DotNet.CSharp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LambdaExample example = new LambdaExample();

            //example.HelloWorld();
            //example.Closure();
            //example.PrintNumber();

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //ExcuteFunction excuteFunction = new ExcuteFunction();
            //var func1 = excuteFunction.Excute(1);
            //Console.WriteLine(func1("hi"));

            ////excuteFunction = new ExcuteFunction();
            //var func2 = excuteFunction.Excute(2);
            //Console.WriteLine(func2("hi"));

            //var func3 = excuteFunction.Excute(3);
            //Console.WriteLine(func3("hi"));
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //Console.ReadLine();

            ExpressionExample expressionExample = new ExpressionExample();
            expressionExample.CreatingExpressionTreesFromLambdaExpressions();
            expressionExample.CreatingExpressionTreesByUsingTheAPI();

            var users = GetUsers();
            UserSpecification spec = new UserSpecification("用户1");
            var result = SpecificationEvaluator<User>.GetQuery(users.AsQueryable(), spec).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}");
            }
        }

        private static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            for (int i = 1; i <= 10; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = $"用户{i % 3}"
                });
            }
            return users;
        }
    }
}
