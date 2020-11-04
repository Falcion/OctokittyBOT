using System;

using Octokit;

namespace Stratum.Body.Request
{
    public static class EnumCommit
    {
        public static CommitRequest getCommitRequest(DateTime? Until, DateTime? Since, string? Author, string? Path, string? Sha)
        {
            /*
                An array of Commit parameters for the next call to the GitHub API (dateParams).
                In the appropriate order:, until date, since date.
             */

            /*
                An array of Commit parameters for the next call to the GitHub API (commitParams).
                In the appropriate order: commit's author, commit's path, commit's SHA.
             */

            return new CommitRequest()
            {
                Author = Author,
                Path = Path,
                Sha = Sha,

                Until = Until,
                Since = Since
            };
        }
    }
}
