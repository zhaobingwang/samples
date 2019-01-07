using Sample.Data.Access.Dapper;
using Sample.Data.Entities;
using System;

namespace Sample.Fragment.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersOp usersOp = new UsersOp();
            var result = usersOp.AddUser(new User
            {
                NickName = "张三",
                Email = "zhangsan@qq.com",
                IsDelete = false,
                RegTime = DateTime.Now,
                ModifyTime = DateTime.Now,
                Remark = "这是一个测试用户"
            });
            Console.WriteLine(result);
            Console.WriteLine("end.");
        }
    }
}
