using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class ProjectViewModel
    {
		public int Id { get; set; }

		[Display(Name = "Наименование")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Статус")]
        public ProjectStatus Status { get; set; }

        [Display(Name = "Пользователи")]
        public List<string>? UserIds { get; set; }
    }
}