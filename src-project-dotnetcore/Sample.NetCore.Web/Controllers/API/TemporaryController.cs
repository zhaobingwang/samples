using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Interfaces;

namespace Sample.NetCore.Web.Controllers.API
{
    [Route("api/temp")]
    [ApiController]
    public class TemporaryController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;
        public TemporaryController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository ?? throw new ArgumentNullException($"{nameof(todoItemRepository)}");
        }
        [HttpGet]
        public async Task<IActionResult> Get(int todoId)
        {
            var todo = await _todoItemRepository.GetAsync(todoId);
            if (todo == null)
            {
                return NotFound(todoId);
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewTodoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = new TodoItem()
            {
                Name = model.Name,
                IsComplete = false,
                CreateTime = DateTimeOffset.Now,
                ModifyTime = DateTimeOffset.Now
            };

            await _todoItemRepository.AddAsync(todo);
            return Ok(todo);
        }

        public class NewTodoModel
        {
            [Required]
            public string Name { get; set; }
        }
    }
}