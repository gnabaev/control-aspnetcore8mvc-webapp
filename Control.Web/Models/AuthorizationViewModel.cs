using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class AuthorizationViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string? UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
