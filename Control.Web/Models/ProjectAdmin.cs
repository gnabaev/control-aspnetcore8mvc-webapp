using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control.Web.Models
{
    public class ProjectAdmin
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
