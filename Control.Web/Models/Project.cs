using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
	public class Project
	{
		[Key]
		public int Id { get; set; }

		public required string Name { get; set; }

		public string? Description { get; set; }

		public DateTime CreationDateTime { get; set; }

		public ProjectStatus Status { get; set; }

		// Реляционные отношения
		public string? AdminId { get; set; }

		[ForeignKey(nameof(AdminId))]
		public User? Admin { get; set; }

		public List<User>? Users { get; set; }
	}
}
