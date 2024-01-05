using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public IssueDiscipline Discipline { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime? CompletionDateTime { get; set; }

        public IssueStatus Status { get; set; }

        // Реляционные отношения
        public required int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }

        public string? CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User? Creator { get; set; }

        public string? ExecutorId { get; set; }

        [ForeignKey(nameof(ExecutorId))]
        public User? Executor { get; set; }

        public List<IssueComment> IssueComments { get; set; } = new List<IssueComment>();
    }
}
