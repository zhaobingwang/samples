using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Infrastructure;
using Sample.Infrastructure.Repositories;
using Sample.Infrastructure.Util;

namespace Sample.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoItemsController : BaseController
    {
        private readonly ILogger<TodoItemsController> _logger;
        TodoItemRepository _todoItemRepository;
        public TodoItemsController(ILogger<TodoItemsController> logger, TodoItemRepository todoItemRepository)
        {
            _logger = logger;
            _todoItemRepository = todoItemRepository;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<string>> GetAsync()
        {
            _logger.LogInformation($"Visit {nameof(GetAsync)}");
            var todoItem = await _todoItemRepository.GetAllAsync();
            return Ok(todoItem);
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