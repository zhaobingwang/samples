using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeSnippets.Infrastructure.Entities
{
    public class Blog
    {
        public int id { get; set; }
        public string url { get; set; }
    }
}
