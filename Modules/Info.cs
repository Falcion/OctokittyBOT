using Discord;
using Discord.Commands;
using Octokit;
using System.Threading.Tasks;

namespace Stagnum.Modules
{
    public class Info : ModuleBase<SocketCommandContext>
    {
        [Command("repos?info")]

        public async Task RepositoryInfo(string owner, string name)
        {
            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stagnum"));

            var repository = await git.Repository.Get(owner, name);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Repository's Information")
                 .AddField("ID:", repository.Id)
                 .AddField("License:", repository.License.Name)
                 .AddField("Creation Date:", $"{repository.CreatedAt}");

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("branch?info")]

        public async Task BranchInfo(string owner, string name, string branchName)
        {
            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stagnum"));

            var branch = await git.Repository.Branch.Get(owner, name, branchName);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Branch Information")
                 .AddField("Name:", branch.Name)
                 .AddField("Protected:", branch.Protected);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("release?info")]

        public async Task ReleaseInfo(string owner, string name, string tag)
        {
            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stagnum"));

            var release = await git.Repository.Release.Get(owner, name, tag);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Release Information")
                 .AddField("ID:", release.Id)
                 .AddField("Target:", release.TargetCommitish);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("issue?info")]

        public async Task IssueInfo(string owner, string name, int number)
        {
            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stagnum"));

            var issue = await git.Issue.Get(owner, name, number);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Issue Information")
                 .AddField("ID:", issue.Id)
                 .AddField("State:", issue.State.Value);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("commit?info")]

        public async Task CommitInfo(string owner, string name, string sha)
        {
            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stagnum"));

            var commit = await git.Repository.Commit.Get(owner, name, sha);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Commit Information")
                 .AddField("Author:", commit.Author.Login)
                 .AddField("Total:", commit.Stats.Total);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("user?info")]

        public async Task UserInfo(string login)
        {
            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stagnum"));

            var user = await git.User.Get(login);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("User Information")
                 .AddField("ID:", user.Id)
                 .AddField("Repositories:", user.TotalPrivateRepos + user.PublicRepos);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
