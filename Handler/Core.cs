using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

using Octokit;

namespace Stratum {

    public class CORE : ModuleBase<SocketCommandContext> {

        private Color DEFAULT = Color.Default;

        private Config CONFIG;
        private Logger LOGGER;
        private Parser PARSER;

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

        [Command("REPOS-BRANCHES")]

        public async Task REPOSBRANCHES(string AUTHOR, string NAME, int PAGE = 0) {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string GITURL = "https://github.com/" + AUTHOR + NAME + "/branches/";

            IReadOnlyList<Branch> BRANCHLIST = await GITCLIENT.Repository.Branch.GetAll(AUTHOR, NAME);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("__P82_AA8C__")
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + $"{PAGE}");

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0; 

            for(int i = 0 + 25 * PAGE; i < BRANCHLIST.Count; i++) {
                Branch BRANCH = BRANCHLIST[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("BRANCH:", "NAME:" + BRANCH.Name + "\n" + "PROTECTED:" + BRANCH.Protected);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("REPOS-RELEASES")]

        public async Task REPOSRELEASES(string AUTHOR, string NAME, int PAGE = 0) {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string GITURL = "https://github.com/" + AUTHOR + NAME + "/releases/";

            IReadOnlyList<Release> RELEASELIST = await GITCLIENT.Repository.Release.GetAll(AUTHOR, NAME);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("__P82_D09Q_1")
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + $"{PAGE}");

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0; 

            for(int i = 0 + 25 * PAGE; i < RELEASELIST.Count; i++) {
                Release RELEASE = RELEASELIST[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("RELEASE: " + RELEASE.Name, "AUTHOR: " + RELEASE.Author.Login + "\n" + "URL: " + RELEASE.Url + "\n" + "TAG:" + RELEASE.TagName);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("REPOS-ISSUES")]

        public async Task REPOSISSUES(string AUTHOR, string NAME, int PAGE = 0,[Remainder]string FILTERS = "") {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string GITURL = "https://github.com/" + AUTHOR + NAME + "/issues/";

            string[] FILTERARRAY = FILTERS.Split('⇒');

            IssueFilter ISSUEFILTER = IssueFilter.All;

            string ISSUECREATOR = "NONE";
            string ISSUEMENTIONED = "NONE";
            string ISSUEASSIGNEE = "NONE";
            string ISSUEMILESTONE = "NONE";

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("__4PQ9_C8_")
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + $"{PAGE}");

            for(int i = 0; i < FILTERARRAY.Length; i++) {

                if(FILTERARRAY[i].StartsWith(" ISSUESFILTER: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 15);

                    ISSUEFILTER = PARSER.ISSUEFILTER(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" CREATOR: ")) ISSUECREATOR = FILTERARRAY[i].Remove(0, 10);
                if(FILTERARRAY[i].StartsWith(" MENTIONED: ")) ISSUEMENTIONED = FILTERARRAY[i].Remove(0, 12);
                if(FILTERARRAY[i].StartsWith(" ASSIGNEE: ")) ISSUEASSIGNEE = FILTERARRAY[i].Remove(0, 11);
                if(FILTERARRAY[i].StartsWith(" MILESTONE: ")) ISSUEMILESTONE = FILTERARRAY[i].Remove(0, 12);

            }

            RepositoryIssueRequest ISSUEREQUEST;

            ISSUEREQUEST = PARSER.ISSUEREQUEST(ISSUEFILTER, ISSUECREATOR, ISSUEMENTIONED, ISSUEASSIGNEE, ISSUEMILESTONE);

            IReadOnlyList<Issue> ISSUESLIST = await GITCLIENT.Issue.GetAllForRepository(AUTHOR, NAME, ISSUEREQUEST);

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0;

            for(int i = 0 + 25 * PAGE; i < ISSUESLIST.Count; i++) {

                Issue ISSUE = ISSUESLIST[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("ISSUE: " + ISSUE.Title, "AUTHOR: " + ISSUE.User.Login + "\n" + "URL: " + ISSUE.Url + "\n" + "STATE: " + ISSUE.State);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("REPOS-COMMITS")]

        public async Task REPOSCOMMITS(string AUTHOR, string NAME, int PAGE = 0, [Remainder]string FILTERS = "") {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string GITURL = "https://github.com/" + AUTHOR + NAME + "/commits/";

            string[] FILTERARRAY = FILTERS.Split('⇒');

            DateTime DATECHECKER = DateTime.Now;

            DateTime UNTILDATE = DATECHECKER;
            DateTime SINCEDATE = DATECHECKER;

            string COMMITAUTHOR = "NONE";
            string PATH = "NONE";
            string SHA = "NONE";

            for(int i = 0; i < FILTERARRAY[i].Length; i++) {

                if(FILTERARRAY[i].StartsWith(" UNTIL: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 8);

                    UNTILDATE = DateTime.Parse(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" SINCE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 8);

                    SINCEDATE = DateTime.Parse(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" AUTHOR: ")) COMMITAUTHOR = FILTERARRAY[i].Remove(0, 9);
                if(FILTERARRAY[i].StartsWith(" PATH: ")) PATH = FILTERARRAY[i].Remove(0, 7);
                if(FILTERARRAY[i].StartsWith(" SHA: ")) SHA = FILTERARRAY[i].Remove(0, 6);
            }


            CommitRequest COMMITREQUEST = PARSER.COMMITREQUEST(DATECHECKER, UNTILDATE, SINCEDATE, COMMITAUTHOR, PATH, SHA, new string[] { AUTHOR, NAME });

            IReadOnlyList<GitHubCommit> COMMITLIST = await GITCLIENT.Repository.Commit.GetAll(AUTHOR, NAME, COMMITREQUEST);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("_8PQ_C6__")
                 .WithColor(DEFAULT)
                 .WithUrl(GITURL)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + $"{PAGE}");

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0;

            for(int i = 0 + 25 * PAGE; i < COMMITLIST.Count; i++) {

                GitHubCommit COMMIT = COMMITLIST[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("COMMIT: " + COMMIT.NodeId, "SHA: " + COMMIT.Sha + "\n" + "TOTAL: " + COMMIT.Stats.Total);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("SEARCH-USERS")]

        public async Task SEARCHUSERS(int PAGE = 0, [Remainder]string FILTERS = "") {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string[] FILTERARRAY = FILTERS.Split('⇒');

            Octokit.Range FOLLOWERSCOUNT = Octokit.Range.GreaterThanOrEquals(0);
            Octokit.Range REPOSITORIES = Octokit.Range.GreaterThanOrEquals(0);

            DateRange CREATIONDATE = DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(1999, 4, 1)));

            Language LANGUAGE = Language.Unknown;

            AccountSearchType USERTYPE = AccountSearchType.User;

            string LOCATION = "NONE";
            string USERNAME = "NONE";
            string EMAIL = "NONE";
            string FULLNAME = "NONE";

            for(int i = 0; i < FILTERARRAY.Length; i++) {

                if(FILTERARRAY[i].StartsWith(" FOLLOWERS: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 12);

                    string[] REQUESTARRAY = FILTERARRAY[i].Split(' ');

                    FOLLOWERSCOUNT = PARSER.RANGE(REQUESTARRAY);
                }

                if(FILTERARRAY[i].StartsWith(" CREATIONDATE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 15);

                    CREATIONDATE = PARSER.DATERANGE(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" LOCATION: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    LOCATION = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" REPOSITORIES: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 15);

                    string[] REQUESTARRAY = FILTERARRAY[i].Split(' ');

                    REPOSITORIES = PARSER.RANGE(REQUESTARRAY);
                }

                if(FILTERARRAY[i].StartsWith(" LANGUAGE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    LANGUAGE = PARSER.LANGUAGE(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" USERNAME: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    USERNAME = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" EMAIL: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 8);

                    EMAIL = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" FULLNAME: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    FULLNAME = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" USERTYPE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    USERTYPE = PARSER.ACCOUNTSEARCH(FILTERARRAY[i]);
                }
            }

            SearchUsersRequest USERSREQUEST = PARSER.USERSREQUEST(FOLLOWERSCOUNT, REPOSITORIES, CREATIONDATE, LOCATION, USERNAME, EMAIL, FULLNAME, LANGUAGE, USERTYPE);

            SearchUsersResult USERSRESULT = await GITCLIENT.Search.SearchUsers(USERSREQUEST);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("_8P_C7Q10__")
                 .WithColor(DEFAULT)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + PAGE);

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0;
            for(int i = 0 + 25 * PAGE; i < USERSRESULT.Items.Count; i++) {

                User USER = USERSRESULT.Items[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("USER: " + USER.Login, "EMAIL: " + USER.Email + "\n" + "ID: " + USER.Id + "\n" + "DISKUSAGE: " + USER.DiskUsage + "\n" + "URL:" + USER.Url);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("SEARCH-REPOS")]

        public async Task SEARCHREPOS(int PAGE = 0, [Remainder]string FILTERS = "") {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string[] FILTERARRAY = FILTERS.Split('⇒');

            Octokit.Range STARS = Octokit.Range.GreaterThanOrEquals(0);
            Octokit.Range SIZE = Octokit.Range.GreaterThan(0);
            Octokit.Range FORKS = Octokit.Range.GreaterThanOrEquals(0);

            ForkQualifier INCLUDEFORKS = ForkQualifier.IncludeForks;

            Language LANGUAGE = Language.Unknown;

            DateTime DATECHECKER = DateTime.Now;

            DateRange CREATIONDATE = DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(1999, 4, 1)));
            DateRange UPDATEDATE = DateRange.Between(new DateTimeOffset(new DateTime(1999, 4, 1)), DATECHECKER);

            string NAME = "NONE";
            string OWNER = "NONE";

            bool README = true;
            bool DESC = true;

            for(int i = 0; i < FILTERARRAY[i].Length; i++) {

                if(FILTERARRAY[i].StartsWith(" STARS: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 8);

                    string[] REQUESTARRAY = FILTERARRAY[i].Split(' ');

                    STARS = PARSER.RANGE(REQUESTARRAY);
                }

                if(FILTERARRAY[i].StartsWith(" SIZE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    string[] REQUESTARRAY = FILTERARRAY[i].Split(' ');

                    SIZE = PARSER.RANGE(REQUESTARRAY);
                }

                if(FILTERARRAY[i].StartsWith(" FORKS: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    string[] REQUESTARRAY = FILTERARRAY[i].Split(' ');

                    FORKS = PARSER.RANGE(REQUESTARRAY);
                }

                if(FILTERARRAY[i].StartsWith(" ONLYFORKS: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 12);

                    INCLUDEFORKS = PARSER.FORKQUALIFIER(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" LANGUAGE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    LANGUAGE = PARSER.LANGUAGE(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" CREATIONDATE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 15);

                    CREATIONDATE = PARSER.DATERANGE(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" UPDATEDATE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 13);

                    UPDATEDATE = PARSER.DATEBETWEEN(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" NAME: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    NAME = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" OWNER: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 8);

                    OWNER = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" README: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 9);

                    README = bool.Parse(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" DESC: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    DESC = bool.Parse(FILTERARRAY[i]);
                }
            }

            SearchRepositoriesRequest REPOSITORIESREQUEST = PARSER.REPOSITORIESREQUEST(STARS, SIZE, FORKS, INCLUDEFORKS, LANGUAGE, DATECHECKER, CREATIONDATE, UPDATEDATE, NAME, OWNER, README, DESC);

            SearchRepositoryResult REPOSITORYRESULT = await GITCLIENT.Search.SearchRepo(REPOSITORIESREQUEST);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("_5DQ_C80__")
                 .WithColor(DEFAULT)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + PAGE);

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0;
            for(int i = 0 + 25 * PAGE; i < REPOSITORYRESULT.Items.Count; i++) {

                Repository REPOSITORY = REPOSITORYRESULT.Items[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("REPOSITORY: " + REPOSITORY.FullName, "OWNER: " + REPOSITORY.Owner + "\n" + "ID: " + REPOSITORY.Id + "\n" + "URL: " + REPOSITORY.Url);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("SEARCH-CODE")]

        public async Task SEARCHCODE(int PAGE = 0, [Remainder]string FILTERS = "") {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            string[] FILTERARRAY = FILTERS.Split('⇒');

            string FILENAME = "NONE";
            string PATH = "NONE";
            string USER = "NONE";

            string AUTHOR = "NONE";
            string NAME = "NONE";

            Language LANGUAGE = Language.Unknown;

            bool FORKS = false;

            Octokit.Range SIZE = Octokit.Range.GreaterThan(0);

            for(int i = 0 + 25 * PAGE; i < FILTERARRAY[i].Length; i++) {

                if(FILTERARRAY[i].StartsWith(" FILENAME: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    FILENAME = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" PATH: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    PATH = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" AUTHOR: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 9);

                    AUTHOR = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" NAME: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    NAME = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" USER: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    USER = FILTERARRAY[i];
                }

                if(FILTERARRAY[i].StartsWith(" LANGUAGE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 11);

                    LANGUAGE = PARSER.LANGUAGE(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" FORKS: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 8);

                    FORKS = bool.Parse(FILTERARRAY[i]);
                }

                if(FILTERARRAY[i].StartsWith(" SIZE: ")) {

                    FILTERARRAY[i] = FILTERARRAY[i].Remove(0, 7);

                    string[] REQUESTARRAY = FILTERARRAY[i].Split(' ');

                    SIZE = PARSER.RANGE(REQUESTARRAY);
                }
            }

            if(AUTHOR == "NONE" || NAME == "NONE") return;

            SearchCodeRequest CODEREQUEST = PARSER.CODEREQUEST(FILENAME, PATH, LANGUAGE, FORKS, SIZE, USER, AUTHOR, NAME);

            SearchCodeResult CODERESULT = await GITCLIENT.Search.SearchCode(CODEREQUEST);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle("_CC8_6DT1__")
                 .WithColor(DEFAULT)
                 .WithFooter(FOOTER => FOOTER.Text = "PAGE: " + PAGE);

            if(PAGE > 0) PAGE--;
            if(PAGE < 0) PAGE = 0;

            uint ENCOUNTER = 0;
            for(int i = 0 + 25 * PAGE; i < CODERESULT.Items.Count; i++) {

                SearchCode CODE = CODERESULT.Items[i];

                ENCOUNTER++;
                if(ENCOUNTER > 25) break;

                EMBED.AddField("CODE: " + CODE.Name, "SHA: " + CODE.Sha + "\n" + "PATH: " + CODE.Path + "\n" + "URL: " + CODE.Url);
            }

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("ORGANIZATION")]

        public async Task ORGANIZATION(string NAME) {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            Organization ORGANIZATION = await GITCLIENT.Organization.Get(NAME);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(ORGANIZATION.Name)
                 .WithColor(DEFAULT)
                 .WithImageUrl(ORGANIZATION.AvatarUrl)
                 .WithUrl(ORGANIZATION.Url)
                 .AddField("LOCATION:", ORGANIZATION.Location)
                 .AddField("EMAIL:", ORGANIZATION.Email)
                 .AddField("BILLING:", ORGANIZATION.BillingAddress);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        [Command("PULL-REQUEST")]

        public async Task PULLREQUEST(string AUTHOR, string NAME, int NUMBER) {
            string APITOKEN = CONFIG.getApiToken();

            GitHubClient GITCLIENT = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials TOKENAUTH = new Credentials(APITOKEN);

            GITCLIENT.Credentials = TOKENAUTH;

            PullRequest PULLREQUEST = await GITCLIENT.PullRequest.Get(AUTHOR, NAME, NUMBER);

            EmbedBuilder EMBED = new EmbedBuilder();

            EMBED.WithTitle(PULLREQUEST.Title)
                 .WithColor(DEFAULT)
                 .AddField("DRAFT:", PULLREQUEST.Draft)
                 .AddField("STATE:", PULLREQUEST.State.Value)
                 .AddField("TOTAL:", PULLREQUEST.ChangedFiles);

            await Context.Channel.SendMessageAsync("", false, EMBED.Build());
        }

        //IN OTHER CLASS: GIT-API LIMIT COMMAND
        //IN OTHER CLASS: HELP COMMAND
    }
}