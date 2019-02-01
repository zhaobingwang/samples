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
            int count = 100 * 1000;
            UsersOp usersOp = new UsersOp();
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("start");
            sw.Start();
            usersOp.BulkToMySql(count);
            sw.Stop();
            Console.WriteLine($"本次共插入{count}条数据，耗时：{sw.ElapsedMilliseconds} ms");
            Console.WriteLine("end");
        }
    }
}
