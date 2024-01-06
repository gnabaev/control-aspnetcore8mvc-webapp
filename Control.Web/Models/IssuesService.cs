using Microsoft.EntityFrameworkCore;

namespace Control.Web.Models
{
    public class IssuesService : IIssuesService
    {
        private readonly AppDbContext _context;

        public IssuesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddIssue(int projectId, IssueViewModel issueVM)
        {
            var issueDb = new Issue()
            {
                Name = issueVM.Name,
                Description = issueVM.Description,
                Discipline = issueVM.Discipline,
                CreationDateTime = DateTime.Now,
                Status = issueVM.Status,
                ProjectId = projectId,
                CreatorId = issueVM.CreatorId,
                ExecutorId = issueVM.ExecutorId
            };

            _context.Issues.Add(issueDb);
            _context.SaveChanges();
        }

        public void EditIssue(int projectId, IssueViewModel issueVM)
        {
			var issueDb = _context.Issues.FirstOrDefault(i => i.Id == issueVM.Id);

			if (issueDb != null)
			{
				issueDb.Name = issueVM.Name;
				issueDb.Description = issueVM.Description;
                issueDb.Discipline = issueVM.Discipline;
				issueDb.Status = issueVM.Status;
                issueDb.ProjectId = projectId;
                issueDb.CreatorId = issueVM.CreatorId;
                issueDb.ExecutorId = issueVM.ExecutorId;

				_context.SaveChanges();

				if (issueDb.Status == IssueStatus.Fixed)
				{
					issueDb.CompletionDateTime = DateTime.Now;

					_context.SaveChanges();
				}
			}
		}

        public Issue GetIssueByProjectIdAndId(int projectId, int id)
        {
            return _context.Issues.Where(i => i.ProjectId == projectId).Include(i => i.Project).Include(i => i.Creator).Include(i => i.Executor).Include(i => i.IssueComments).FirstOrDefault(i => i.Id == id);
        }

        public IssueDropdownsViewModel GetIssueDropdowns()
        {
            var issueDropdownVM = new IssueDropdownsViewModel();

            issueDropdownVM.Users = _context.Users.ToList();
            issueDropdownVM.Projects = _context.Projects.ToList();

            return issueDropdownVM;
        }

        public List<Issue> GetIssuesByProjectId(int projectId)
        {
            return _context.Issues.Where(i => i.ProjectId == projectId).Include(i => i.Project).Include(i => i.Creator).Include(i => i.Executor).ToList();
        }
    }
}
