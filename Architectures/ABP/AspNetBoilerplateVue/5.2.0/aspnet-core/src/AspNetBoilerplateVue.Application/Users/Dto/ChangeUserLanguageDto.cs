using System.ComponentModel.DataAnnotations;

namespace AspNetBoilerplateVue.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}