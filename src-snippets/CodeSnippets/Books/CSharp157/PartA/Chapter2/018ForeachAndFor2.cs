using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// foreach不能替代for
    /// foreach不支持在循环时对集合进行增删操作
    /// </summary>
    public class _018ForeachAndFor2
    {
        public static void Run()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            foreach (var item in list)
            {
                //list.Remove(item);  // throw InvalidOperationException
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i >= list.Count)
                    break;
                Console.WriteLine(list[i]);
                list.Remove(list[i]);
            }
        }
    }
}
