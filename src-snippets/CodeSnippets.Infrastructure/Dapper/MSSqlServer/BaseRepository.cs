using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CodeSnippets.Infrastructure.Dapper.MSSqlServer
{
    public class BaseRepository : IBaseRepository
    {
        private IConfiguration Configuration;

        public IDbConnection DbConnection { get; private set; }
        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            DbConnection = new SqlConnection(configuration.GetConnectionString("sqlserver"));
        }

        public object Get()
        {
            using (DbConnection)
            {
                var aa = DbConnection.Query("select * from Template");
                return aa;
            }
        }
    }
}
