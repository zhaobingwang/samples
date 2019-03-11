using Sample.Data.Access.Dapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Transactions;

namespace Sample.Fragment.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserOperator userOperator = new UserOperator();
                UserTagOperator userTagOperator = new UserTagOperator();
                using (var scope = new TransactionScope())
                {
                    //var result1 = userTagOperator.Insert(new Data.Entities.UserTag { Name = "friends", FromUserId = 7, TargetUserId = 8 });
                    //var result2 = userTagOperator.Insert(new Data.Entities.UserTag { Name = "game", FromUserId = 7, TargetUserId = 8 });
                    //scope.Complete();

                    //var result1 = userTagOperator.Insert(new Data.Entities.UserTag { Name = "test1", FriendId = 7, UserId = 8 });
                    //var result2 = userTagOperator.Insert(new Data.Entities.UserTag { Name = "test2", FriendId = 7, UserId = 8 });
                    var userTag1 = new Data.Entities.UserTag { Name = "000", UserId = 7, FriendId = 8 };
                    var userTag2 = new Data.Entities.UserTag { Name = "111", UserId = 7, FriendId = 8 };
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    var result1 = userTagOperator.Insert(userTag1);
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    var result2 = userTagOperator.InsertByContrib(userTag1);
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    sw.Stop();
                    //scope.Complete();
                    Console.WriteLine(result1);
                    Console.WriteLine(result2);
                    //Console.WriteLine(result2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常：{ex.Message}");
            }
        }
    }
    class Test
    {
        [StringLength(4, ErrorMessage = "max length 4")]
        public string name { get; set; }
    }
}
