using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.NetCore.Infrastructure.Interfaces;
using Sample.NetCore.Web.Models;

namespace Sample.NetCore.Web.Controllers
{
    public class TemporaryController : Controller
    {
        private readonly ITodoItemRepository _todoItemRepository;
        public TemporaryController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
        public async Task<IActionResult> Index()
        {
            var todos = await _todoItemRepository.ListAsync();
            var model = todos.Select(todo => new TodoItemViewModel()
            {
                Id = todo.ID,
                Name = todo.Name,
                ModifyTime = todo.ModifyTime,
                StepCount = todo.Steps.Count
            });
            return View(model);
        }
    }
}