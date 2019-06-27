using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.Entities
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 0:未完成,1:已完成.
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
