using System.ComponentModel.DataAnnotations;

namespace AspNetBoilerplate.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}