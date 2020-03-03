using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("tag/create")]
        public IActionResult CreateTag([FromForm]Tag tag)
        {
            // 假设数据库记录添加成功，直接返回对象
            Tag tagEntity = new Tag();
            tagEntity.Id = 1;
            tagEntity.UserId = tag.UserId;
            tagEntity.Value = tag.Value;
            return Ok(tagEntity);
        }
    }
    public class Tag
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
    }
}