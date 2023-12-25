using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class RegistrationViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required string Surname { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "Потверждение пароля")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают!")]
        public required string ConfirmedPassword { get; set; }
    }
}
