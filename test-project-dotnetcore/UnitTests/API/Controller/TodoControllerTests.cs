using Microsoft.AspNetCore.Mvc;
using Moq;
using Sample.NetCore.API.Controllers;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.API.Controller
{
    [Trait("WEBAPI", "API控制器测试")]
    public class TodoControllerTests
    {
        [Fact(DisplayName = "获取待办事项-返回404-对于无效的Todo")]
        public async Task GetTodo_ReturnHttpNotFound_ForInvalidTodo()
        {
            // Arrange
            int todoId = 99;
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(repo => repo.GetAsync(todoId))
                .ReturnsAsync((TodoItem)null);
            var controller = new TodoController(mockRepo.Object);

            // Act
            var result = await controller.GetTodoItem(todoId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(todoId, notFoundObjectResult.Value);
        }
    }
}
