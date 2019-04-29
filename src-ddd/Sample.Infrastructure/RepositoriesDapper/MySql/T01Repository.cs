using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sample.Domain.Entities;

namespace Sample.Infrastructure.RepositoriesDapper.MySql
{
    public class T01Repository
    {
        IConfiguration _configuration;
        public T01Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<T01> GetAll()
        {
            var connection = GetConnection();
            string sql = "SELECT * FROM T01";
            return connection.Query<T01>(sql);
        }

        public int Insert(T01 entity)
        {
            string sql = $"INSERT INTO {GetTableName()} ({nameof(entity.StringValue)},{nameof(entity.IntValue)},{nameof(entity.DateTimeValue)},{nameof(entity.BooleanValue)},{nameof(entity.IntNullableValue)},{nameof(entity.DateTimeNullableValue)},{nameof(entity.BooleanNullableValue)}) values (@{nameof(entity.StringValue)},@{nameof(entity.IntValue)},@{nameof(entity.DateTimeValue)},@{nameof(entity.BooleanValue)},@{nameof(entity.IntNullableValue)},@{nameof(entity.DateTimeNullableValue)},@{nameof(entity.BooleanNullableValue)})";
            var connection = GetConnection();
            return connection.Execute(sql, entity);
        }

        private IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings").GetSection("MySql-Sample").Value;
            var conn = new MySqlConnection(connectionString);
            return conn;
        }
        private string GetTableName()
        {
            return "T01";
        }
    }
}
