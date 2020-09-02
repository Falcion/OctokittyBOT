using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using Discord;
using System.Collections.Generic;
using System;

namespace Stratum {

    public class Git : ModuleBase<SocketCommandContext> {

        [Command("gitapi-limit")]

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
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .AddField("Core Information", coreInformation)
                                                        .AddField("Search Information", searchInformation);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("repos-info")]

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
                                                        .WithColor(Color.Default)
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
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithUrl(gitURL)
                                                        .AddField("Branch List:", branchList);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("repos-releases")]
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
                                                        .WithColor(Color.Default)
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

            string[] filterArray = filters.Split("/ +/");

            if(filterArray.Length < 2)
                                    return;

            IssueFilter issuesFilter = IssueFilter.All;

            string issueCreator = "none",
                   issueMentioned = "none",
                   issueAssignee = "none",
                   issueMilestone = "none";

            for(int i = 0; i < filterArray.Length; i++) {

                if(filterArray[i].StartsWith(" issues-filter:")) {

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
                                                        .WithColor(Color.Default)
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

        [Command("repos-commits")]
        [RequireContext(ContextType.Guild)]

        public async Task ReposCommits(string gitAuthor, string gitRepos, int page, [Remainder]string filters = "") {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + '/' + "commit/";

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth 
                        = new Credentials(apiToken);
                        
            gitClient.Credentials = tokenAuth;

            string[] filterArray = filters.Split("/ +/");

            DateTime dateChecker = DateTime.Now;

            DateTime untilDate = dateChecker,
                     sinceDate = dateChecker;

            string commitAuthor = "none",
                   path = "none",
                   sha = "none";

            for(int i = 0; i < filterArray.Length; i++) {

                if(filterArray[i].StartsWith(" until: ")) {

                    filterArray[i] 
                            = filterArray[i].Remove(0, 8);

                    untilDate = DateTime.Parse(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" since: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 8);

                    sinceDate = DateTime.Parse(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" author: ")) 
                                commitAuthor = filterArray[i].Remove(0, 9);

                if(filterArray[i].StartsWith(" path: "))
                                path = filterArray[i].Remove(0, 7);

                if(filterArray[i].StartsWith(" sha: "))
                                sha = filterArray[i].Remove(0, 6);
            }

            IReadOnlyList<GitHubCommit> commitArray;

            if(untilDate == dateChecker && commitAuthor == "none" && path == "none" && sha == "none")
                                    commitArray = await gitClient.Repository.Commit.GetAll(gitAuthor, gitRepos);

            else {
                CommitRequest commitRequest
                            = new CommitRequester().CommitRegister(commitAuthor, path, sha, untilDate, sinceDate, dateChecker);

                commitArray = await gitClient.Repository.Commit.GetAll(gitAuthor, gitRepos, commitRequest);
            }

            if(page > 0) page--;
            else if(page <= 0) page = 0;

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Repository's Commits")
                                                        .WithDescription($"All sorted (that were found) commits count: {commitArray.Count}. For more information, click on the title hyperlink or type page number (integer).")
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithUrl(gitURL);

            int algBreaker = 0;
            for(int i = 0 + 25 * page; i < commitArray.Count; i++) {
                algBreaker++;
                if(algBreaker == 25) break;

                GitHubCommit commit = commitArray[i];
                
                string commitInfo = "Commit's Author: " + commit.Author.Login + "\nCommit's URL: " + commit.Url;

                messageEmbed.AddField("Commit's SHA: " + commit.Sha, commitInfo);
            }

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}