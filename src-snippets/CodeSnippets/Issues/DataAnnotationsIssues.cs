using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeSnippets.Issues
{
    public class DataAnnotationsIssues
    {
        public static void Run()
        {
            DataAnnotationsIssuesClass c1 = new DataAnnotationsIssuesClass();
            c1.ID = 1;
            c1.Name = "aaaa";
            c1.RegDateTime = DateTime.Now;
            c1.Status = 1;
            c1.IsDelete = false;

            var errors = new List<ValidationResult>();
            var success = Validator.TryValidateObject(c1, new ValidationContext(c1, null, null), errors, true);
            Console.WriteLine(success);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }
    }

    public class DataAnnotationsIssuesClass
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(3)]
        public string Name { get; set; }
        public DateTime RegDateTime { get; set; }
        public byte Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
