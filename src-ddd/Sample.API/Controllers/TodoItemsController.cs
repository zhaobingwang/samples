using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Infrastructure;
using Sample.Infrastructure.Repositories;

namespace Sample.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoItemsController : BaseController
    {
        TodoItemRepository _todoItemRepository;
        public TodoItemsController(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<string>> GetAsync()
        {
            logger.Info($"Visit the function:{typeof(TodoItemsController)}.{nameof(TodoItemsController.GetAsync)}");
            var todoItem = await _todoItemRepository.GetAllAsync();
            return Ok(todoItem);
        }
    }
}