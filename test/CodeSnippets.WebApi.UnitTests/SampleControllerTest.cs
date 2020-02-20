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

namespace CodeSnippets.WebApi.UnitTests
{
    [TestClass]
    public class SampleControllerTest
    {
        [TestMethod]
        public async Task GetShouldSuccess()
        {
            // Arrange
            var dbContext = await GetSqliteDbContextAsync();
            var loggerMoq = new Mock<ILogger<SampleController>>();
            var logger = loggerMoq.Object;
            var controller = new SampleController(dbContext, logger);

            // Act
            var response = await controller.Get(1);

            // Assert
            // Assert.IsInstanceOfType(response, typeof(OkObjectResult));

            // Use FluentValidation Instead Assert
            var result = response.Should().BeOfType<OkObjectResult>().Subject;
            var sampleData = result.Value.Should().BeAssignableTo<SampleEntity>().Subject;
            sampleData.Id.Should().Be(1);
            sampleData.BoolValue.Should().BeFalse();
            sampleData.StringValue.Should().Be("sample");
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
            await sqliteDbContext.SaveChangesAsync();
            return sqliteDbContext;
        }
    }
}
