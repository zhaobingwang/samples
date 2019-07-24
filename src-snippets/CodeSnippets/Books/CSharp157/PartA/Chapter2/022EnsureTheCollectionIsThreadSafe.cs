using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// 确保集合的线程安全
    /// </summary>
    public class _022EnsureTheCollectionIsThreadSafe
    {
        static List<Person> list = new List<Person>()
        {
            new Person("001"){ FirstName="三",LastName="张"},
            new Person("002"){ FirstName="四",LastName="李"},
            new Person("003"){ FirstName="五",LastName="王"}
        };

        //static ConcurrentBag<Person> list = new ConcurrentBag<Person>()
        //{
        //    new Person("001"){ FirstName="三",LastName="张"},
        //    new Person("002"){ FirstName="四",LastName="李"},
        //    new Person("003"){ FirstName="五",LastName="王"}
        //};

        static AutoResetEvent autoReset = new AutoResetEvent(false);

        // 如果是其他集合，可以根据实际情况选择线程安全集合类型：
        // ConcurrentQueue<T> 对应 Queue<T>
        // ConcurrentDictionary<TKey, TValue>  对应 Dictionary<TKey, TValue> 
        // ConcurrentBag<T> 对应 List<T>
        // ConcurrentStack<T> 对应 Stack<T>

        static object syncObj = new object();   // 如果是ArrayList，内置已经实现的lock:SyncRoot

        public static void RunThrowInvalidOperationException()
        {
            //Task t1 = new Task(() =>
            //{
            //    // 确保等待t2开始后才运行以下代码
            //    autoReset.WaitOne();
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine($"t1:{item.LastName} {item.FirstName}");
            //        Thread.Sleep(1000);
            //        //Task.Delay(1000);
            //    }
            //});
            Thread t1 = new Thread(() =>
            {
                // 确保等待t2开始后才运行以下代码
                autoReset.WaitOne();
                lock (syncObj)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine($"t1:{item.LastName} {item.FirstName}");
                        Thread.Sleep(1000);
                    }
                }
            });
            t1.Start();
            //Task t2 = new Task(() =>
            //{
            //    // 通知t1可以执行代码
            //    autoReset.Set();
            //    // 睡眠1秒是为了确保删除操作在t1迭代过程中
            //    Thread.Sleep(1000);
            //    //Task.Delay(1000);
            //    list.RemoveAt(2);
            //});
            Thread t2 = new Thread(() =>
            {
                // 通知t1可以执行代码
                autoReset.Set();
                // 睡眠1秒是为了确保删除操作在t1迭代过程中
                Thread.Sleep(1000);
                lock (syncObj)
                {
                    list.RemoveAt(2);
                }
            });
            t2.Start();
        }
    }
}
