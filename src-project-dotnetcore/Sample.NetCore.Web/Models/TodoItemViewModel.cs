using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.NetCore.Web.Models
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public bool IsComplete { get; set; }
        public int StepCount { get; set; }
    }
}
