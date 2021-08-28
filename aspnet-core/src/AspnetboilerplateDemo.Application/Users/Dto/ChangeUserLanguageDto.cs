using System.ComponentModel.DataAnnotations;

namespace AspnetboilerplateDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}