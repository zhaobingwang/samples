using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.WebMvc.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }
        public string Avatar { get; set; }
    }
}
