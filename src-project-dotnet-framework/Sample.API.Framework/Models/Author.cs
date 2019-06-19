using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.API.Framework.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
