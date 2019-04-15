using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Infrastructure.Repositories;

namespace Sample.Web.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ILogger<TodoItemsController> _logger;
        TodoItemRepository _todoItemRepository;
        public TodoItemsController(ILogger<TodoItemsController> logger, TodoItemRepository todoItemRepository)
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