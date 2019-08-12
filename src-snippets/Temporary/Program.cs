using CodeSnippets;
using CodeSnippets.Books.CSharp157;
using CodeSnippets.Issues;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Temporary
{
    class User
    {
        public int Id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Iterator.Timetable timetable = new Iterator.Timetable();
                timetable.StartDate = Convert.ToDateTime("2019-08-01");
                timetable.EndDate = DateTime.Now;

                // 从时间段中迭代日期
                // 使用循环
                for (DateTime day = timetable.StartDate; day < timetable.EndDate; day = day.AddDays(1))
                {
                    Console.WriteLine(day);
                }
                // 循环有时没有迭代直观和有表现力，在本例中，可以理解为“时间区间中的每一天”，这正是foreach使用的场景。因此上述循环如果写成迭代，代码会更美观：
                foreach (var day in timetable.DateRange)
                {
                    Console.WriteLine(day);
                }

                var json = JsonConvert.SerializeObject(timetable);
                Console.WriteLine(json);

                foreach (var line in Iterator.ReadLines("Files/TextFile.txt"))
                {
                    Console.WriteLine(line);
                }

                List<User> users = new List<User>() {
                    new User{ Id=1},
                    new User{ Id=2}
                };
                foreach (var user in users)
                {
                    //users.Add(new User { Id = 10 });
                    Console.WriteLine(user.Id);
                }

                string[] strList = new string[] { "第一个节点数据", "第二个节点数据", "第三个节点数据" };
                MyIEnumerable myIEnumerable = new MyIEnumerable(strList);
                // 1.获取IEnumerator接口实例
                var enumerator = myIEnumerable.GetEnumerator();

                // 2.判断是否可以继续循环
                while (enumerator.MoveNext())
                {
                    // 3.取值
                    Console.WriteLine(enumerator.Current);
                }
                Console.WriteLine("==========");
                foreach (var item in myIEnumerable) // 效果等同于上述方式
                {
                    Console.WriteLine(item);
                }
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
