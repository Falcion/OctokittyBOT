using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using Octokit;

namespace Stratum.Handler {

    public class CORE : ModuleBase<SocketCommandContext> {

        private Color DEFAULT = Color.Default;

        private Config CONFIG;
        private Logger LOGGER;

        [Command("REPOS-INFO")]

        public async Task REPOSINFO(string AUTHOR, string NAME) {
            string APITOKEN = CONFIG.getApiToken();
            string GITURL = "https://github.com/" + AUTHOR + "/" + NAME;

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            User GITUSER = await GITCLIENT.User.Get(AUTHOR);

            Repository REPOSITORY = await GITCLIENT.Repository.Get(AUTHOR, NAME);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(REPOSITORY.FullName)
                 .WithDescription(REPOSITORY.Description)
                 .WithColor(DEFAULT)
                 .WithUrl(REPOSITORY.Url)
                 .WithThumbnailUrl(GITUSER.AvatarUrl)
                 .AddField("ID:", REPOSITORY.Id)
                 .AddField("LICENSE:", REPOSITORY.License.Name)
                 .AddField("CREATION DATE:", REPOSITORY.CreatedAt)
                 .AddField("LAST UPDATE:", REPOSITORY.UpdatedAt);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("BRANCH-INFO")]

        public async Task BRANCHINFO(string AUTHOR, string NAME, string BRANCHNAME) {
            string APITOKEN = CONFIG.getApiToken();
            string GITURL = "https://github.com/" + AUTHOR + "/" + NAME + "/branches/" + BRANCHNAME;

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            User GITUSER = await GITCLIENT.User.Get(AUTHOR);

            Branch BRANCH = await GITCLIENT.Repository.Branch.Get(AUTHOR, NAME, BRANCHNAME);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(BRANCHNAME)
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .AddField("NAME:", BRANCH.Name)
                 .AddField("PROTECTED:", BRANCH.Protected)
                 .AddField("SHA:", BRANCH.Commit.Sha);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("RELEASE-INFO")]

        public async Task RELEASEINFO(string AUTHOR, string NAME, string TAG) {
            string APITOKEN = CONFIG.getApiToken();
            string GITURL = "https://github.com/" + AUTHOR + "/" + NAME + "/releases/tag/" + TAG;

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            Release RELEASE = await GITCLIENT.Repository.Release.Get(AUTHOR, NAME, TAG);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(RELEASE.Name)
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .AddField("ID:", RELEASE.Id)
                 .AddField("URL:", RELEASE.Url)
                 .AddField("TARGET:", RELEASE.TargetCommitish);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("ISSUE-INFO")]

        public async Task ISSUEINFO(string AUTHOR, string NAME, int NUMBER) {
            string APITOKEN = CONFIG.getApiToken();
            string GITURL = "https://github.com/" + AUTHOR + "/" + NAME + "/issues/" + $"{NUMBER}";

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            Issue ISSUE = await GITCLIENT.Issue.Get(AUTHOR, NAME, NUMBER);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(ISSUE.Title)
                 .WithDescription(ISSUE.Body)
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .AddField("ID:", ISSUE.Id)
                 .AddField("STATE:", ISSUE.State.Value)
                 .AddField("URL:", ISSUE.Assignee.Url)
                 .AddField("ASSIGNEE:", ISSUE.Assignee.Name);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("COMMIT-INFO")]

        public async Task COMMITINFO(string AUTHOR, string NAME, string REFERENCE) {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            GitHubCommit COMMIT = await GITCLIENT.Repository.Commit.Get(AUTHOR, NAME, REFERENCE);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(COMMIT.Sha)
                 .WithColor(DEFAULT)
                 .WithUrl(COMMIT.Url)
                 .AddField("REFERENCE:", COMMIT.Ref)
                 .AddField("AUTHOR:", COMMIT.Author.Login)
                 .AddField("TOTAL:", COMMIT.Stats.Total);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("USER-INFO")]

        public async Task USERINFO(string USER) {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            User GITUSER = await GITCLIENT.User.Get(USER);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(GITUSER.Login)
                 .WithDescription(GITUSER.Bio)
                 .WithColor(DEFAULT)
                 .WithUrl(GITUSER.Url)
                 .WithImageUrl(GITUSER.AvatarUrl)
                 .AddField("EMAIL:", GITUSER.Email)
                 .AddField("LOCATION:", GITUSER.Location)
                 .AddField("ID:", GITUSER.Id)
                 .AddField("FOLLOWERS:", GITUSER.Followers)
                 .AddField("DISKUSAGE:", GITUSER.DiskUsage);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        //TO-DO: REPOS-BRANCHES

        //TO-DO: REPOS-RELEASES

        //TO-DO: REPOS-ISSUES

        //TO-DO: REPOS-COMMITS

        //TO-DO: SEARCH-USERS

        //TO-DO: SEARCH-REPOS

        //TO-DO: SEARCH-ISSUES

        //IN OTHER CLASS: GIT-API LIMIT COMMAND
        //IN OTHER CLASS: HELP COMMAND
    }
}