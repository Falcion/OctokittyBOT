using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using Discord;
using System.IO;

namespace Stratum
{
    public class Git : ModuleBase<SocketCommandContext>
    {
        Color msgColor = new Color(0x4FEFC8);

        [Command("repos-show")]

        public async Task ReposAsync(string reposName, string gitAuthor)
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var user = await gitClient.User.Get(gitAuthor);

            Repository repos = await gitClient.Repository.Get(gitAuthor, reposName);

            EmbedBuilder reposEmbed = new EmbedBuilder();

            string license = "";

            if(repos.License == null) license = "Лицензия отсутствует";
            else license = repos.License.Name;

            reposEmbed.WithTitle("Репозитория GitHub")
                      .WithColor(msgColor)
                      .WithCurrentTimestamp()
                      .WithThumbnailUrl(user.AvatarUrl)
                      .AddField("Описание репозитории:", repos.Description)
                      .AddField("ID репозитории:", $"{repos.Id}")
                      .AddField("Лицензия репозитории:", license)
                      .AddField("Дата создания:", $"{repos.CreatedAt}")
                      .AddField("Наименование репозитории:", repos.Name)
                      .AddField("Последнее обновление:", $"{repos.UpdatedAt}");

            await Context.Channel.SendMessageAsync("", false, reposEmbed.Build());
        }

        [Command("repos-branches")]

        public async Task Branches(string reposName, string reposAuthor)
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var reposBranches = await gitClient.Repository.Branch.GetAll(reposAuthor, reposName);

            EmbedBuilder branchesEmbed = new EmbedBuilder();

            branchesEmbed.WithTitle("Ветки репозитории")
                         .WithColor(msgColor)
                         .WithCurrentTimestamp()
                         .AddField("Ссылка на все ветки:", $"https://github.com/{reposAuthor}/{reposName}/branches");


            int branchesCount = reposBranches.Count;

            if(branchesCount > 24)
            {
                while (branchesCount > 24) branchesCount--;
            }

            for(int i = 0; i < branchesCount; i++)
            {
                Branch branchElement = reposBranches[i];
                branchesEmbed.AddField($"Ветка #{i}:", $"{branchElement.Name}");
            }

            await Context.Channel.SendMessageAsync("", false, branchesEmbed.Build());

        }

        [Command("repos-releases")]

        public async Task Releases(string reposName, string reposAuthor)
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var releases = await gitClient.Repository.Release.GetAll(reposAuthor, reposName);

            var user = await gitClient.User.Get(reposAuthor);

            int reposReleases = releases.Count;
            string isNan = "Да.";

            EmbedBuilder releaseEmbed = new EmbedBuilder();

            if (reposReleases > 22)
            {
                while (reposReleases > 22) reposReleases--;
                isNan = "Нет.";
            }

            releaseEmbed.WithAuthor("Выпуски репозитории")
                        .WithColor(msgColor)
                        .WithCurrentTimestamp()
                        .WithThumbnailUrl(user.AvatarUrl)
                        .AddField("Общее количество выпусков:", $"{releases.Count}")
                        .AddField("Полный ли список:", isNan)
                        .AddField("Ссылка на выпуски репозитории:", $"https://github.com/{reposAuthor}/{reposName}/releases");
                
            for(int i = 0; i < reposReleases; i++)
            {
                Release releaseElement = releases[i];
                releaseEmbed.AddField(releaseElement.Name, releaseElement.Id);
            }

            await Context.Channel.SendMessageAsync("", false, releaseEmbed.Build());
        }

        [Command("repos-issues")]

        public async Task Issues(string reposName, string reposAuthor, ushort days = 14)
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var recentlyIssues = new RepositoryIssueRequest
            {
                Filter = IssueFilter.All,
                State = ItemStateFilter.Open,
                Since = DateTimeOffset.Now.Subtract(TimeSpan.FromDays(days))
            };

            var issues = await gitClient.Issue.GetAllForRepository(reposAuthor, reposName, recentlyIssues);

            int issuesCount = issues.Count;

            EmbedBuilder issuesEmbed = new EmbedBuilder();

            if (issuesCount > 22)
            {
                while (issuesCount > 22) issuesCount--;
            }

            var allIssues = await gitClient.Issue.GetAllForRepository(reposAuthor, reposName);
            int repIssues = allIssues.Count;

            issuesEmbed.WithAuthor("Темы репозитории")
                       .WithColor(msgColor)
                       .WithCurrentTimestamp()
                       .AddField("Всего открытых тем:", $"{issues.Count}")
                       .AddField("Всего тем:", $"{repIssues}")
                       .AddField("Ссылка на темы репозитории:", $"https://github.com/{reposAuthor}/{reposName}/issues");

            for(int i = 0; i < issuesCount; i++)
            {
                Issue issueElement = issues[i];
                issuesEmbed.AddField(issueElement.Title, $"{issueElement.UpdatedAt}");
            }

            await Context.Channel.SendMessageAsync("", false, issuesEmbed.Build());
        }

        [Command("repos-commits")]

        public async Task Commits(string reposName, string reposAuthor, string commitBranch = "master")
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var commits = await gitClient.Repository.Commit.GetAll(reposAuthor, reposName);

            int commitsCount = commits.Count;

            if(commitsCount > 23)
            {
                while (commitsCount > 23) commitsCount--;
            }

            EmbedBuilder commitEmbed = new EmbedBuilder();

            commitEmbed.WithTitle("Обновления репозитории")
                       .WithColor(msgColor)
                       .WithCurrentTimestamp()
                       .AddField("Всего обновлений:", $"{commits.Count}")
                       .AddField("Ссылка на обновления (по указанной ветке):", $"https://github.com/{reposAuthor}/{reposName}/commits/{commitBranch}");

            for(int i = 0; i < commitsCount; i++)
            {
                GitHubCommit commitElement = commits[i];
                commitEmbed.AddField($"{commitElement.HtmlUrl}", $"`GitHub API Url:` {commitElement.Url}");
            }

            await Context.Channel.SendMessageAsync("", false, commitEmbed.Build());
        }

        [Command("gitapi-limit")]
        [RequireOwner]

        public async Task ApiLimit()
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var miscRate = await gitClient.Miscellaneous.GetRateLimits();

            var coreRate = miscRate.Resources.Core;

            var corePerHour = coreRate.Limit;
            var coreLeft = coreRate.Remaining;
            var coreReset = coreRate.Reset;

            EmbedBuilder coreEmbed = new EmbedBuilder();

            coreEmbed.WithTitle("Основные запросы")
                     .WithColor(msgColor)
                     .AddField("Основных запросов в час:", $"{corePerHour}")
                     .AddField("Осталось основных запросов:", $"{coreLeft}")
                     .AddField("Сброс основных запросов:", $"{coreReset}");

            await Context.Channel.SendMessageAsync("", false, coreEmbed.Build());

            var searchRate = miscRate.Resources.Search;

            var searchPerMinute = searchRate.Limit;
            var searchLeft = searchRate.Remaining;
            var searchResest = searchRate.Reset;

            EmbedBuilder searchEmbed = new EmbedBuilder();

            searchEmbed.WithTitle("Поисковые запросы")
                     .WithColor(msgColor)
                     .AddField("Поисковых запросов в минуту:", $"{searchPerMinute}")
                     .AddField("Осталось поисковых запросов:", $"{searchLeft}")
                     .AddField("Сброс поисковых запросов:", $"{searchResest}");

            await Context.Channel.SendMessageAsync("", false, searchEmbed.Build());
        }
    }
}
