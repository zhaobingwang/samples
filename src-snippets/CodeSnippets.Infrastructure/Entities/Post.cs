using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeSnippets.Infrastructure.Entities
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        public int blog_Id { get; set; }
    }
}
