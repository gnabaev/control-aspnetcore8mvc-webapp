using Control.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace Control.Web.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService _service;

		public IssuesController(IIssuesService service)
		{
			_service = service;
		}

		public IActionResult Index(int projectId)
        {
            var projectIssues = _service.GetIssuesByProjectId(projectId);

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
            var projectIssue = _service.GetIssueByProjectIdAndId(projectId, id);

            if (projectIssue == null)
            {
                return View("IssueNotFound");
            }

            return View(projectIssue);
        }

        public IActionResult Add(int projectId)
        {
            var dropdowns = _service.GetIssueDropdowns();
            ViewBag.Users = new SelectList(dropdowns.Users, "Id", "Fullname");
            ViewBag.Projects = new SelectList(dropdowns.Projects, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Add(int projectId, IssueViewModel issueVM)
        {
            _service.AddIssue(projectId, issueVM);

            return RedirectToAction(nameof(Index), new { projectId });
        }

        public IActionResult Edit(int projectId, int id)
        {
            var issueDb = _service.GetIssueByProjectIdAndId(projectId, id);

			if (issueDb == null)
            {
                return View("IssueNotFound");
            }

            var issueVM = new IssueViewModel
            {
                Id = issueDb.Id,
                Name = issueDb.Name,
                Description = issueDb.Description,
                Status = issueDb.Status,
                Discipline = issueDb.Discipline,
                ProjectId = issueDb.ProjectId,
                CreatorId = issueDb.CreatorId,
                ExecutorId = issueDb.ExecutorId,
            };

            var dropdowns = _service.GetIssueDropdowns();
            ViewBag.Users = new SelectList(dropdowns.Users, "Id", "Fullname");
			ViewBag.Projects = new SelectList(dropdowns.Projects, "Id", "Name");

			return View(issueVM);
        }

        [HttpPost]
        public IActionResult Edit(int projectId, int id, IssueViewModel issueVM)
        {
            var issueDb = _service.GetIssueByProjectIdAndId(projectId, id);

            if (issueDb == null)
            {
                return View("IssueNotFound");
            }

            _service.EditIssue(projectId, issueVM);

			return RedirectToAction(nameof(Index), new { projectId });
		}
	}
}
