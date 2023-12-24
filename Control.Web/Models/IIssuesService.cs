﻿namespace Control.Web.Models
{
    public interface IIssuesService
    {
        List<Issue> GetIssuesByProjectId(int projectId);

        Issue GetIssueByProjectIdAndId(int projectId, int id);

        void AddIssue(int projectId, IssueViewModel issueVM);

        void EditIssue(IssueViewModel issueVM);

        IssueDropdownsViewModel GetIssueDropdowns();
    }
}
