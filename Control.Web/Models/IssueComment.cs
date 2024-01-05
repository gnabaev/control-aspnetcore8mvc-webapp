using System.ComponentModel.DataAnnotations.Schema;

namespace Control.Web.Models
{
    public class IssueComment
    {
        public int Id { get; set; }

        public required string Text { get; set; }

        public DateTime Date { get; set; }

        // Реляционные отношения
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required User User { get; set; }

        public required int IssueId { get; set; }

        [ForeignKey(nameof(IssueId))]
        public required Issue Issue { get; set; }
    }
}
