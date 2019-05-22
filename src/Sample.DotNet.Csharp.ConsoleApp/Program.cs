using System;
using System.Diagnostics;

namespace Sample.DotNet.Csharp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LambdaExample example = new LambdaExample();

            //example.HelloWorld();
            //example.Closure();
            //example.PrintNumber();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ExcuteFunction excuteFunction = new ExcuteFunction();
            var func1 = excuteFunction.Excute(1);
            Console.WriteLine(func1("hi"));

            //excuteFunction = new ExcuteFunction();
            var func2 = excuteFunction.Excute(2);
            Console.WriteLine(func2("hi"));

            var func3 = excuteFunction.Excute(3);
            Console.WriteLine(func3("hi"));
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
