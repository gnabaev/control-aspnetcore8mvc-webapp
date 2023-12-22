namespace Control.Web.Models
{
    public interface IIssuesService
    {
        List<Issue> GetIssuesByProjectId(int projectId);

        Issue GetIssueByProjectIdAndId(int projectId, int id);

        void AddIssue(IssueViewModel projectVM);

        void EditIssue(IssueViewModel projectVM);

        IssueDropdownsViewModel GetIssueDropdowns();
    }
}
