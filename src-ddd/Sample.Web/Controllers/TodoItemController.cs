using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Infrastructure.Repositories;

namespace Sample.Web.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly ILogger<TodoItemController> _logger;
        TodoItemRepository _todoItemRepository;
        public TodoItemController(ILogger<TodoItemController> logger, TodoItemRepository todoItemRepository)
        {
            _logger = logger;
            _todoItemRepository = todoItemRepository;
        }
        public async Task<IActionResult> Index()
        {
            var todos = await _todoItemRepository.GetAllAsync();
            return View(todos);
        }
    }
}