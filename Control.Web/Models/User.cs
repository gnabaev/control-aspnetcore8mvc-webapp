using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
	public class User
	{
		[Key]
		public required string Id { get; set; }

		public required string Name { get; set; }

		public required string Surname { get; set; }

		public string Fullname
		{
			get
			{
				return $"{Surname} {Name}";
			}
		}

		// Реляционные отношения
		public List<Project>? Projects { get; set; } = new List<Project>();
	}
}
