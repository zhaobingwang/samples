using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        [Route("author/get-all")]
        public IActionResult Articles(int userId)
        {
            List<Article> articles = new List<Article> {
                new Article{
                    Id=1,
                    Author=userId.ToString(),
                    Title="文章A",
                    MainBody="正文A",
                    CreateTime=DateTimeOffset.Now,
                    ModifyTime=DateTimeOffset.Now
                },
                new Article{
                    Id=1,
                    Author=userId.ToString(),
                    Title="文章B",
                    MainBody="正文B",
                    CreateTime=DateTimeOffset.Now,
                    ModifyTime=DateTimeOffset.Now
                }
            };
            return Ok(articles);
        }
    }

    public class Article
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string MainBody { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
    }
}