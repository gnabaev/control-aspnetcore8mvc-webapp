namespace Control.Web.Models
{
	public interface IProjectsService
	{
		List<Project> GetProjects();

		void AddProject(ProjectViewModel projectVM);

        ProjectDropdownsViewModel GetProjectDropdowns();
    }
}
