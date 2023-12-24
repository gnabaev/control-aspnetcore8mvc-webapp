using Control.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace Control.Web.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService _issueService;
        private readonly IProjectsService _projectsService;

		public IssuesController(IIssuesService service, IProjectsService projectsService)
		{
			_issueService = service;
			_projectsService = projectsService;
		}

		public IActionResult Index(int projectId)
        {
            var projectIssues = _issueService.GetIssuesByProjectId(projectId);

            // Для кнопки Добавить, так как невозможно получить имя проекта из любого замечания, если их еще нет в данном проекте.
            ViewBag.ProjectId = projectId;

			if (projectIssues == null)
            {
                return View("IssueNotFound");
            }

            return View(projectIssues);
        }

        public IActionResult Details(int projectId, int id)
        {
            var projectIssue = _issueService.GetIssueByProjectIdAndId(projectId, id);

            if (projectIssue == null)
            {
                return View("IssueNotFound");
            }

            return View(projectIssue);
        }

        public IActionResult Add(int projectId)
        {
            var dropdowns = _issueService.GetIssueDropdowns();
            ViewBag.Users = new SelectList(dropdowns.Users, "Id", "Fullname");
            ViewBag.Projects = new SelectList(dropdowns.Projects, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Add(int projectId, IssueViewModel issueVM)
        {
            _issueService.AddIssue(projectId, issueVM);

            return RedirectToAction(nameof(Index), new { projectId });
        }

        //public IActionResult Edit(int id)
        //{
        //    var projectDb = _service.GetProjectById(id);

        //    if (projectDb == null)
        //    {
        //        return View("ProjectNotFound");
        //    }

        //    var projectVM = new ProjectViewModel
        //    {
        //        Id = projectDb.Id,
        //        Name = projectDb.Name,
        //        Description = projectDb.Description,
        //        Status = projectDb.Status,
        //        UserIds = projectDb.UserProjects.Select(up => up.UserId).ToList()
        //    };

        //    var userDropdown = _service.GetProjectDropdowns();
        //    ViewBag.Users = new SelectList(userDropdown.Users, "Id", "Fullname");

        //    return View(projectVM);
        //}

        //[HttpPost]
        //public IActionResult Edit(int id, ProjectViewModel projectVM)
        //{
        //    var projectDb = _service.GetProjectById(id);

        //    if (projectDb == null)
        //    {
        //        return View("ProjectNotFound");
        //    }

        //    _service.EditProject(projectVM);

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
