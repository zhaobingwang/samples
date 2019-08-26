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
            dbConnection = new NpgsqlConnection("Host=192.168.0.166;Database=snippets;Username=postgres;Password=123456");
        }

        public void Insert()
        {
            Blog blog = new Blog();
            blog.url = "http://127.0.0.1/blogs/userid";
            string sql = $"insert into blogs (url) values (@url)";
            var result = dbConnection.Execute(sql, new { url = blog.url });
        }
        public void GetBlogs()
        {
            string sqlQuery = $"select * from blogs";
            var blogs = dbConnection.Query<Blog>(sqlQuery);
            var a = 1;
        }
    }
}
