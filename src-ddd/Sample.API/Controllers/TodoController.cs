using System;
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
    [Route("api/v1/[controller]")]
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
                _todoItemRepository.Insert(new Domain.Entities.TodoItem { Name = "测试1", IsComplete = 0 });
                _todoItemRepository.Insert(new Domain.Entities.TodoItem { Name = "测试2", IsComplete = 0 });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _todoItemRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetAsync(long id)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
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