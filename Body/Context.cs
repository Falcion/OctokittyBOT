using System;
using System.Linq;
using Octokit;

namespace Stratum.Body
{
    public static class Context
    {
        public static RepositoryIssueRequest getIssueRequest(IssueFilter filter, string[]? issueParams)
        {
            /*
                An array of Issue parameters for the next call to the GitHub API (issueParams).
                In the appropriate order: issue's creator, issue's mentioned, issue's assignee, issue's milestone.
             */

            return new RepositoryIssueRequest()
            {
                Filter = filter,

                Creator   = issueParams[0],
                Mentioned = issueParams[1],
                Assignee  = issueParams[2],
                Milestone = issueParams[3]
            };
        }

        public static CommitRequest getCommitRequest(DateTime[]? dateParams, string[]? commitParams)
        {

            /*
                An array of Issue parameters for the next call to the GitHub API (dateParams).
                In the appropriate order:, until date, since date.
             */

            /*
                An array of Issue parameters for the next call to the GitHub API (commitParams).
                In the appropriate order: commit's author, commit's path, commit's SHA.
             */

            return new CommitRequest()
            {
                Author = commitParams[0],
                Path   = commitParams[1],
                Sha    = commitParams[2],

                Until  = dateParams[0],
                Since  = dateParams[1]
            };
        }
    }
}
