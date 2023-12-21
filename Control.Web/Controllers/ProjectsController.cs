using Control.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Control.Web.Controllers
{
	public class ProjectsController : Controller
	{
		private readonly IProjectsService _service;

        public ProjectsController(IProjectsService service)
        {
			_service = service;
        }

        public IActionResult Index()
		{
			var projects = _service.GetProjects();

			if (projects == null)
			{
				return View("ProjectNotFound");
			}

			return View(projects);
		}
	}
}
