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
    [Trait("控制器测试", "Web")]
    public class TemporaryControllerTests
    {
        #region snippet_Index
        [Fact(DisplayName = "TemporaryController 返回正确视图和数据")]
        public async Task Index_ReturnsAViewResult_WithAListOfTodoItems()
        {
            // Arrange
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(FakeDatasHelper.GetTestTodos());
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<TodoItemViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        #endregion

        #region snippet_IndexPost
        [Fact(DisplayName = "TemporaryController Post添加数据并重定向到action 正确入参测试")]
        public async Task IndexPost_ReturnsARedirectAndAddsTodo_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<TodoItem>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var controller = new TemporaryController(mockRepo.Object);
            var newTodo = new TemporaryController.NewTodoModel()
            {
                Name = "测试"
            };

            // Act
            var result = await controller.Index(newTodo);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

        [Fact(DisplayName = "TemporaryController Post添加数据并重定向到action 异常入参测试")]
        public async Task IndexPost_ReturnsARedirectAndAddsTodo_WhenModelStateIsInValid()
        {
            // Arrange
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(FakeDatasHelper.GetTestTodos());

            var controller = new TemporaryController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var newTodo = new TemporaryController.NewTodoModel();

            // Act
            var result = await controller.Index(newTodo);

            // Assert
            var badReqeustResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badReqeustResult.Value);
        }
        #endregion

        #region snippet_IndexById
        [Fact(DisplayName = "TemporaryController 返回首页 当ID是null的时候")]
        public async Task IndexById_ReturnsARedirectToIndexHomeWhenIdIsNull()
        {
            // Arrange
            var controller = new TemporaryController(todoItemRepository: null);

            // Act
            var result = await controller.IndexById(id: null);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact(DisplayName = "TemporaryController 返回Content 当没有待办事项的时候")]
        public async Task IndexById_ReturnsContentWithTodoItemsNotFound_WhenTodoItemNotFound()
        {
            // Arrange
            int todoId = 1;
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.GetAsync(todoId))
                .ReturnsAsync((TodoItem)null);
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.IndexById(todoId);

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("Todo items not found", contentResult.Content);
        }

        [Fact(DisplayName = "TemporaryController 返回正确的视图和数据")]
        public async Task IndexById_ReturnsViewResult_WithTodoItemsVideModel()
        {
            // Arrange
            var todoId = 1;
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.GetAsync(todoId))
                .ReturnsAsync(FakeDatasHelper.GetTestTodos().FirstOrDefault(t => t.ID == todoId));
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.IndexById(todoId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<TodoItemViewModel>>(viewResult.ViewData.Model);
            Assert.False(model[0].IsComplete);
            Assert.Equal("测试1", model[0].Name);
            Assert.Equal(DateTimeOffset.Now.Day, model[0].ModifyTime.Day);
            Assert.Equal(todoId, model[0].Id);
            Assert.Equal(2, model[0].StepCount);
        }
        #endregion
    }
}
