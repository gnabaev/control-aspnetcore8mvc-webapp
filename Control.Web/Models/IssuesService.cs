
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Control.Web.Models
{
    public class IssuesService : IIssuesService
    {
        private readonly AppDbContext _context;

        public IssuesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddIssue(IssueViewModel projectVM)
        {
            throw new NotImplementedException();
        }

        public void EditIssue(IssueViewModel projectVM)
        {
            throw new NotImplementedException();
        }

        public Issue GetIssueByProjectIdAndId(int projectId, int id)
        {
            throw new NotImplementedException();
        }

        public IssueDropdownsViewModel GetIssueDropdowns()
        {
            throw new NotImplementedException();
        }

        public List<Issue> GetIssuesByProjectId(int projectId)
        {
            return _context.Issues.Where(p => p.ProjectId == projectId).Include(p => p.Project).Include(i => i.Creator).Include(i => i.Executor).ToList();

        }
    }
}
