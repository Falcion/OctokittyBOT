﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

using Octokit;

namespace Stratum.Core
{
    public class Body : ModuleBase<SocketCommandContext>
    {
        /*
            The simplest commands for requests to the GitHub API.
            Detailed information about each can be found in the comments before the task itself.
         */

        /*
            Command: repos@info
            Task: Getting basic information about a given repository. 
            Arguments: repository's owner, repository's name.
         */

        [Command("repos@info")]

        public async Task ReposInfo(string? owner, string? name)
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            User? reposOwner = await git.User.Get(owner);

            Repository? repository = await git.Repository.Get(owner, name);

            EmbedBuilder embed = new EmbedBuilder();

            string? reposLicense = repository.License.Name;

            embed.WithTitle("Repository's Information")
                 .WithColor(Color.Blue)
                 .WithUrl(repository.Url)
                 .WithThumbnailUrl(reposOwner.AvatarUrl)
                 .AddField("Repo's ID:", repository.Id)
                 .AddField("Repo's License:", reposLicense)
                 .AddField("Creation Date:", $"{repository.CreatedAt}")
                 .AddField("Last Update:", $"{repository.UpdatedAt}");

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: branch@info
            Task: Getting basic information about a given branch from specified repository. 
            Arguments: repository's owner, repository's name, branch's name.
         */

        [Command("branch@info")]

        public async Task BranchInfo(string? owner, string? name, string? branchName = "main")
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            Branch? branch = await git.Repository.Branch.Get(owner, name, branchName);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Branch Information")
                 .WithColor(Color.Blue)
                 .WithUrl($"https://github.com/{owner}/{name}/tree/{branchName}")
                 .AddField("Name:", branch.Name)
                 .AddField("Protected:", branch.Protected)
                 .AddField("SHA:", branch.Commit.Sha);

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: release@info
            Task: Getting basic information about a given release from specified repository.
            Arguments: repository's owner, repository's name, release's tagname.
         */

        [Command("release@info")]

        public async Task ReleaseInfo(string? owner, string? name, string? tag)
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            Release release = await git.Repository.Release.Get(owner, name, tag);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Release Information")
                 .WithColor(Color.Blue)
                 .WithUrl(release.Url)
                 .AddField("Tag:", release.TagName)
                 .AddField("ID:", release.Id)
                 .AddField("Target:", release.TargetCommitish)
                 .AddField("Zipball URL:", release.ZipballUrl);

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: issue@info
            Task: Getting basic information about a given issue from specified repository.
            Arguments: repository's owner, repository's name, issue's number.
         */

        [Command("issue@info")]

        public async Task IssueInfo(string? owner, string? name, int number)
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            Issue issue = await git.Issue.Get(owner, name, number);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Issue Information")
                 .WithColor(Color.Blue)
                 .WithUrl(issue.Url)
                 .AddField("ID:", issue.Id)
                 .AddField("State:", issue.State.StringValue)
                 .AddField("Comments:", issue.Comments)
                 .AddField("URL:", issue.Url);

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: commit@info
            Task: Getting basic information about a given commit from specified repository.
            Arguments: repository's owner, repository's name, commit's SHA (reference).
         */

        [Command("commit@info")]

        public async Task CommitInfo(string? owner, string? name, string? sha)
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            GitHubCommit commit = await git.Repository.Commit.Get(owner, name, sha);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Commit's Information")
                 .WithColor(Color.Blue)
                 .WithUrl(commit.Url)
                 .AddField("Reference:", commit.Ref)
                 .AddField("Author:", commit.Author.Login)
                 .AddField("Total:", commit.Stats.Total);

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: user@info
            Task: Getting basic information about a given user.
            Arguments: user's login.
         */

        [Command("user@info")]

        public async Task UserInfo(string? login)
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            User user = await git.User.Get(login);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("User Information")
                 .WithColor(Color.Blue)
                 .WithUrl(user.Url)
                 .WithImageUrl(user.AvatarUrl)
                 .AddField("Email:", user.Email)
                 .AddField("ID:", user.Id)
                 .AddField("Followers:", user.Followers)
                 .AddField("Disk Usage:", user.DiskUsage)
                 .AddField("Repos:", user.PublicRepos + user.TotalPrivateRepos);

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }
    }
}
