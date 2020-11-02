using System;

using Octokit;

namespace Stratum.Body.Request
{
    public static class RequestUser
    {
        public static SearchUsersRequest getSearchUser(Octokit.Range Followers, Octokit.Range Repositories, DateRange Created, Language Language, AccountSearchType AccountType, string? Location, string? Username, string? Email, string? Fullname)
        {
            /*
                An array of User parameters for the next call to the GitHub API.
                In the appropriate order: followers, repositories.
             */

            /*
                An array of User parameters for the next call to the GitHub API.
                In the appropriate order: user's location, username, user's email, user's fullname.
             */

            return new SearchUsersRequest(Username)
            {
                Followers = Followers,
                Repositories = Repositories,

                Created = Created,

                Language = Language,

                AccountType = AccountType,

                Location = Location,

                In = new[] { UserInQualifier.Username, UserInQualifier.Email }
            };
        }
    }
}
