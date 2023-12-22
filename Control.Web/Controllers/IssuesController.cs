using Control.Web.Models;
using Microsoft.AspNetCore.Mvc;

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

            if (projectIssues == null)
            {
                return View("IssueNotFound");
            }

            return View(projectIssues);
        }
    }
}
