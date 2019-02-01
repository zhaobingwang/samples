using Sample.Data.Access.Dapper;
using Sample.Data.Entities;
using System;
using System.Diagnostics;

namespace Sample.Fragment.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersOp usersOp = new UsersOp();
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("start");
            sw.Start();
            usersOp.BulkToMySql(100 * 1000);
            sw.Stop();
            Console.WriteLine($"耗时：{sw.ElapsedMilliseconds} ms");
            Console.WriteLine("end");
        }
    }
}
