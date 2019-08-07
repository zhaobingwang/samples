using Moq;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Interfaces;
using Sample.NetCore.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Sample.NetCore.Web.Models;
using System.Linq;

namespace UnitTests.Web.Controller
{
    [Trait("web测试", "控制器")]
    public class TemporaryControllerTests
    {
        [Fact(DisplayName = "首页返回正确视图和数据")]
        public async Task Index_ReturnsAViewResult_WithAListOfTodoItems()
        {
            // Arrange
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestTodos());
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<TodoItemViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        #region snippet_GetTestTodos
        private List<TodoItem> GetTestTodos()
        {
            List<TodoItem> todos = new List<TodoItem>();
            var todo1 = new TodoItem()
            {
                Name = "测试1",
                IsComplete = false,
                CreateTime = DateTimeOffset.UtcNow,
                ModifyTime = DateTimeOffset.UtcNow,
            };
            var todo2 = new TodoItem()
            {
                Name = "测试2",
                IsComplete = true,
                CreateTime = DateTimeOffset.UtcNow,
                ModifyTime = DateTimeOffset.UtcNow,
            };
            var step1 = new TodoItemStep()
            {
                Index = 1,
                Name = "步骤1"
            };
            var step2 = new TodoItemStep()
            {
                Index = 1,
                Name = "步骤2"
            };

            todo1.AddStep(step1);
            todo1.AddStep(step2);

            todo2.AddStep(step1);

            todos.Add(todo1);
            todos.Add(todo2);

            return todos;
        }
        #endregion
    }
}
