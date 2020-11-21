using System;

using Octokit;

namespace Stagnum.Core.Request
{
    public static class EnumIssue
    {

        public static RepositoryIssueRequest getIssueRequest(IssueFilter Filter, string? Creator, string? Mentioned, string? Assignee, string? Milestone)
        {
            /*
                An array of Issue parameters for the next call to the GitHub API (issueParams).
                In the appropriate order: issue's creator, issue's mentioned, issue's assignee, issue's milestone.
             */

            return new RepositoryIssueRequest()
            {
                Filter = Filter,

                Creator = Creator,
                Mentioned = Mentioned,
                Assignee = Assignee,
                Milestone = Milestone
            };
        }
    }
}
