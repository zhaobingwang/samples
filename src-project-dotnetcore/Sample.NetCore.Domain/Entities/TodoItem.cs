using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.NetCore.Domain.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }

        public List<TodoItemStep> Steps { get; } = new List<TodoItemStep>();
        public void AddStep(TodoItemStep step)
        {
            Steps.Add(step);
        }
    }

    public class TodoItemStep : BaseEntity
    {
        public byte Index { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
