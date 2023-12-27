using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control.Web.Models
{
    public class IssueViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Наименование должно содержать от 2 до 500 символов")]
        public required string Name { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Описание должно содержать от 2 до 500 символов")]
        public string? Description { get; set; }

        [Display(Name = "Раздел")]
		[Required(ErrorMessage = "Обязательное поле")]
		public IssueDiscipline Discipline { get; set; }

        [Display(Name = "Статус")]
		[Required(ErrorMessage = "Обязательное поле")]
		public IssueStatus Status { get; set; }

        [Display(Name = "Проект")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required int ProjectId { get; set; }

        [Display(Name = "Создатель")]
        public string? CreatorId { get; set; }

        [Display(Name = "Исполнитель")]
        public string? ExecutorId { get; set; }
    }
}
