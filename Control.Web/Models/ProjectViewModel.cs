using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class ProjectViewModel
    {
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Пользователи")]
        public List<string>? UserIds { get; set; }
    }
}