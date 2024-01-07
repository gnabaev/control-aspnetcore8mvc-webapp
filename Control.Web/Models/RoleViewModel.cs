using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Наименование роли должно содержать от 2 до 50 символов")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }
    }
}
