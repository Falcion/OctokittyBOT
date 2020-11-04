using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

using Octokit;

using Stratum.Body;
using Stratum.Body.Request;
using Stratum.Body.Parser;

namespace Stratum.Core
{
    public class Head : ModuleBase<SocketCommandContext>
    {
        /*
            The advanced commands for requests to the GitHub API.
            Detailed information about each can be found in the comments before the task itself.
         */

        /*
            Command: issue@array
            Task: Get a list of all issues in the specified repository.
            Arguments: repository's owner, repository's name, page number, filters syntax.
         */

        [Command("issue@array")]

        public async Task IssueArray(string? owner, string? name, int page = 0, [Remainder]string? syntax = "none")
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            /*
                Checking the syntax of filters at the time of their existence.
                At least one element so that the code does not break.
             */

            if (syntax == "none")
            {
                Logger.Error("Wrong command syntax format!");
                return;
            }

            string[] filterArray = syntax.Split(',');

            IssueFilter issueFilter = new IssueFilter();

            /*
                An array of Issue parameters for the next call to the GitHub API.
                In the appropriate order: issue's creator, issue's mentioned, issue's assignee, issue's milestone.
             */

            string[] IssueParams = new string[] { "none", "none", "none", "none" };

            /* 
                Insert a space into elements of the array and implementing it to lower case.
                It's necessary to avoid additional conditions in the "for" loop when checking filters.           
             */

            for (int _B90D = 0; _B90D < filterArray.Length; _B90D++)
            {
                filterArray[_B90D] = filterArray[_B90D].ToLower();

                if (!filterArray[_B90D].StartsWith(" ")) filterArray[_B90D].Insert(0, " ");
            }

