using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.TPL.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // hello world
            Console.WriteLine("==hello world  start==");
            HelloWorld helloWorld = new HelloWorld();
            helloWorld.Run(50);
            Console.WriteLine("==hello world end==");


            Console.Read();
            //long totalSize = 0;
            //if (args.Length == 1)
            //{
            //    Console.WriteLine("There are no command line arguments.");
            //    return;
            //}
            //if (!Directory.Exists(args[1]))
            //{
            //    Console.WriteLine($"The directory({args[1]}) does not exist.");
            //    return;
            //}
            //string[] files = Directory.GetFiles(args[1]);
            //Parallel.For(0, files.Length, index =>
            //{
            //    FileInfo fi = new FileInfo(files[index]);
            //    long size = fi.Length;
            //    Interlocked.Add(ref totalSize, size);
            //});
            //Console.WriteLine($"Directory '{args[1]}'");
            //Console.WriteLine($"{files.Length.ToString("N0")} files,{totalSize.ToString("N0")} bytes");
        }
    }
}
