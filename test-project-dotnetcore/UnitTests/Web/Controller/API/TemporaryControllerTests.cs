using Microsoft.AspNetCore.Mvc;
using Moq;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Interfaces;
using Sample.NetCore.Web.Controllers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Web.Controller.API
{
    [Trait("控制器测试", "API")]
    public class TemporaryControllerTests
    {
        #region snippet_Get
        [Fact(DisplayName = "获取待办事项-返回404-当未获取到待办事项时")]
        public async Task GetTodoItems_ReturnsHttpNotFound_ForInvalidTodoItem()
        {
            // Arrange
            int todoId = 111;
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.GetAsync(todoId))
                .ReturnsAsync((TodoItem)null);
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.Get(todoId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(todoId, notFoundObjectResult.Value);
        }
        [Fact(DisplayName = "获取待办事项-返回正确的待办事项")]
        public async Task GetTodoItems_ReturnsTodoItems()
        {
            // Arrange
            int todoId = 1;
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.GetAsync(todoId))
                .ReturnsAsync(FakeDatasHelper.GetTestTodos().FirstOrDefault(t => t.ID == todoId));
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.Get(todoId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<TodoItem>(okResult.Value);
            Assert.False(returnValue.IsComplete);
            Assert.Equal("测试1", returnValue.Name);
            Assert.Equal(DateTimeOffset.Now.Day, returnValue.ModifyTime.Day);
            Assert.Equal(todoId, returnValue.ID);
            Assert.Equal(2, returnValue.Steps.Count);
        }
        #endregion

        #region snippet_Post
        [Fact(DisplayName = "新增一个待办事项-返回400BadReqeust-当传错误的参数时")]
        public async Task Post_ReturnsBadReqeust_GivenInvalidModel()
        {
            // Arrange
            var mockRepo = new Mock<ITodoItemRepository>();
            var controller = new TemporaryController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.Post(model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact(DisplayName = "新增一个待办事项-返回新增的的todoitems")]
        public async Task Post_ReturnsNewlyCreatedTodoItems()
        {
            // Arrange
            var todo = FakeDatasHelper.GetTestTodos().FirstOrDefault();
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.AddAsync(todo))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new TemporaryController(mockRepo.Object);

            // Act
            var result = await controller.Post(new TemporaryController.NewTodoModel() { Name = "test" });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTodo = Assert.IsType<TodoItem>(okResult.Value);
            Assert.False(returnTodo.IsComplete);
            Assert.Equal("test", returnTodo.Name);
            Assert.Equal(DateTimeOffset.Now.Day, returnTodo.ModifyTime.Day);
            Assert.Equal(DateTimeOffset.Now.Day, returnTodo.CreateTime.Day);
            Assert.Empty(returnTodo.Steps);
        }
        #endregion
    }
}
