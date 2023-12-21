namespace Control.Web.Models
{
	public class ProjectsService : IProjectsService
	{
		private readonly AppDbContext _context;

		public ProjectsService(AppDbContext context)
		{
			_context = context;
		}

		public List<Project> GetProjects()
		{
			return _context.Projects.ToList();
		}
	}
}
