using Sample.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public static class FakeDatasHelper
    {
        public static List<TodoItem> GetTestTodos()
        {
            List<TodoItem> todos = new List<TodoItem>();
            var todo1 = new TodoItem()
            {
                ID = 1,
                Name = "测试1",
                IsComplete = false,
                CreateTime = DateTimeOffset.Now,
                ModifyTime = DateTimeOffset.Now,
            };
            var todo2 = new TodoItem()
            {
                ID = 2,
                Name = "测试2",
                IsComplete = true,
                CreateTime = DateTimeOffset.Now,
                ModifyTime = DateTimeOffset.Now,
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
    }
}
