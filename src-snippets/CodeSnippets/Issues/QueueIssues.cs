using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Issues
{
    public class QueueIssues
    {
        public static Queue<QueueContent> queue = new Queue<QueueContent>();
        // 源数组长度不足。请检查 srcIndex 和长度以及数组的下限。


        public void In(QueueContent content)
        {
            //lock (Const.queueLock)
            queue.Enqueue(content);
        }

        public void Out(Queue<QueueContent> queue)
        {
            //lock (Const.queueLock)
            queue.Dequeue();
        }

        private void TestCode()
        {
            QueueIssues queueIssues = new QueueIssues();
            Console.WriteLine("start");
            // throw:System.ArgumentException: Source array was not long enough. Check the source index, length, and the array's lower bounds.
            while (true)
            {
                if (DateTime.Now > new DateTime(2019, 7, 10, 14, 55, 0))
                {
                    break;
                }
                Task.Run(() =>
                {
                    try
                    {
                        queueIssues.In(new QueueContent { A = new Random().Next(1, 10000), B = "aaa" });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                });
                Task.Run(() =>
                {
                    queueIssues.Out(QueueIssues.queue);
                });
            }
        }
    }
    public class QueueContent
    {
        public int A { get; set; }
        public string B { get; set; }
    }
}
