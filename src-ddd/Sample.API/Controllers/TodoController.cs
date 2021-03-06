﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Domain.Entities;
using Sample.Infrastructure;
using Sample.Infrastructure.Repositories;
using Sample.Infrastructure.Util;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        TodoItemRepository _todoItemRepository;
        public TodoController(ILogger<TodoController> logger, TodoItemRepository todoItemRepository)
        {
            _logger = logger;
            _todoItemRepository = todoItemRepository;

            if (_todoItemRepository.GetCount() == 0)
            {
                _todoItemRepository.Insert(new Domain.Entities.TodoItem { Name = "测试1", IsComplete = false });
                _todoItemRepository.Insert(new Domain.Entities.TodoItem { Name = "测试2", IsComplete = false });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItemsAsync()
        {
            var result = await _todoItemRepository.GetAllAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItemAsync(long id)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItem item)
        {
            await _todoItemRepository.InsertAsync(item);

            return CreatedAtAction(nameof(GetTodoItemAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _todoItemRepository.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(id);
            if (todoItem == null)
                return NotFound();
            await _todoItemRepository.DeleteAsync(todoItem);

            return NoContent();
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test(string from, string to, string password)
        {
            EmailOperator emailOperator = new EmailOperator(_logger, "smtp-mail.outlook.com", 587);
            emailOperator.SecureSocketOptions = MailKit.Security.SecureSocketOptions.StartTls;
            emailOperator.SenderEmailAdrees = from;
            emailOperator.SenderEmailPassword = password;
            emailOperator.Subject = "test from api";
            emailOperator.Body = "The mail from api send by MailKit.";
            emailOperator.SendEmail(from, to);
            return Ok();
        }
    }
}