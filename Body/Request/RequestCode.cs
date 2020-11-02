using System;

using Octokit;

namespace Stratum.Body.Request
{
    public static class RequestCode
    {
        public static SearchCodeRequest getSearchCode(string? FileName, string? Path, string? User, string? owner, string? name, Language Language, bool? Forks, Octokit.Range Size)
        {
            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: filename, path, user, repository's owner, repository's name.
             */

            return new SearchCodeRequest("auth", owner, name)
            {
                In = new[] { CodeInQualifier.File, CodeInQualifier.Path },

                FileName = FileName,
                Path = Path,

                User = User,

                Language = Language,

                Forks = Forks,

                Size = Size
            };
        }
    }
}