            for (int i = 0; i < filterArray.Length; i++)
            {
                /*
                    We pass the raw string through the handler and parse it into the finished variable.
                    For detailed comments go to the specified class.
                 */

                if (filterArray[i].StartsWith(" issue@filter: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 16);

                    issueFilter = IssueEnum.getIssueFilter(filterArray[i]);
                }

                /* Processing of simple elements. */

                if (filterArray[i].StartsWith(" creator: ")) 
                    IssueParams[0] = filterArray[i].Remove(0, 10);

                if (filterArray[i].StartsWith(" mentioned: ")) 
                    IssueParams[1] = filterArray[i].Remove(0, 12);

                if (filterArray[i].StartsWith(" assignee: ")) 
                    IssueParams[2] = filterArray[i].Remove(0, 11);

                if (filterArray[i].StartsWith(" milestone: ")) 
                    IssueParams[3] = filterArray[i].Remove(0, 12);
            }

            /* Calling (parsing) RepositoryIssueRequest from special class. */

            RepositoryIssueRequest issueRequest = EnumIssue.getIssueRequest(issueFilter, IssueParams[0], IssueParams[1], IssueParams[2], IssueParams[3]);

            EmbedBuilder embed = new EmbedBuilder();

            IReadOnlyList<Issue> issues = await git.Issue.GetAllForRepository(owner, name, issueRequest);

            /*
                Fixing page counter, so user can type 1 or 0 and that will be equals as 0.
                In other words, we transfer the usual number system to the number system of arrays.
             */

            if (page > 0) page--;
            if (page < 0) page = 0;

            uint encounter = 0;

            embed.WithTitle("Repository's Issues")
                 .WithColor(Color.Blue)
                 .WithFooter(footer => footer.Text = $"Page: {page}");

            for(int i = 0 + 25 * page; i < issues.Count; i++)
            {
                /*
                    Discord API doesn't allow you to create EmbedMessage with more than 25 fields.
                    See https://discord.com/developers/docs/resources/channel#embed-limits-limits
                 */

                encounter++;
                if (encounter >= 25) break;

                embed.AddField($"Issue (#{issues[i].Number}):", issues[i].Title);
            }

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: commit@array
            Task: Get a list of all commits in the specified repository.
            Arguments: repository's owner, repository's name, page number, filters syntax.
         */

        [Command("commit@array")]

        public async Task CommitArray(string? owner, string? name, int page = 0, [Remainder]string? syntax = "none")
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            /*
               Checking the syntax of filters at the time of their existence.
               At least one element so that the code does not break.
            */

            if (syntax == "none")
            {
                Logger.Error("Wrong command syntax format!");
                return;
            }

            string[] filterArray = syntax.Split(',');

            /*
                An array of Commit parameters for the next call to the GitHub API.
                In the appropriate order: until date, since date.
             */

            DateTime[] DateParams = new DateTime[] { DateTime.Now, new DateTime(1999, 10, 1) };

            /*
                An array of Commit parameters for the next call to the GitHub API.
                In the appropriate order: commit's author, commit's path, commit's SHA.
             */

            string[] CommitParams = new string[] { "none", "none", "none" };

            /* 
                Insert a space into elements of the array and implementing it to lower case.
                It's necessary to avoid additional conditions in the "for" loop when checking filters.           
             */

            for (int _B90D = 0; _B90D < filterArray.Length; _B90D++)
            {
                filterArray[_B90D] = filterArray[_B90D].ToLower();

                if (!filterArray[_B90D].StartsWith(" ")) filterArray[_B90D].Insert(0, " ");
            }

            for (int i = 0; i < filterArray.Length; i++)
            {
                /*
                    We pass the raw string through the handler and parse it into the finished variable.
                    For detailed comments go to the specified class.
                 */

                if (filterArray[i].StartsWith(" until: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 8);

                    DateParams[1] = DateTime.Parse(filterArray[i]);
                }

                if (filterArray[i].StartsWith(" since: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 8);

                    DateParams[2] = DateTime.Parse(filterArray[i]);
                }

                /* Processing of simple elements. */

                if (filterArray[i].StartsWith(" author: "))
                    CommitParams[0] = filterArray[i].Remove(0, 9);

                if (filterArray[i].StartsWith(" path: "))
                    CommitParams[1] = filterArray[i].Remove(0, 7);

                if (filterArray[i].StartsWith(" sha: "))
                    CommitParams[2] = filterArray[i].Remove(0, 6);
            }

            /* Calling (parsing) CommitRequest from special class. */

            CommitRequest commitRequest = EnumCommit.getCommitRequest(DateParams[0], DateParams[1], CommitParams[0], CommitParams[1], CommitParams[2]);

            EmbedBuilder embed = new EmbedBuilder();

            IReadOnlyList<GitHubCommit> commits = await git.Repository.Commit.GetAll(owner, name, commitRequest);

            /*
                Fixing page counter, so user can type 1 or 0 and that will be equals as 0.
                In other words, we transfer the usual number system to the number system of arrays.
             */

            if (page > 0) page--;
            if (page < 0) page = 0;

            uint encounter = 0;

            embed.WithTitle("Repository's Commits")
                 .WithColor(Color.Blue)
                 .WithFooter(footer => footer.Text = $"Page: {page}");

            for (int i = 0 + 25 * page; i < commits.Count; i++)
            {
                /*
                    Discord API doesn't allow you to create EmbedMessage with more than 25 fields.
                    See https://discord.com/developers/docs/resources/channel#embed-limits-limits
                 */

                encounter++;
                if (encounter >= 25) break;

                embed.AddField($"Commit (#{i}):", commits[i].Sha);
            }

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: user@find
            Task: Get a list of all users by specified filters.
            Arguments: page number, filters syntax.
         */


        [Command("user@find")]

        public async Task UserFind(int page = 0, [Remainder]string? syntax = "none")
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            /*
               Checking the syntax of filters at the time of their existence.
               At least one element so that the code does not break.
            */

            if (syntax == "none")
            {
                Logger.Error("Wrong command syntax format!");
                return;
            }

            string[] filterArray = syntax.Split(',');

            /*
                An array of User parameters for the next call to the GitHub API.
                In the appropriate order: followers, repositories.
             */

            Octokit.Range[] RangeParams = new Octokit.Range[] { RangeEnum.getDefaultRange(), RangeEnum.getDefaultRange() };

            DateRange created = DateEnum.getDefaultRange();

            Language language = new Language();

            AccountSearchType accountType = new AccountSearchType();

            /*
                An array of User parameters for the next call to the GitHub API.
                In the appropriate order: user's location, username, user's email, user's fullname.
             */

            string[] UserParams = new string[] { "none", "none", "none", "none" };

            /* 
                Insert a space into elements of the array and implementing it to lower case.
                It's necessary to avoid additional conditions in the "for" loop when checking filters.           
             */

            for (int _B90D = 0; _B90D < filterArray.Length; _B90D++)
            {
                filterArray[_B90D] = filterArray[_B90D].ToLower();

                if (!filterArray[_B90D].StartsWith(" ")) filterArray[_B90D].Insert(0, " ");
            }

            for (int i = 0; i < filterArray.Length; i++)
            {
                /*
                    We pass the raw string through the handler and parse it into the finished variable.
                    For detailed comments go to the specified class.
                 */

                if (filterArray[i].StartsWith(" followers: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 12);

                    string[]? arraySyntax = filterArray[i].Split(' ');

                    RangeParams[0] = RangeEnum.getRange(arraySyntax);
                }

                if(filterArray[i].StartsWith(" repositories: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 15);

                    string[]? arraySyntax = filterArray[i].Split(' ');

                    RangeParams[1] = RangeEnum.getRange(arraySyntax);
                }

                if(filterArray[i].StartsWith(" created@date: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 15);

                    created = DateEnum.getDateRange(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" language: ")) 
                {
                    filterArray[i] = filterArray[i].Remove(0, 11);

                    language = LangEnum.getLanguage(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" account@type: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 15);

                    accountType = AccountEnum.getAccountType(filterArray[i]);
                }

                /* Processing of simple elements. */

                if (filterArray[i].StartsWith(" location: "))
                    UserParams[0] = filterArray[i].Remove(0, 11);

                if (filterArray[i].StartsWith(" username: "))
                    UserParams[1] = filterArray[i].Remove(0, 11);

                if (filterArray[i].StartsWith(" email: "))
                    UserParams[2] = filterArray[i].Remove(0, 8);

                if (filterArray[i].StartsWith(" fullname: "))
                    UserParams[3] = filterArray[i].Remove(0, 11);
            }

            SearchUsersRequest searchRequest = EnumUser.getSearchUser(RangeParams[0], RangeParams[1], created, language, accountType, UserParams[0], UserParams[1], UserParams[2], UserParams[3]);

            EmbedBuilder embed = new EmbedBuilder();

            SearchUsersResult users = await git.Search.SearchUsers(searchRequest);

            /*
                Fixing page counter, so user can type 1 or 0 and that will be equals as 0.
                In other words, we transfer the usual number system to the number system of arrays.
             */

            if (page > 0) page--;
            if (page < 0) page = 0;

            uint encounter = 0;

            embed.WithTitle("GitHub's Users")
                 .WithColor(Color.Blue)
                 .WithFooter(footer => footer.Text = $"Page: {page}");

            for (int i = 0 + 25 * page; i < users.Items.Count; i++)
            {
                /*
                    Discord API doesn't allow you to create EmbedMessage with more than 25 fields.
                    See https://discord.com/developers/docs/resources/channel#embed-limits-limits
                 */

                encounter++;
                if (encounter >= 25) break;

                /* 
                    Since these are individual users, and not just parts of the repository. 
                    We display the name and only the URL. The user can use user@info for details.
                 */

                embed.AddField($"User ({users.Items[i].Name}):", $"**{users.Items[i].Url}**");
            }

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: repos@find
            Task: Get a list of all repos by specified filters.
            Arguments: page number, filters syntax.
         */

        [Command("repos@find")]

        public async Task ReposFind(int page = 0, [Remainder]string? syntax = "none")
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            /*
               Checking the syntax of filters at the time of their existence.
               At least one element so that the code does not break.
            */

            if (syntax == "none")
            {
                Logger.Error("Wrong command syntax format!");
                return;
            }

            string[] filterArray = syntax.Split(',');

            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: stars count, size range (kilobytes), forks count.
             */

            Octokit.Range[] RangeParams = new Octokit.Range[] { RangeEnum.getDefaultRange(), RangeEnum.getDefaultRange(), RangeEnum.getDefaultRange() };

            ForkQualifier forkQualifier = new ForkQualifier();

            Language language = new Language();

            DateRange created = DateEnum.getDefaultRange();
            DateRange updated = PeriodEnum.getDefaultRange();

            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: repository's owner, repository's name.
             */

            string[] ReposParams = new string[] { "none", "none" };

            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: README, description.
             */

            bool[] BooleanParams = new bool[] { true, true };

            /* 
                Insert a space into elements of the array and implementing it to lower case.
                It's necessary to avoid additional conditions in the "for" loop when checking filters.           
             */

            for (int _B90D = 0; _B90D < filterArray.Length; _B90D++)
            {
                filterArray[_B90D] = filterArray[_B90D].ToLower();

                if (!filterArray[_B90D].StartsWith(" ")) filterArray[_B90D].Insert(0, " ");
            }

            for (int i = 0; i < filterArray.Length; i++)
            {
                /*
                    We pass the raw string through the handler and parse it into the finished variable.
                    For detailed comments go to the specified class.
                 */

                if (filterArray[i].StartsWith(" stars: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 8);

                    string[]? syntaxArray = filterArray[i].Split(' ');

                    RangeParams[0] = RangeEnum.getRange(syntaxArray);
                }

                if (filterArray[i].StartsWith(" size: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 7);

                    string[]? syntaxArray = filterArray[i].Split(' ');

                    RangeParams[1] = RangeEnum.getRange(syntaxArray);
                }

                if (filterArray[i].StartsWith(" forks: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 7);

                    string[]? syntaxArray = filterArray[i].Split(' ');

                    RangeParams[2] = RangeEnum.getRange(syntaxArray);
                }

                if(filterArray[i].StartsWith(" fork@qualifier: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 17);

                    forkQualifier = ForkEnum.getForkQualifier(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" language: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 11);

                    language = LangEnum.getLanguage(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" creation@date: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 16);

                    created = DateEnum.getDateRange(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" update@date: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 14);

                    updated = PeriodEnum.getPeriodRange(filterArray[i]);
                }

                /* Processing of simple elements. */

                if (filterArray[i].StartsWith(" repos@git: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 12);

                    string[]? syntaxArray = filterArray[i].Split('/');

                    ReposParams[0] = syntaxArray[0];
                    ReposParams[1] = syntaxArray[1];
                }

                if(filterArray[i].StartsWith(" readme: ")) 
                {
                    filterArray[i] = filterArray[i].Remove(0, 9);

                    BooleanParams[0] = bool.Parse(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" desc: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 7);

                    BooleanParams[1] = bool.Parse(filterArray[i]);
                }
            }

            SearchRepositoriesRequest reposRequest = EnumRepos.getSearchRepos(RangeParams[0], RangeParams[1], RangeParams[2], forkQualifier, language, created, updated, ReposParams[0], ReposParams[1], BooleanParams[0], BooleanParams[1]);

            EmbedBuilder embed = new EmbedBuilder();

            SearchRepositoryResult repos = await git.Search.SearchRepo(reposRequest);

            /*
                Fixing page counter, so user can type 1 or 0 and that will be equals as 0.
                In other words, we transfer the usual number system to the number system of arrays.
             */

            if (page > 0) page--;
            if (page < 0) page = 0;

            uint encounter = 0;

            embed.WithTitle("GitHub's Codes")
                 .WithColor(Color.Blue)
                 .WithFooter(footer => footer.Text = $"Page: {page}");

            for (int i = 0 + 25 * page; i < repos.Items.Count; i++)
            {
                /*
                    Discord API doesn't allow you to create EmbedMessage with more than 25 fields.
                    See https://discord.com/developers/docs/resources/channel#embed-limits-limits
                 */

                encounter++;
                if (encounter >= 25) break;

                /* 
                    Since these are individual repos, and not just parts of the list. 
                    We display the name and only the URL. The user can find repository and check it for details.
                 */

                embed.AddField($"Repos ({repos.Items[i].FullName}):", $"**{repos.Items[i].Url}**");
            }

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: code@find
            Task: Get a list of all codes by specified filters.
            Arguments: page number, filters syntax.
         */

        [Command("code@find")]

        public async Task CodeFind(int page = 0, [Remainder] string? syntax = "none")
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            /*
               Checking the syntax of filters at the time of their existence.
               At least one element so that the code does not break.
            */

            if (syntax == "none")
            {
                Logger.Error("Wrong command syntax format!");
                return;
            }

            string[] filterArray = syntax.Split(',');

            /* 
                Insert a space into elements of the array and implementing it to lower case.
                It's necessary to avoid additional conditions in the "for" loop when checking filters.           
             */

            for (int _B90D = 0; _B90D < filterArray.Length; _B90D++)
            {
                filterArray[_B90D] = filterArray[_B90D].ToLower();

                if (!filterArray[_B90D].StartsWith(" ")) filterArray[_B90D].Insert(0, " ");
            }
                
            /*
                An array of Repository parameters for the next call to the GitHub API.
                In the appropriate order: filename, path, user, repository's owner, repository's name.
             */

            string[] CodeParams = new string[] { "none", "none", "none", "none", "none" };

            Language language = new Language();

            bool forks = false;

            /* File size (bytes). */

            Octokit.Range size = RangeEnum.getDefaultRange();

            for (int i = 0; i < filterArray[i].Length; i++)
            {
                /*
                    We pass the raw string through the handler and parse it into the finished variable.
                    For detailed comments go to the specified class.
                 */

                if (filterArray[i].StartsWith(" language: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 11);

                    language = LangEnum.getLanguage(filterArray[i]);
                }

                if (filterArray[i].StartsWith(" size: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 7);

                    string[]? syntaxArray = filterArray[i].Split(' ');

                    size = RangeEnum.getRange(syntaxArray);
                }

                /* Processing of simple elements. */

                if (filterArray[i].StartsWith(" filename: "))
                    CodeParams[0] = filterArray[i].Remove(0, 11);

                if (filterArray[i].StartsWith(" path: "))
                    CodeParams[1] = filterArray[i].Remove(0, 7);

                if (filterArray[i].StartsWith(" user: "))
                    CodeParams[2] = filterArray[i].Remove(0, 7);

                if (filterArray[i].StartsWith(" repos@git: "))
                {
                    filterArray[i] = filterArray[i].Remove(0, 12);

                    string[]? syntaxArray = filterArray[i].Split('/');

                    CodeParams[3] = syntaxArray[0];
                    CodeParams[4] = syntaxArray[1];
                }

                if (filterArray[i].StartsWith(" forks: "))
                    forks = bool.Parse(filterArray[i].Remove(0, 8));
            }

            SearchCodeRequest codeRequest = EnumCode.getSearchCode(CodeParams[0], CodeParams[1], CodeParams[2], CodeParams[3], CodeParams[4], language, forks, size); ;

            EmbedBuilder embed = new EmbedBuilder();

            SearchCodeResult codes = await git.Search.SearchCode(codeRequest);

            /*
                Fixing page counter, so user can type 1 or 0 and that will be equals as 0.
                In other words, we transfer the usual number system to the number system of arrays.
             */

            if (page > 0) page--;
            if (page < 0) page = 0;

            uint encounter = 0;

            embed.WithTitle("GitHub's Codes")
                 .WithColor(Color.Blue)
                 .WithFooter(footer => footer.Text = $"Page: {page}");

            for (int i = 0 + 25 * page; i < codes.Items.Count; i++)
            {
                /*
                    Discord API doesn't allow you to create EmbedMessage with more than 25 fields.
                    See https://discord.com/developers/docs/resources/channel#embed-limits-limits
                 */

                encounter++;
                if (encounter >= 25) break;

                /* 
                    Since these are individual codes, and not just parts of the repository. 
                    We display the name and only the URL. The user can find repository and check it for details.
                 */

                embed.AddField($"Code ({codes.Items[i].Sha}):", $"**{codes.Items[i].Url}**");
            }

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }
    }
}
