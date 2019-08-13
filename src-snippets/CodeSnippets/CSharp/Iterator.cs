using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CodeSnippets.CSharp
{
    /// <summary>
    /// 迭代器
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/iterators
    /// https://www.cnblogs.com/zhaopei/p/5769782.html
    /// https://www.cnblogs.com/yangecnu/archive/2012/03/17/2402432.html
    /// </summary>
    public class Iterator
    {
        public static void Run()
        {
            Console.WriteLine("***** GetSingleDigitNumbers() 展示基本语法 *****");
            foreach (var item in GetSingleDigitNumbers())
            {
                Console.Write(item);
            }
            Console.WriteLine("\n***** GetSingleDigitNumbers2() 展示基本语法 *****");
            foreach (var item in GetSingleDigitNumbers2())
            {
                Console.Write(item);
            }
            Console.WriteLine("\n***** GetSingleDigitNumbers3() 展示基本语法 *****");
            foreach (var item in GetSingleDigitNumbers3())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("***** 实现自定义枚举器 *****");
            RunMyIEnumerable();
            Console.WriteLine("***** 读取文本文件中的每一行 *****");
            PrintTextLine();
            Console.WriteLine("***** 打印时间区间中的每一天 *****");
            PrintFromTimeTable();
        }

        #region 用GetSingleDigitNumbers来展示基本语法
        private static IEnumerable<int> GetSingleDigitNumbers()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }
        private static IEnumerable<int> GetSingleDigitNumbers2()
        {
            int index = 0;
            while (index++ < 10)
                yield return index - 1;
        }
        private static IEnumerable<int> GetSingleDigitNumbers3()
        {
            int index = 0;
            while (index++ < 10)
                yield return index - 1;

            yield return 50;

            index = 100;
            while (index++ < 110)
                yield return index - 1;
        }
        public IEnumerable<int> GetSingleDigitNumbers4()
        {
            int index = 0;
            while (index++ < 10)
                yield return index;

            yield return 50;

            // generates a compile time error:
            var items = new int[] { 100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
            // 无法从迭代器返回值。请使用 yield return 语句返回值，或使用 yield break 语句结束迭代。
            //return items;   
            foreach (var item in items)
                yield return item;
        }
        #endregion

        #region loT正式示例
        // 迭代器方法有一个重要限制：在同一方法中不能同时使用 return 语句和 yield return 语句
        //public static IEnumerable<T> Sample(this IEnumerable<T> sourceSequence, int interval)
        //{
        //    int idnex = 0;
        //    foreach (var item in sourceSequence)
        //    {
        //        if (index++ % interval = 0)
        //        {
        //            yield return item;
        //        }
        //    }
        //}

        #endregion

        #region 实现自定义枚举器
        public static void RunMyIEnumerable()
        {
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
        #endregion

        #region 打印时间区间中的每一天
        public class Timetable
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public IEnumerable<DateTime> DateRange
            {
                get
                {
                    for (DateTime day = StartDate; day <= EndDate; day = day.AddDays(1))
                    {
                        yield return day;
                    }
                }
            }
        }
        public static void PrintFromTimeTable()
        {
            Iterator.Timetable timetable = new Iterator.Timetable();
            timetable.StartDate = Convert.ToDateTime("2019-08-01");
            timetable.EndDate = Convert.ToDateTime("2019-08-03");

            // 从时间段中迭代日期
            // 使用循环
            for (DateTime day = timetable.StartDate; day <= timetable.EndDate; day = day.AddDays(1))
            {
                Console.WriteLine(day);
            }
            // 循环有时没有迭代直观和有表现力，在本例中，可以理解为“时间区间中的每一天”，这正是foreach使用的场景。因此上述循环如果写成迭代，代码会更美观：
            foreach (var day in timetable.DateRange)
            {
                Console.WriteLine(day);
            }
        }
        #endregion

        #region 读取文本文件中的每一行
        public static void PrintTextLine()
        {
            foreach (var line in Iterator.ReadLines("Files/TextFile.txt"))
            {
                Console.WriteLine(line);
            }
        }
        private static IEnumerable<string> ReadLines(string fileName)
        {
            using (TextReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        #endregion
    }

    #region 实现自己的迭代器
    public class MyIEnumerable : IEnumerable
    {
        private string[] _strList;
        public MyIEnumerable(string[] strList)
        {
            _strList = strList;
        }
        public IEnumerator GetEnumerator()
        {
            //return new MyIEnumerator(_strList);
            for (int i = 0; i < _strList.Length; i++)
            {
                yield return _strList[i];   // 使用yield关键字，就不应return MyIEnumerator了，其在内部已经帮助我们实现了IEnumerator
            }
        }
    }
    public class MyIEnumerator : IEnumerator
    {
        private string[] _strList;
        private int position;
        public MyIEnumerator(string[] strList)
        {
            _strList = strList;
            position = -1;
        }
        public object Current
        {
            get { return _strList[position]; }
        }

        public bool MoveNext()
        {
            position++;
            if (position < _strList.Length)
                return true;
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    #endregion
}
