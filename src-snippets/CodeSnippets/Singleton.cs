﻿using System;

namespace CodeSnippets
{
    /// <summary>
    /// 单例模式实现
    /// </summary>
    public class Singleton
    {
        // 定义一个静态变量来保存类的实例
        private static Singleton uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private Singleton()
        {
        }

        /// <summary>
        /// 定义共有方法提供一个全局访问点，同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            // 当第一个线程运行到这里时，会对locker对象“加锁”
            // 当第二个线程运行到这里时，首先检测到locker对象为“加锁”状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完成后（即线程运行完之后）会对该对象“加锁”
            if (uniqueInstance==null)
            {
                lock (locker)
                {
                    // 如果实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
