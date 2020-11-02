using System;

using Octokit;

namespace Stratum.Body.Request
{
    public static class RequestRepos
    {
        public static SearchRepositoriesRequest getSearchRepos(Octokit.Range Stars, Octokit.Range Size, Octokit.Range Forks, ForkQualifier ForkQualifier, Language Language, DateRange Created, DateRange Updated, string? User, string? name, bool? Readme, bool? Description)
        {
            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: stars count, size range (kilobytes), forks count.
             */

            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: repository's owner, repository's name.
             */

            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: README, description.
             */

            return new SearchRepositoriesRequest(name)
            {
               Stars = Stars,
               Size = Size,
               Forks = Forks,

               Fork = ForkQualifier,

               Language = Language,

               Created = Created,
               Updated = Updated,

               User = User,

               In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },
            };
        }
    }
}
