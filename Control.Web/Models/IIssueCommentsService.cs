namespace Control.Web.Models
{
    public interface IIssueCommentsService
    {
        void AddComment(string userId, IssueCommentViewModel issueCommentVM);
    }
}
