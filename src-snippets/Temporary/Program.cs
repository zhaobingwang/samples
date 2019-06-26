using CodeSnippets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Temporary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            for (int i = 0; i < 1000; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    //Console.WriteLine($"loop{i}");
                    Singleton a = Singleton.GetInstance();
                    Singleton b = Singleton.GetInstance();
                    if (a.Equals(b))
                    {
                        //Console.WriteLine("same");
                    }
                    else
                    {
                        Console.WriteLine("diff");
                    }
                });
            }

            Thread.Sleep(5000);
            Console.WriteLine("end");
        }
    }
}
