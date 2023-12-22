using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control.Web.Models
{
    public class IssueViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Обязательное поле")]
        public required string Name { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }

        [Display(Name = "Статус")]
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
