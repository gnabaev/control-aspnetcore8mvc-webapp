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

            return View();
		}

		[HttpPost]
		public IActionResult Add(ProjectViewModel projectVM)
		{
			_service.AddProject(projectVM);

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			var projectDb = _service.GetProjectById(id);

            if (projectDb == null)
            {
                return View("ProjectNotFound");
            }

			var projectVM = new ProjectViewModel
			{
				Id = projectDb.Id,
				Name = projectDb.Name,
				Description = projectDb.Description,
				Status = projectDb.Status,
				UserIds = projectDb.UserProjects.Select(up => up.UserId).ToList()
			};

            var userDropdown = _service.GetProjectDropdowns();
            ViewBag.Users = new SelectList(userDropdown.Users, "Id", "Fullname");

			return View(projectVM);
        }

		[HttpPost]
        public IActionResult Edit(int id, ProjectViewModel projectVM)
        {
			var projectDb = _service.GetProjectById(id);

			if (projectDb == null)
			{
				return View("ProjectNotFound");
			}

			_service.EditProject(projectVM);

			return RedirectToAction(nameof(Index));
        }
    }
}
