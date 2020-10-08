using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using Octokit;

namespace Stratum {

    public class Other : ModuleBase<SocketCommandContext> {

        private Config CONFIG;

        [Command("GITAPI-STATUS")]

        public async Task APISTATUS() {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            MiscellaneousRateLimit APIMISCELLANEOUS = await GITCLIENT.Miscellaneous.GetRateLimits();

            RateLimit APICORE = APIMISCELLANEOUS.Resources.Core;
            RateLimit APISEARCH = APIMISCELLANEOUS.Resources.Search;

            string COREINFORMATION = "LIMIT: " + APICORE.Limit + "\n" + "REMAINING: " + APICORE.Remaining + "\n" + "RESET (UTC): " + APICORE.Reset;
            string SEARCHINFORMATION = "LIMIT: " + APISEARCH.Limit + "\n" + "REMAINING: " + APISEARCH.Remaining + "\n" + "RESET (UTC): " + APISEARCH.Reset; 

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("GITHUB API STATUS")
                 .WithColor(Color.Green)
                 .AddField("API CORE:", COREINFORMATION)
                 .AddField("API SEARCH:", SEARCHINFORMATION);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("GITAPI-HELP")]

        public async Task APIHELP() {
            string BOTPREFIX = CONFIG.getBotPrefix();
            string IMAGEURL = Context.Client.CurrentUser.GetAvatarUrl();

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("GITHUB API HELP")
                 .WithColor(Color.Green)
                 .WithUrl("https://github.com/Falcion/Stratum/blob/main/Documentation/")
                 .AddField("``" + BOTPREFIX + "GITAPI-LIMIT" + "``", "Shows current status of GitHub API with specific token.")
                 .AddField("``" + BOTPREFIX + "GITAPI-HELP" + "``", "Shows information and list of current commands.")
                 .AddField("``" + BOTPREFIX + "REPOS-INFO [AUTHOR] [NAME]" + "``", "Shows information about specific repository.")
                 .AddField("``" + BOTPREFIX + "BRANCH-INFO [AUTHOR] [NAME] [BRANCH]" + "``", "Shows information about specific branch.")
                 .AddField("``" + BOTPREFIX + "RELEASE-INFO [AUTHOR] [NAME] [TAG]" + "``", "Shows advanced information about specific release.")
                 .AddField("``" + BOTPREFIX + "ISSUE-INFO [AUTHOR] [NAME] [NUMBER]" + "``", "Shows advanced information about specific issue.")
                 .AddField("``" + BOTPREFIX + "COMMIT-INFO [AUTHOR] [NAME]" + "``", "Shows information about specific commit.")
                 .AddField("``" + BOTPREFIX + "USER-INFO [LOGIN]" + "``", "Shows information about specific user.")
                 .AddField("``" + BOTPREFIX + "REPOS-BRANCHES [AUTHOR] [NAME] [PAGE]" + "``", "Shows information about branches of specific repository.")
                 .AddField("``" + BOTPREFIX + "REPOS-RELEASES [AUTHOR] [NAME] [PAGE]" + "``", "Shows information about releases of specific repository.")
                 .AddField("``" + BOTPREFIX + "REPOS-ISSUES [AUTHOR] [NAME] [PAGE] [FILTERS]" + "``", "Shows list of issues in specific repository that sorted by specific filters.")
                 .AddField("``" + BOTPREFIX + "REPOS-COMMITS [AUTHOR] [NAME] [PAGE] [FILTERS]" + "``", "Shows list of commits in specific repository that sorted by specific filters.")
                 .AddField("``" + BOTPREFIX + "SEARCH-USERS [PAGE] [FILTERS]" + "``", "Shows a list of found users using specific filters.")
                 .AddField("``" + BOTPREFIX + "SEARCH-REPOS [PAGE] [FILTERS]" + "``", "Shows a list of found repositories using specific filters.")
                 .AddField("``" + BOTPREFIX + "SEARCH-CODE [PAGE] [FILTERS]" + "``", "Shows a list of found codes using specific filters.")
                 .AddField("``" + BOTPREFIX + "ORGANIZATION [NAME]" + "``", "Shows information about specific organization.")
                 .AddField("``" + BOTPREFIX + "PULL-REQUEST [AUTHOR] [NAME] [NUMBER]" + "``", "Shows information about specific pull request.");

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }
    }
}