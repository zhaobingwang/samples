using Dapper;
using Sample.API.Framework.DTOs;
using Sample.API.Framework.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Sample.API.Framework.Controllers.API
{
    /// <summary>
    /// 书籍API
    /// </summary>
    [RoutePrefix("api/books")]
    public class Books222Controller : BaseController
    {

        /// <summary>
        /// 获取所有书籍基本信息
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<BookDto> GetBooks()
        {
            string sql = "select a.Title as title,b.Name as author,a.Genre as genre from Books a left join Authors b on a.AuthorId=b.AuthorId";
            return connection.Query<BookDto>(sql);
        }

        /// <summary>
        /// 根据ID获取一本书
        /// </summary>
        /// <param name="id">书籍ID</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [ResponseType(typeof(BookDto))]
        public IHttpActionResult GetBook(int id)
        {
            string sqlBook = $"select * from Books where {nameof(Book.BookId)}=@id";
            string sqlAuthor = $"select * from Authors where {nameof(Author.AuthorId)}=@authorId";
            var book = connection.Query<Book>(sqlBook, new { id = id }).FirstOrDefault();
            var author = connection.Query<Author>(sqlAuthor, new { authorId = book.AuthorId }).FirstOrDefault();

            book.Author = author;

            var bookDto = MapperHelper.MapTo<BookDto>(book);
            if (bookDto == null)
            {
                return NotFound();
            }
            return Ok(bookDto);
        }
    }
}
