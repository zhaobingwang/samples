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

namespace Temporary
{
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
