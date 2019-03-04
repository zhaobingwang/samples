using Dapper;
using MySql.Data.MySqlClient;
using Sample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sample.Data.Access.Dapper
{
    public class UserOperator
    {
        MySqlConnection connection;
        string _conncetionString = null;
        public UserOperator()
        {
            _conncetionString = Sample.Share.Constants.DBConnectionString.MySql01;
        }
        public UserOperator(string connString)
        {
            _conncetionString = connString;
        }
        public bool Insert(User user)
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

        public void BulkToMySql(int bulkCount)
        {
            StringBuilder sqlCmd = new StringBuilder($"insert into users ({nameof(User.NickName)},{nameof(User.Email)},{nameof(User.IsDelete)},{nameof(User.RegTime)},{nameof(User.ModifyTime)},{nameof(User.Remark)}) values ");
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                List<string> rows = new List<string>();
                for (int i = 0; i < bulkCount; i++)
                {
                    //rows.Add(string.Format("('{0}','{1}')", MySqlHelper.EscapeString("test"), MySqlHelper.EscapeString("test")));
                    rows.Add($"('测试{i}','ceshi{i}@qq.com','{0}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','')");
                }
                sqlCmd.Append(string.Join(",", rows));
                sqlCmd.Append(";");
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sqlCmd.ToString(), connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
