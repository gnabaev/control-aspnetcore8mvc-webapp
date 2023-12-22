namespace Control.Web.Models
{
	public interface IProjectsService
	{
		List<Project> GetProjects();

		Project GetProjectById(int id);

		void AddProject(ProjectViewModel projectVM);

		void EditProject(ProjectViewModel projectVM);

        ProjectDropdownsViewModel GetProjectDropdowns();
    }
}
