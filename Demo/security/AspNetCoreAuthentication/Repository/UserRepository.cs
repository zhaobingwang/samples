using AspNetCoreAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAuthentication.Repository
{
    public class UserRepository
    {
        public User findUser(string userName, string password)
        {
            return _users.FirstOrDefault(x => x.Name == userName && x.Password == password);
        }

        private static List<User> _users = new List<User> {
            new User{ Id=1,Name="张三",Password="zhangsan",Email="zhangsan@email.com",PhoneNumber="18800000000"},
            new User{ Id=1,Name="李四",Password="lisi",Email="lisi@email.com",PhoneNumber="18800000001"}
        };
    }
}
