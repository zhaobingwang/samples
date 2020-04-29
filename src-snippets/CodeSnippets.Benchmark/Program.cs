using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;

namespace CodeSnippets.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<StringOperatorBenchmarkTest>();
            //StringOperator op = new StringOperator();
            //var aa = op.Foamat();
            //Console.WriteLine(aa);
            Console.ReadLine();
        }
    }
}
