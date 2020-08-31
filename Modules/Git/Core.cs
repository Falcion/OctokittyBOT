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

            string allowBlock = $"**AllowMergeCommit:** ``{repository.AllowMergeCommit}``\n**AllowRebaseMerge:** ``{repository.AllowRebaseMerge}``\n**AllowSquashMerge:** ``{repository.AllowSquashMerge}``";
            string forkBlock = $"**Is Fork:** ``{repository.Fork}``\n**Forks Count:** ``{repository.ForksCount}``";
            string otherBlock = $"**Is Archived:** ``{repository.Archived}``\n**Default Branch:** ``{repository.DefaultBranch}``\n**Repository Size:** ``{repository.Size}``";

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Repository's Core Info")
                                                        .WithColor(Color.Gold)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(gitUser.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Allow-information block", allowBlock)
                                                        .AddField("Fork information block", forkBlock)
                                                        .AddField("Other information block", otherBlock);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("branch-info")]

        public async Task BranchInfo(string gitAuthor, string gitRepos, string gitBranch) {

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

            Branch branch
                        = await gitClient.Repository.Branch.Get(gitAuthor, gitRepos, gitBranch);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Branch's Info")
                                                        .WithColor(Color.Gold)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(gitUser.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Branch's Name:", branch.Name)
                                                        .AddField("Branch's Protected:", branch.Protected)
                                                        .AddField("Branch's Sha (Last):", branch.Commit.Sha);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("release-info")]

        public async Task ReleaseInfo(string gitAuthor, string gitRepos, string gitRelease) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + "/releases/tag/" + gitRelease;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            User gitUser
                        = await gitClient.User.Get(gitAuthor);

            Release release
                        = await gitClient.Repository.Release.Get(gitAuthor, gitRepos, gitRelease);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle(release.Name)
                                                        .WithDescription(release.Body)
                                                        .WithColor(Color.Gold)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(gitUser.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .WithFooter(
                                                                footer => footer.Text = release.TagName
                                                        )
                                                        .AddField("Author:", release.Author)
                                                        .AddField("Published At:", $"{release.PublishedAt}")
                                                        .AddField("Release's ID:", release.Id)
                                                        .AddField("Assets' URL:", release.AssetsUrl);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("issue-info")]

        public async Task IssueInfo(string gitAuthor, string gitRepos, int gitIssue) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + "/issues/" + gitIssue;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            Issue issue
                        = await gitClient.Issue.Get(gitAuthor, gitRepos, gitIssue);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle(issue.Title + "(#" + issue.Number + ')')
                                                        .WithDescription(issue.Body)
                                                        .WithColor(Color.Gold)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(issue.User.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .WithFooter(
                                                                footer => footer.Text = issue.Repository.Name
                                                        )
                                                        .AddField("Issue's ID:", issue.Id)
                                                        .AddField("Issue's URL:",issue.Url)
                                                        .AddField("Issue's Update:", $"{issue.UpdatedAt}")
                                                        .AddField("Issue's State:", issue.State.Value);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("commit-info")]

        public async Task CommitInfo(string gitAuthor, string gitRepos, string gitCommit) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor + '/' + gitRepos + "/commit/" + gitCommit;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            GitHubCommit commit
                        = await gitClient.Repository.Commit.Get(gitAuthor, gitRepos, gitCommit);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Commit's Info")
                                                        .WithDescription(commit.Commit.Message)
                                                        .WithColor(Color.Gold)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(commit.Author.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .WithFooter(
                                                                footer => footer.Text = commit.Repository.Name
                                                        )
                                                        .AddField("Commit's Sha:", commit.Sha)
                                                        .AddField("Commit's URL:", commit.Url)
                                                        .AddField("Commit's Total:", $"{commit.Stats.Total}");

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("user-core")]

        public async Task UserCore(string gitAuthor) {

            string apiToken
                    = Storage.apiToken;

            string gitURL
                    = "https://github.com/" + gitAuthor;

            GitHubClient gitClient
                                = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            User gitUser
                        = await gitClient.User.Get(gitAuthor);

            string publicInformation = "Company: " + gitUser.Company + "\nEmail: " + gitUser.Email + "\nLocation: " + gitUser.Location + $"\nCreation Date: {gitUser.CreatedAt}";
            string reposInformation = "Public Repositories: " + gitUser.PublicRepos + "\nPrivate Repositories: " + gitUser.TotalPrivateRepos;
            string followInformation = "Followers: " + gitUser.Followers + "\nFollowing: " + gitUser.Following;
            string systemInformation = "Disk Usage: " + gitUser.DiskUsage + "\nPlan: " + gitUser.Plan + "\nNode ID: " + gitUser.NodeId;

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle(gitUser.Name + "'s Information")
                                                        .WithDescription(gitUser.Bio)
                                                        .WithColor(Color.Gold)
                                                        .WithCurrentTimestamp()
                                                        .WithThumbnailUrl(gitUser.AvatarUrl)
                                                        .WithUrl(gitURL)
                                                        .AddField("Public Information", publicInformation)
                                                        .AddField("Repositories Information", reposInformation)
                                                        .AddField("Following Information", followInformation)
                                                        .AddField("System Information", systemInformation);

           await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}