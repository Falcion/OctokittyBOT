using Discord;
using Discord.Commands;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Stratum
{
    public class AdvanceGit : ModuleBase<SocketCommandContext>
    {
        Color msgColor = new Color(0x4FEFC8);

        [Command("repos-advshow")]

        public async Task AdvancedRepos(string reposName, string gitAuthor)
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var user = await gitClient.User.Get(gitAuthor);

            Repository repos = await gitClient.Repository.Get(gitAuthor, reposName);

            EmbedBuilder reposEmbed = new EmbedBuilder();

            reposEmbed.WithTitle("Подробная информация о репозитории:")
                      .WithColor(msgColor)
                      .WithCurrentTimestamp()
                      .WithThumbnailUrl(user.AvatarUrl)
                      .AddField("AllowMergeCommit:", $"{repos.AllowMergeCommit.Value}")
                      .AddField("AllowRebaseMerge:", $"{repos.AllowRebaseMerge.Value}")
                      .AddField("AllowSquashMerge:", $"{repos.AllowSquashMerge.Value}")
                      .AddField("Архивирован ли:", $"{repos.Archived}")
                      .AddField("Стандартная ветка:", $"{repos.DefaultBranch}")
                      .AddField("Является ли Fork:", $"{repos.Fork}")
                      .AddField("Количество Fork:", $"{repos.ForksCount}")
                      .AddField("Размер репозитории:", $"{repos.Size}");    

            await Context.Channel.SendMessageAsync("", false, reposEmbed.Build());
        }
        
        [Command("repos-advbranches")]

        public async Task AdvancedBranches(string reposName, string reposAuthor, string branchName) 
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var reposBranches = await gitClient.Repository.Branch.GetAll(reposAuthor, reposName);

            var correctBranch = reposBranches.Where(branch => branch.Name == branchName).ElementAt(0);

            EmbedBuilder branchEmbed = new EmbedBuilder();

            branchEmbed.WithTitle("Информация о ветке репозитории")
                       .WithColor(msgColor)
                       .WithCurrentTimestamp()
                       .AddField("Название ветки репозитории:", correctBranch.Name)
                       .AddField("Защищеща ли ветка:", $"{correctBranch.Protected}")
                       .AddField("Sha-код последнего обновления ветки:", $"{correctBranch.Commit.Sha}");

            await Context.Channel.SendMessageAsync("", false, branchEmbed.Build());
        } 

        [Command("repos-advreleases")]
        
        public async Task AdvancedReleases(string reposName, string reposAuthor, [Remainder]string releaseName) 
        {
            string token = File.ReadAllText("api-token.conf");

            var tokenAuth = new Credentials(token);
            var gitClient = new GitHubClient(new ProductHeaderValue("Stratum"));
            gitClient.Credentials = tokenAuth;

            var reposReleases = await gitClient.Repository.Release.GetAll(reposAuthor, reposName);

            var correctRelease = reposReleases.Where(release => release.Name == releaseName).ElementAt(0);

            EmbedBuilder releaseEmbed = new EmbedBuilder();

            releaseEmbed.WithTitle("Продвинутая информация о выпуске")
                        .WithColor(msgColor)
                        .WithCurrentTimestamp()
                        .AddField("Название выпуска:", correctRelease.Name)
                        .AddField("Наименования тэга выпуска:", correctRelease.TagName)
                        .AddField("Ветка:", correctRelease.TargetCommitish)
                        .AddField("Upload-URL выпуска:", correctRelease.UploadUrl)
                        .AddField("URL выпуска:", correctRelease.Url)
                        .AddField("Дата выпуска:", $"{correctRelease.PublishedAt}")
                        .AddField("Архив-URL:", $"{correctRelease.ZipballUrl}");

            await Context.Channel.SendMessageAsync("", false, releaseEmbed.Build());
        }
    }
}
