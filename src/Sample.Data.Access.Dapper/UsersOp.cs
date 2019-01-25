using Dapper;
using MySql.Data.MySqlClient;
using Sample.Data.Entities;
using System;
using System.Collections.Generic;

namespace Sample.Data.Access.Dapper
{
    public class UsersOp
    {
        MySqlConnection connection;
        string _conncetionString = null;
        public UsersOp()
        {
            _conncetionString = "server=127.0.0.1;user id=root;password=123456;database=sample";
        }
        public UsersOp(string connString)
        {
            _conncetionString = connString;
        }
        public bool AddUser(User user)
        {
            string sql = $"insert into Users ({nameof(User.NickName)},{nameof(User.Email)},{nameof(User.IsDelete)},{nameof(User.RegTime)},{nameof(User.ModifyTime)},{nameof(User.Remark)}) values (@NickName,@Email,@IsDelete,@RegTime,@ModifyTime,@Remark)";
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Execute(sql, user) > 0;
            }
        }
        public IEnumerable<User> GetUsersByNickName(string nickName)
        {
            string query = $"select {nameof(User.NickName)},{nameof(User.Email)},{(nameof(User.Remark))} from users a where {nameof(User.NickName)} =@NickName";
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Query<User>(query, new { nickName });
            }
        }
    }
}
