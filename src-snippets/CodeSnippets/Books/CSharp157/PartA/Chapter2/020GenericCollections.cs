using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        static int collectionCount = 0;
        static Stopwatch watch = null;
        static int testCount = 1000 * 10000;
        public static void PerformanceTest()
        {
            Console.WriteLine("开始测试ArrayList:");
            TestBegin();
            TestArrayList();
            TestEnd();
            Console.WriteLine("开始测试List<T>:");
            TestBegin();
            TestGenericList();
            TestEnd();
        }
        static void TestBegin()
        {
            GC.Collect();   // 强制对有所代码进行及时垃圾回收
            GC.WaitForPendingFinalizers();  // 挂起线程，执行终结器队列中的终结器（即析构方法）
            GC.Collect();   // 再次对所有代码进行垃圾回收，主要包括从终结器队列中出来的对象
            collectionCount = GC.CollectionCount(0);    // 返回在0代中执行的垃圾回收次数
            watch = new Stopwatch();
            watch.Start();
        }
        static void TestEnd()
        {
            watch.Stop();
            Console.WriteLine($"耗时：{watch.ElapsedMilliseconds} 毫秒");
            Console.WriteLine($"垃圾回收次数：{GC.CollectionCount(0) - collectionCount}");
        }
        static void TestArrayList()
        {
            ArrayList al = new ArrayList();
            int temp = 0;
            for (int i = 0; i < testCount; i++)
            {
                al.Add(i);
                temp = (int)al[i];
            }
            al = null;
        }
        static void TestGenericList()
        {
            List<int> listT = new List<int>();
            int temp = 0;
            for (int i = 0; i < testCount; i++)
            {
                listT.Add(i);
                temp = listT[i];
            }
            listT = null;
        }
    }
}
