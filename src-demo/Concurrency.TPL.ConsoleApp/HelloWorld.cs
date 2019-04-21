using Demo.ClassLibrary;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.TPL.ConsoleApp
{
    public class HelloWorld : BaseClass
    {
        public void Run()
        {
            Count = 50;//10 * 1000 * 1000;
            Console.WriteLine("init start");
            var list = FakeExampleClassList;

            Console.WriteLine("start");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in list)
            {
                Process(item);
            }
            Console.WriteLine($"串行计算{Count}条数据耗时:{sw.ElapsedMilliseconds} ms");

            sw.Restart();
            Parallel.ForEach(list, item => Process(item));
            sw.Stop();
            Console.WriteLine($"并行计算{Count}条数据耗时:{sw.ElapsedMilliseconds} ms");
        }
        public static void Process(ExampleClass exampleClass)
        {
            Thread.Sleep(100);
        }
    }
}
