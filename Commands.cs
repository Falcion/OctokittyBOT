using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using Discord;
using System;

namespace Stratum {

    public class Commands : ModuleBase<SocketCommandContext> {

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
                                                messageEmbed.Build());
        }
    }
}