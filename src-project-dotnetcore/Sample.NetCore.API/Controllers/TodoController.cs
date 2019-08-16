using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Interfaces;

namespace Sample.NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        ITodoItemRepository _todoItemRepository;
        public TodoController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTodoItem(int id)
        {
            var todoItem = await _todoItemRepository.GetAsync(id);
            if (todoItem == null)
            {
                return NotFound(id);
            }
            return Ok(todoItem);
        }
    }
}