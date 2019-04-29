using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.TPL.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region hello world
            //Console.WriteLine("==hello world  start==");
            //HelloWorld helloWorld = new HelloWorld();
            //helloWorld.Run(50);
            //Console.WriteLine("==hello world end=="); 
            #endregion

            #region TAP
            Console.WriteLine($"**********[{nameof(TAP)}] [START]**********");
            TAP tap = new TAP();
            Stopwatch stopwatch = new Stopwatch();

            // 1.hello,world
            Console.WriteLine($"    =={nameof(TAP.HelloWorld)} start==    ");
            stopwatch.Start();
            tap.HelloWorld();
            Console.WriteLine($"elapsed time:{stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"    =={nameof(TAP.HelloWorld)} end==    ");

            // 2.
            stopwatch.Reset();

            Console.WriteLine($"**********[{nameof(TAP)}] [END]**********");
            #endregion


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
