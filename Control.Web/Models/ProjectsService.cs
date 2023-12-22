using Microsoft.EntityFrameworkCore;

namespace Control.Web.Models
{
	public class ProjectsService : IProjectsService
	{
		private readonly AppDbContext _context;

		public ProjectsService(AppDbContext context)
		{
			_context = context;
		}

		public void AddProject(ProjectViewModel projectVM)
		{
			var projectDb = new Project()
			{
				Name = projectVM.Name,
				Description = projectVM.Description,
				CreationDateTime = DateTime.Now,
				Status = ProjectStatus.Created,
			};

			_context.Projects.Add(projectDb);
			_context.SaveChanges();

			if (projectVM.UserIds != null)
			{
				foreach (var userId in projectVM.UserIds)
				{
					var userProject = new UserProject()
					{
						ProjectId = projectDb.Id,
						UserId = userId
					};

					_context.UserProjects.Add(userProject);
				}

				_context.SaveChanges();
			}
		}

		public ProjectDropdownsViewModel GetProjectDropdowns()
		{
			var projectDropdownVM = new ProjectDropdownsViewModel();

			projectDropdownVM.Users = _context.Users.ToList();

			return projectDropdownVM;
		}

		public List<Project> GetProjects()
		{
			return _context.Projects.Include(p => p.UserProjects).ThenInclude(p => p.User).ToList();
		}
	}
}
