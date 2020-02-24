using CodeSnippets.Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using CodeSnippets.WebApi.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CodeSnippets.Infrastructure.Entities;
using CodeSnippets.WebApi.Interfaces;

namespace CodeSnippets.WebApi.UnitTests
{
    [TestClass]
    public class SampleControllerTest
    {
        //[TestMethod]
        //public async Task GetShouldSuccess()
        //{
        //    // Arrange
        //    var dbContext = await GetSqliteDbContextAsync();
        //    var loggerMoq = new Mock<ILogger<SampleController>>();
        //    var logger = loggerMoq.Object;
        //    var controller = new SampleController(dbContext, logger);

        //    // Act
        //    var response = await controller.Get(1);

        //    // Assert
        //    // Assert.IsInstanceOfType(response, typeof(OkObjectResult));

        //    // Use FluentValidation Instead Assert
        //    var result = response.Should().BeOfType<OkObjectResult>().Subject;
        //    var sampleData = result.Value.Should().BeAssignableTo<SampleEntity>().Subject;
        //    sampleData.Id.Should().Be(1);
        //    sampleData.BoolValue.Should().BeFalse();
        //    sampleData.StringValue.Should().Be("sample");
        //}

        //[TestMethod]
        //public async Task Get_ReturnOK_WithExpectedParameters()
        //{
        //    // Arrange
        //    var dbContext = await GetSqliteDbContextAsync();
        //    var loggerMock = new Mock<ILogger<SampleController>>();
        //    var controller = new SampleController(dbContext, loggerMock.Object);

        //    // Act
        //    var response = await controller.Get(1);
        //    var responseModel = ((OkObjectResult)response).Value as SampleEntity;

        //    // Assert
        //    Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        //    Assert.IsTrue(responseModel.Id == 1);
        //    Assert.IsFalse(responseModel.BoolValue);
        //    Assert.IsTrue(responseModel.StringValue == "sample");
        //}

        [TestMethod]
        public async Task Get_ReturnOK_WithPingFalse()
        {
            // Arrange
            var dbContext = await GetSqliteDbContextAsync();

            var loggerMock = new Mock<ILogger<SampleController>>();
            var logger = loggerMock.Object;

            var fooMock = new Mock<IFoo>();
            fooMock.Setup(foo => foo.Ping("localhost")).Returns(false);
            var foo = fooMock.Object;

            var controller = new SampleController(dbContext, logger, foo);

            // Act
            var response = await controller.Get(2);

            // Assert
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Get_ReturnOK_WithPingTrue()
        {
            // Arrange
            var dbContext = await GetSqliteDbContextAsync();

            var loggerMock = new Mock<ILogger<SampleController>>();
            var logger = loggerMock.Object;

            var fooMock = new Mock<IFoo>();
            fooMock.Setup(foo => foo.Ping("localhost")).Returns(true);
            var foo = fooMock.Object;

            var controller = new SampleController(dbContext, logger, foo);

            // Act
            var response = await controller.Get(2);
            var responseModel = ((OkObjectResult)response).Value as SampleEntity;

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.IsTrue(responseModel.Id == 2);
            Assert.IsFalse(responseModel.BoolValue);
            Assert.IsTrue(responseModel.StringValue == "ping");
        }

        [TestMethod]
        public async Task Get_ReturnOK_WithPingTrue_UsingFluentAssertions()
        {
            // Arrange
            var dbContext = await GetSqliteDbContextAsync();

            var loggerMock = new Mock<ILogger<SampleController>>();
            var logger = loggerMock.Object;

            var fooMock = new Mock<IFoo>();
            fooMock.Setup(foo => foo.Ping("localhost")).Returns(true);
            var foo = fooMock.Object;

            var controller = new SampleController(dbContext, logger, foo);

            // Act
            var response = await controller.Get(2);

            // Assert
            var result = response.Should().BeOfType<OkObjectResult>().Subject;
            var sampleData = result.Value.Should().BeAssignableTo<SampleEntity>().Subject;
            sampleData.Id.Should().Be(2);
            sampleData.BoolValue.Should().BeFalse();
            sampleData.StringValue.Should().Be("ping");
        }

        private async Task<SqliteDbContext> GetSqliteDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<SqliteDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var sqliteDbContext = new SqliteDbContext(options);
            sqliteDbContext.SampleEntity.Add(new Infrastructure.Entities.SampleEntity
            {
                Id = 1,
                BoolValue = false,
                DateTimeValue = DateTime.Now,
                StringValue = "sample"
            });

            sqliteDbContext.SampleEntity.Add(new Infrastructure.Entities.SampleEntity
            {
                Id = 2,
                BoolValue = false,
                DateTimeValue = DateTime.Now,
                StringValue = "ping"
            });
            await sqliteDbContext.SaveChangesAsync();
            return sqliteDbContext;
        }
    }
}
