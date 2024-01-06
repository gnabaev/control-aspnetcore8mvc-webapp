using Control.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Control.Web.Controllers
{
    public class IssueCommentsController : Controller
    {
        private readonly IIssueCommentsService _service;
        private readonly IHttpContextAccessor _contextAccessor;

        public IssueCommentsController(IIssueCommentsService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        public IActionResult Add(int projectId, int id, IssueCommentViewModel issueCommentVM)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _service.AddComment(userId, issueCommentVM);

            return RedirectToAction("Details", "Issues", new { projectId, id });
        }
    }
}
