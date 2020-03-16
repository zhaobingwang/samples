using CodeSnippets.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Issues
{
    public class LockIssues
    {
        private static List<User> users;
        private static Queue<User> usersQueue;
        private static ConcurrentQueue<User> usersConcurrentQueue;
        private static object lockObj = new object();

        #region Basic
        public static void RunWithOutLock()
        {
            users = new List<User>();
            Task task1 = Task.Run(() =>
            {
                AddUsersWithOutLock();
            });
            Task task2 = Task.Run(() =>
            {
                AddUsersWithOutLock();
            });
            Task task3 = Task.Run(() =>
            {
                AddUsersWithOutLock();
            });

            Task.WaitAll(task1, task2, task3);
            Console.WriteLine(users.Count); // less than 3000
        }
        public static void RunWithLock()
        {
            users = new List<User>();
            Task task1 = Task.Run(() =>
            {
                AddUsersWithLock();
            });
            Task task2 = Task.Run(() =>
            {
                AddUsersWithLock();
            });
            Task task3 = Task.Run(() =>
            {
                AddUsersWithLock();
            });

            Task.WaitAll(task1, task2, task3);
            Console.WriteLine(users.Count); // 3000
        }
        #endregion

        #region Queue && ConcurrentQueue
        public static void Queue()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            usersQueue = new Queue<User>();
            Task task1 = Task.Run(() =>
            {
                AddUsersToQueue();
            });
            Task task2 = Task.Run(() =>
            {
                AddUsersToQueue();
            });
            Task task3 = Task.Run(() =>
            {
                AddUsersToQueue();
            });

            Task.WaitAll(task1, task2, task3);
            stopwatch.Stop();
            Console.WriteLine(usersQueue.Count); // 3000
            Console.WriteLine($"elapsed time:{stopwatch.ElapsedMilliseconds} ms");
        }

        public static void ConcurrentQueue()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            usersConcurrentQueue = new ConcurrentQueue<User>();
            Task task1 = Task.Run(() =>
            {
                AddUsersToConcurrentQueue();
            });
            Task task2 = Task.Run(() =>
            {
                AddUsersToConcurrentQueue();
            });
            Task task3 = Task.Run(() =>
            {
                AddUsersToConcurrentQueue();
            });

            Task.WaitAll(task1, task2, task3);
            stopwatch.Stop();
            Console.WriteLine(usersConcurrentQueue.Count); // 3000
            Console.WriteLine($"elapsed time:{stopwatch.ElapsedMilliseconds} ms");
        }
        #endregion

        #region Private Function
        private static void AddUsersWithOutLock()
        {
            Parallel.For(0, 1000, (i) =>
            {
                User user = new User
                {
                    Id = i,
                    Name = $"test_{i}"
                };
                users.Add(user);
            });
        }

        private static void AddUsersWithLock()
        {
            Parallel.For(0, 1000, (i) =>
            {
                lock (lockObj)
                {
                    User user = new User
                    {
                        Id = i,
                        Name = $"test_{i}"
                    };
                    users.Add(user);
                }
            });
        }

        private static void AddUsersToQueue()
        {
            Parallel.For(0, 1000, (i) =>
            {
                lock (lockObj)
                {
                    User user = new User
                    {
                        Id = i,
                        Name = $"test_{i}"
                    };
                    usersQueue.Enqueue(user);
                }
            });
        }

        private static void AddUsersToConcurrentQueue()
        {
            Parallel.For(0, 1000, (i) =>
            {
                User user = new User
                {
                    Id = i,
                    Name = $"test_{i}"
                };
                usersConcurrentQueue.Enqueue(user);
            });
        }
        #endregion
    }
}
