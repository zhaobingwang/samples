using Dapper;
using MySql.Data.MySqlClient;
using Sample.Data.Entities;
using System;

namespace Sample.Data.Access.Dapper
{
    public class UsersOp
    {
        MySqlConnection connection;
        public UsersOp()
        {
            connection = new MySqlConnection("server=127.0.0.1;user id=root;password=123456;database=sample");
        }
        public UsersOp(string connString)
        {
            connection = new MySqlConnection(connString);
        }
        public bool AddUser(User user)
        {
            string sql = "insert into Users (NickName,Email,IsDelete,RegTime,ModifyTime,Remark) values (@nickName,@email,@isDelete,@regTime,@modifyTime,@remark)";
            using (connection)
            {
                return connection.Execute(sql, user) > 0;
            }
        }
    }
}
