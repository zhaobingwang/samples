using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Sample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Data.Access.Dapper
{
    public class UserTagOperator
    {
        MySqlConnection conncetion;
        string _conncetionString = null;
        public UserTagOperator()
        {
            _conncetionString = Share.Constants.DBConnectionString.MySql01;
        }
        public UserTagOperator(string conncetionString)
        {
            _conncetionString = conncetionString;
        }

        public int Insert(UserTag entity)
        {
            string sql = $"insert into UsersTags ({nameof(UserTag.Name)},{nameof(UserTag.FriendId)},{nameof(UserTag.UserId)}) values (@Name,@FriendId,@UserId)";
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Execute(sql, entity);
            }
        }

        public long InsertByContrib(UserTag entity)
        {
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Insert(entity);
            }
        }

        public bool Delete(int id)
        {
            string sql = $"delete from UserTags where {nameof(UserTag.Id)}=@id";
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Execute(sql, new { id = id }) > 0;
            }
        }

        public bool DeleteByContrib(UserTag entity)
        {
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Delete(entity);
            }
        }

        public bool Update(int id, string name)
        {
            string sql = $"update {GetTableName()} set {nameof(UserTag.Name)}=@name where {nameof(UserTag.Id)}=@id";
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return conncetion.Execute(sql, new { id = id, name = name }) > 0;
            }
        }

        public bool UpdateByContrib(UserTag entity)
        {
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Update(entity);
            }
        }
        public IEnumerable<UserTag> Query(int userId, int friendId)
        {
            string sql = $"select * from UsersTags where {nameof(UserTag.UserId)}=@userId and {nameof(UserTag.FriendId)}=@friendId";
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return conncetion.Query<UserTag>(sql, new { UserId = userId });
            }
        }
        public UserTag QueryByContrib(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(_conncetionString))
            {
                return connection.Get<UserTag>(id);
            }
        }

        private string GetTableName()
        {
            return "UsersTags";
        }
    }
}
