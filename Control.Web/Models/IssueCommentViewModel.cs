using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control.Web.Models
{
    public class IssueCommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Комментарий должен содержать от 1 до 1000 символов")]
        public required string Text { get; set; }

        public required int IssueId { get; set; }
    }
}
