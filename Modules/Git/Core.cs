using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using Discord;

namespace Stratum {

    public class Core : ModuleBase<SocketCommandContext> {

        [Command("repos-core")]

        public async Task ReposCore(string gitAuthor, string gitRepos) {

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

            Repository repository
                            = await gitClient.Repository.Get(gitAuthor, gitRepos);

            string allowBlock = $"**AllowMergeCommit:** {repository.AllowMergeCommit}\n**AllowRebaseMerge:** {repository.AllowRebaseMerge}\n**AllowSquashMerge:** {repository.AllowSquashMerge}";
            string forkBlock = $"**Is Fork:** {repository.Fork}\n**Forks Count:** {repository.ForksCount}";
            string otherBlock = $"**Is Archived:** {repository.Archived}\n**Default Branch:** {repository.DefaultBranch}\n**Repository Size:** {repository.Size}";

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Repository's Core Info")
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(gitUser.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Allow-information block", allowBlock)
                                                        .AddField("Fork information block", forkBlock)
                                                        .AddField("Other information block", otherBlock);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}