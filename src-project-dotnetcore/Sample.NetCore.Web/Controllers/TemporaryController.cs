using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                IsComplete = todo.IsComplete,
                ModifyTime = todo.ModifyTime,
                StepCount = todo.Steps.Count
            });
            return View(model);
        }
        public async Task<IActionResult> IndexById(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index), controllerName: "Home");
            }
            var todo = await _todoItemRepository.GetAsync(id.Value);
            if (todo == null)
            {
                return Content("Todo items not found");
            }

            var viewModel = new TodoItemViewModel()
            {
                Id = todo.ID,
                Name = todo.Name,
                IsComplete = todo.IsComplete,
                ModifyTime = todo.ModifyTime,
                StepCount = todo.Steps.Count
            };
            List<TodoItemViewModel> list = new List<TodoItemViewModel>();
            list.Add(viewModel);
            return View("Index", list);
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewTodoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var todo = new Domain.Entities.TodoItem()
                {
                    CreateTime = DateTimeOffset.Now,
                    ModifyTime = DateTimeOffset.Now,
                    IsComplete = false,
                    Name = model.Name
                };
                var step1 = new Domain.Entities.TodoItemStep() { Index = 1, Name = "步骤1" };
                todo.AddStep(step1);

                await _todoItemRepository.AddAsync(todo);
            }
            return RedirectToAction(actionName: nameof(Index));
        }

        public class NewTodoModel
        {
            [Required]
            public string Name { get; set; }
        }
    }
}