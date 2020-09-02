using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using Discord;

namespace Stratum {

    public class Additional : ModuleBase<SocketCommandContext> {

        [Command("organization")]

        public async Task OrganizationRequest(string gitName) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitName;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            Organization organization
                        = await gitClient.Organization.Get(gitName);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle(organization.Name + "'s Information")
                                                        .WithDescription(organization.Bio)
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(organization.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Organization's Location:", organization.Location)
                                                        .AddField("Organization's Billing Adress:", organization.BillingAddress)
                                                        .AddField("Organization's Email:", organization.Email);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("pull-request")]

        public async Task PullRequester(string gitAuthor, string gitRepos, int gitPull) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + "/pull/" + gitPull;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            PullRequest pullRequest
                        = await gitClient.PullRequest.Get(gitAuthor, gitRepos, gitPull);
            
            string requestState = "Draft: " + pullRequest.Draft + "\nMerged: " + pullRequest.Merged + "\nState: " + pullRequest.State + "\nMergerable State: " + pullRequest.MergeableState;

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle(pullRequest.Title)
                                                        .WithDescription(pullRequest.Body)
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(pullRequest.User.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Pull Request's State:", requestState)
                                                        .AddField("Changed Files Count:", pullRequest.ChangedFiles);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}