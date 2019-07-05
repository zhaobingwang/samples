using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Infrastructure.Cache.Redis;
using Sample.Infrastructure.Repositories;
using Newtonsoft.Json;

namespace Sample.Web.Controllers
{
    public class RedisController : Controller
    {
        RedisManager redis;
        TodoItemRepository _todoItemRepository;

        public const string strKey = "sample:test";

        public RedisController(TodoItemRepository todoItemRepository)
        {
            redis = new RedisManager();
            _todoItemRepository = todoItemRepository;
        }
        public async Task<IActionResult> Index()
        {
            var todoItems = await _todoItemRepository.GetAllAsync();
            foreach (var todo in todoItems)
            {
                await redis.SetStringAsync($"Sample:TodoItems:{todo.Id}:Datas", JsonConvert.SerializeObject(todo), TimeSpan.FromMinutes(60));
            }
            return View();
        }

        public async Task<ActionResult> GetRedisValue()
        {
            var result = await redis.GetStringAsync("Sample:TodoItems:1:Datas");
            return Json(result);
        }
    }
}