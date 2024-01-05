using Microsoft.AspNetCore.Identity;

namespace Control.Web.Models
{
	public class User : IdentityUser
	{
		public required string Name { get; set; }

		public required string Surname { get; set; }

		public string FullName
		{
			get
			{
				return $"{Surname} {Name}";
			}
		}

        // Реляционные отношения
        public List<UserProject>? UserProjects { get; set; } = new List<UserProject>();

		public List<IssueComment> IssueComments { get; set; } = new List<IssueComment>();
    }
}
