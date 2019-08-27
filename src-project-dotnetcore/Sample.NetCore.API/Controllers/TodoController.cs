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


        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            var todoItems = await _todoItemRepository.ListAsync();
            if (todoItems == null)
            {
                return NotFound();
            }
            return Ok(todoItems);
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

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            item.CreateTime = DateTimeOffset.Now;
            item.ModifyTime = DateTimeOffset.Now;
            await _todoItemRepository.AddAsync(item);
            return CreatedAtAction(nameof(GetTodoItem), new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }
            await _todoItemRepository.UpdateAsync(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _todoItemRepository.GetAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            await _todoItemRepository.DeleteAsync(todoItem);

            return NoContent();
        }
    }
}