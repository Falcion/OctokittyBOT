using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using Discord;
using System.Collections.Generic;

namespace Stratum {

    public class Git : ModuleBase<SocketCommandContext> {

        [Command("gitapi-limit")]
        [RequireContext(ContextType.Guild)]

        public async Task ApiLimit() {

            string apiToken 
                        = Storage.apiToken;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth 
                        = new Credentials(apiToken);
                        
            gitClient.Credentials = tokenAuth;

            var apiMisc 
                        = await gitClient.Miscellaneous.GetRateLimits();

            RateLimit apiCore
                        = apiMisc.Resources.Core;
            RateLimit apiSearch
                        = apiMisc.Resources.Search;

            string coreInformation 
                = $"Requests Limit: {apiCore.Limit} " +
                  $"\nRequests Remaining: {apiCore.Remaining} " +
                  $"\nUTC Time Reset: {apiCore.Reset}";
            string searchInformation 
                = $"Requests Limit: {apiSearch.Limit} " +
                  $"\nRequests Remaining: {apiSearch.Remaining} " +
                  $"\nUTC Time Reset: {apiSearch.Reset}";

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("GitHub API Limit")
                                                        .WithDescription("Like any popular API, Github needs to throttle some requests. The OctoKit.NET client allows you to get some insight into how many requests you have left and when you can start making requests again.")
                                                        .WithColor(Color.DarkerGrey)
                                                        .WithCurrentTimestamp()
                                                        .AddField("Core Information", coreInformation)
                                                        .AddField("Search Information", searchInformation);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("repos-info")]
        [RequireContext(ContextType.Guild)]

        public async Task ReposInfo(string gitAuthor, string gitRepos) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth 
                        = new Credentials(apiToken);
                        
            gitClient.Credentials = tokenAuth;

            User gitUser
                    = await gitClient.User.Get(gitAuthor);

            Repository Repository
                            = await gitClient.Repository.Get(gitAuthor, gitRepos);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("GitHub Repository")
                                                        .WithDescription(Repository.Description)
                                                        .WithColor(Color.LightGrey)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(gitUser.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Repository's ID:", Repository.Id)
                                                        .AddField("Repository's License:", Repository.License.Name)
                                                        .AddField("Creation Date:", Repository.CreatedAt)
                                                        .AddField("Repository's Name:", Repository.Name)
                                                        .AddField("Last Update:", Repository.UpdatedAt);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("repos-branches")]
        [RequireContext(ContextType.Guild)]

        public async Task ReposBranches(string gitAuthor, string gitRepos) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + '/' + "branches";

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth 
                        = new Credentials(apiToken);
                        
            gitClient.Credentials = tokenAuth;

            IReadOnlyList<Branch> branchArray
                            = await gitClient.Repository.Branch.GetAll(gitAuthor, gitRepos);

            string branchList = null;

            for(int i = 0; i < branchArray.Count; i++) {
                Branch branch = branchArray[i];

                branchList += branch.Name + "\n";
            }

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Repository's Branches")
                                                        .WithDescription("Below you can see repository's branches, for GitHub repository's branches page, you can open title with special url.")
                                                        .WithColor(Color.LightGrey)
                                                        .WithCurrentTimestamp()
                                                        .WithUrl(gitURL)
                                                        .AddField("Branch List:", branchList);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("repos-releases")]
        [RequireContext(ContextType.Guild)]
        public async Task ReposReleases(string gitAuthor, string gitRepos, int page = 0) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + '/' + "releases";

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth 
                        = new Credentials(apiToken);
                        
            gitClient.Credentials = tokenAuth;

            IReadOnlyList<Release> releaseArray
                                = await gitClient.Repository.Release.GetAll(gitAuthor, gitRepos);

