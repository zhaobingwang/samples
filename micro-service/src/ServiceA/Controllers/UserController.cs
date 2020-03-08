using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Services;

namespace ServiceA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IArticleService _articleService;
        public UserController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        [Route("tag/create")]
        public IActionResult CreateTag([FromForm]int userId, [FromForm]string value)
        {
            // 假设数据库记录添加成功，直接返回对象
            Tag tagEntity = new Tag();
            tagEntity.Id = 1;
            tagEntity.UserId = userId;
            tagEntity.Value = value;
            return Ok(tagEntity);
        }

        [HttpGet]
        [Route("article/get-all")]
        public async Task<IActionResult> Articles(int userId)
        {
            var articles = await _articleService.GetArticles(userId);
            return Ok(articles);
        }
    }
    public class Tag
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
    }

    public class Article
    {
        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string mainBody { get; set; }
        public DateTimeOffset createTime { get; set; }
        public DateTimeOffset modifyTime { get; set; }
    }
}