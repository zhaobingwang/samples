using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    public class _020GenericCollections
    {
        public static void Run()
        {
            object a = 1;
            int b = (int)a;
            // bad code
            ArrayList al = new ArrayList();
            al.Add(1);  // ArrayList.Add()接收object参数，此处会完成一次装箱操作
            al.Add("aa");
            foreach (var item in al)
            {
                Console.WriteLine(item);
            }
        }
    }
}
