using Dapper;
using Sample.API.Framework.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Sample.API.Framework.Controllers.API
{
    /// <summary>
    /// 书籍API
    /// </summary>
    public class BooksController : BaseController
    {

        /// <summary>
        /// 获取所有书籍基本信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookDto> GetBooks()
        {
            string sql = "select a.Title as title,b.Name as author,a.Genre as genre from Books a left join Authors b on a.AuthorId=b.AuthorId";
            return connection.Query<BookDto>(sql);
        }
    }
}
