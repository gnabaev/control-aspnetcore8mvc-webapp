namespace Control.Web.Models
{
    public class IssueCommentsService : IIssueCommentsService
    {
        private readonly AppDbContext _context;

        public IssueCommentsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddComment(string userId, IssueCommentViewModel issueCommentVM)
        {
            var issueCommentDb = new IssueComment()
            {
                Text = issueCommentVM.Text,
                Date = DateTime.Now,
                UserId = userId,
                IssueId = issueCommentVM.IssueId
            };

            _context.IssueComments.Add(issueCommentDb);
            _context.SaveChanges();
        }
    }
}
