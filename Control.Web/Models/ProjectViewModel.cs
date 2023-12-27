using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class ProjectViewModel
    {
		public int Id { get; set; }

		[Display(Name = "Наименование")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Наименование должно содержать от 2 до 500 символов")]
        public required string Name { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Описание должно содержать от 2 до 500 символов")]
        public string? Description { get; set; }

        [Display(Name = "Статус")]
		[Required(ErrorMessage = "Обязательное поле")]
		public ProjectStatus Status { get; set; }

        [Display(Name = "Пользователи")]
        public List<string>? UserIds { get; set; }
    }
}