using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Fragment.ConsoleApp
{
    public static class FakeData
    {
        public static List<User> GetUsers()
        {
            List<User> list = new List<User>();
            list.Add(new User
            {
                ID = 10001,
                NickName = "张三",
                RealName = "张三",
                MobilePhone = "18812123434",
                IsDelete = false
            });

            list.Add(new User
            {
                ID = 10001,
                NickName = "李四",
                RealName = "lisi",
                MobilePhone = "18812123434",
                IsDelete = false
            });

            list.Add(new User
            {
                ID = 10001,
                NickName = "王五",
                RealName = null,
                MobilePhone = "18812123434",
                IsDelete = false
            });

            return list;
        }
    }
}