            int releaseCount 
                    = releaseArray.Count;

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Repository's Releases")
                                                        .WithDescription("Below you can see repository's releases, for more releases that can't fit in this list you need to type an number of page.")
                                                        .WithFooter(
                                                            footer => footer.Text = "For next page: type number (integer) of page.")
                                                        .WithColor(Color.LighterGrey)
                                                        .WithUrl(gitURL);
            int embedCounter = 0;
            for(int i = 0 + 25 * page; i < releaseCount; i++) {
                ++embedCounter;
                if(embedCounter == 25) 
                                    break;

                Release release = releaseArray[i];

                messageEmbed.AddField(release.Name, "Tag: " + release.TagName + "\nPublished At: " + release.PublishedAt);
            }

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("repos-issues")]
        [RequireContext(ContextType.Guild)]

        public async Task ReposIssues(string gitAuthor, string gitRepos, int page, [Remainder]string filters) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + '/' + "issues";

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth 
                        = new Credentials(apiToken);
                        
            gitClient.Credentials = tokenAuth;

            string[] filterArray = filters.Split("[+]");

            if(filterArray.Length < 2)
                                    return;

            IssueFilter issuesFilter = IssueFilter.All;

            string issueCreator = "none",
                   issueMentioned = "none",
                   issueAssignee = "none",
                   issueMilestone = "none";

            for(int i = 0; i < filterArray.Length; i++) {

                if(filterArray[i].StartsWith(" issuesfilter:")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 1);
                    issuesFilter 
                            = new FilterRequester().FilterRegister(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" creator: ")) 
                                    issueCreator = filterArray[i].Remove(0, 10);
                
                if(filterArray[i].StartsWith(" mentioned: ")) 
                                    issueMentioned = filterArray[i].Remove(0, 12);

                if(filterArray[i].StartsWith(" assignee: ")) 
                                    issueAssignee = filterArray[i].Remove(0, 11);
                
                if(filterArray[i].StartsWith(" milestone: ")) 
                                    issueMilestone = filterArray[i].Remove(0, 12);
            }

            RepositoryIssueRequest issueRequest;

            if(issueCreator != "none") {

                if(issueMentioned != "none") {

                    issueRequest = new RepositoryIssueRequest {

                        Filter = issuesFilter,
                        Creator = issueCreator,
                        Mentioned = issueMentioned,
                        Assignee = issueAssignee,
                        Milestone = issueMilestone,
                    };
                }

                else {

                    issueRequest = new RepositoryIssueRequest {

                        Filter = issuesFilter,
                        Creator = issueCreator,
                        Assignee = issueAssignee,
                        Milestone = issueMilestone,
                    };
                }
            }

            else {

                if(issueMentioned != "none") {

                    issueRequest = new RepositoryIssueRequest {

                        Filter = issuesFilter,
                        Mentioned = issueMentioned,
                        Assignee = issueAssignee,
                        Milestone = issueMilestone,
                    };
                }

                else {

                    issueRequest = new RepositoryIssueRequest {

                        Assignee = issueAssignee,
                        Milestone = issueMilestone,
                    };
                }
            }

            IReadOnlyList<Issue> issuesArray 
                             = await gitClient.Issue.GetAllForRepository(gitAuthor, gitRepos, issueRequest);

            if(page > 0) page--;
            else if(page <= 0) page = 0;

            EmbedBuilder messageEmbed = new EmbedBuilder()
                                                        
                                                         .WithTitle("Repository's Issues")
                                                         .WithDescription($"All sorted issues count: {issuesArray.Count}. For more information, click on the title hyperlink or type page number (integer).")
                                                         .WithColor(Color.LighterGrey)
                                                         .WithCurrentTimestamp()
                                                         .WithUrl(gitURL);
            
            int algBreaker = 0;
            for(int i = 0 + 25 * page; i < issuesArray.Count; i++) {
                algBreaker++;
                    
                if(algBreaker == 25) break;

                Issue issue 
                        = issuesArray[i];

                string issueTitle = "Issue fullname: " + issue.Title + $" (#{issue.Number})";
                string issueDesc = "Link: " + issue.Url + $"\nIssue Update: {issue.UpdatedAt}";

                messageEmbed.AddField(issueTitle, issueDesc);
            }

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}