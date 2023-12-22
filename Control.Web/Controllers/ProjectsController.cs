using Control.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

		public IActionResult Add()
		{
			var userDropdown = _service.GetProjectDropdowns();

			ViewBag.Users = new SelectList(userDropdown.Users, "Id", "Fullname");
			ViewBag.UserAdmins = new SelectList(userDropdown.Users, "Id", "Fullname");

            return View();
		}

		[HttpPost]
		public IActionResult Add(ProjectViewModel projectVM)
		{
			_service.AddProject(projectVM);

			return RedirectToAction(nameof(Index));
		}
	}
}
