using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace Sample.API.Framework.Controllers.API
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        protected IDbConnection connection = null;

        /// <summary>
        /// API控制器基类
        /// </summary>
        /// <param name="conn">MySQL数据库连接字符串</param>
        public BaseController(string conn = Constants.CONN_MYSQL_SAMPLE)
        {
            connection = new MySqlConnection(conn);
        }
    }
}
