using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CodeSnippets.Infrastructure.Entities;
using Dapper;
using Npgsql;

namespace CodeSnippets.ThirdParty
{
    public class DapperSample
    {
        IDbConnection dbConnection;
        public DapperSample()
        {
            dbConnection = new NpgsqlConnection("Host=192.168.0.166;Database=NpgsqlEFContext;Username=postgres;Password=123456");
        }

        public void GetBlogs()
        {
            string sqlQuery = $"select * from {Blog.GetTableName()}";
            var blogs = dbConnection.Query<Blog>(sqlQuery);
            var a = 1;
        }
    }
}
