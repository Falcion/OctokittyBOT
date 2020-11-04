using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

using Octokit;

using Stratum.Body;

namespace Stratum.Core.Other
{
    public class Other : ModuleBase<SocketCommandContext>
    {
        /*
            The miscellaneous commands for displaying special information to bot's user.
            Detailed information about each can be found in the comments before the task itself.
        */

        /*
            Command: git@api
            Task: Get all specified information about GitAPI Status and etc.
            Arguments: none.
         */

        [Command("git@api")]

        public async Task GitApi()
        {
            string? GIT_TOKEN = Configuration.getGitToken();

            GitHubClient git = new GitHubClient(new ProductHeaderValue("Stratum"));
            Credentials tokenAuth = new Credentials(GIT_TOKEN);

            git.Credentials = tokenAuth;

            MiscellaneousRateLimit miscRates = await git.Miscellaneous.GetRateLimits();

            /*
                An array of API parameters for the next call to the GitHub API.
                In the appropriate order: core rates limits, search rates limits.
             */

            RateLimit[] RateParams = new RateLimit[] { miscRates.Resources.Core, miscRates.Resources.Search };

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("GitHub API Limits")
                 .WithColor(Color.Gold)
                 .WithCurrentTimestamp()
                 .AddField("Core Rates:", $"**Rates Limit:** {RateParams[0].Limit}\n**Rates Remaining:** {RateParams[0].Remaining}\n**Rates Reset (UTC):** {RateParams[0].Reset.UtcDateTime}")
                 .AddField("Search Rates:", $"**Rates Limit:** {RateParams[1].Limit}\n**Rates Remaining:** {RateParams[1].Remaining}\n**Rates Reset (UTC):** {RateParams[1].Reset.UtcDateTime}");

            await Context.Channel.SendMessageAsync(null, false, embed.Build());
        }

        /*
            Command: git@help
            Task: Get all information about specified command or display all commands.
            Arguments?: command.
         */

        [Command("git@help")]

        public async Task Help(string? arg = "all")
        {
            EmbedBuilder embed = new EmbedBuilder();

            string? _B9A = Configuration.getBotPrefix();

            switch(arg)
            {
                /* Simple commands block. */

                /*
                    Command: repos@info
                    Task: Getting basic information about a given repository. 
                    Arguments: repository's owner, repository's name.
                 */

                case "repos@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"`{_B9A}repos@info [repos owner] [repos name]`")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: branch@info
                    Task: Getting basic information about a given branch from specified repository. 
                    Arguments: repository's owner, repository's name, branch's name.
                 */

                case "branch@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given branch from specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}branch@info [repos owner] [repos name] [branch name]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the name of the branch, this parameter cannot be empty and does not contain spaces.");
                    
                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: release@info
                    Task: Getting basic information about a given release from specified repository.
                    Arguments: repository's owner, repository's name, release's tagname.
                 */

                case "release@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given release from specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}release@info [repos owner] [repos name] [tag of release]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the tag of the release, this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: issue@info
                    Task: Getting basic information about a given issue from specified repository.
                    Arguments: repository's owner, repository's name, issue's number.
                 */

                case "issue@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given issue from specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}issue@info [repos owner] [repos name] [number of issue]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the number of issue, this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: commit@info
                    Task: Getting basic information about a given commit from specified repository.
                    Arguments: repository's owner, repository's name, commit's SHA (reference).
                 */

                case "commit@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given commit from specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}commit@info [repos owner] [repos name] [reference of commit]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the reference of commit (SHA), this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: user@info
                    Task: Getting basic information about a given user.
                    Arguments: user's login.
                 */

                case "user@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given user by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}user@info [login]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of user, this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: branch@array
                    Task: Get a list of all branches in the specified repository.
                    Arguments: repository's owner, repository's name, page number.
                 */

                case "branch@array":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all branches in the specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}branch@array [repos owner] [repos name] (page number)")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the number of page.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: release@array
                    Task: Get a list of all releases in the specified repository.
                    Arguments: repository's owner, repository's name, page number.
                 */

                case "release@array":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all releases in the specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}release@array [repos owner] [repos name] (page number)")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the number of page, this parameter does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: org@info
                    Task: Getting basic information about a given organization. 
                    Arguments: organization's login.
                 */

                case "org@info":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given organization by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}org@info [login]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of organization, this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: pull@request
                    Task: Getting basic information about a given pull request. 
                    Arguments: repository's owner, repository's name, pull request's number.
                 */

                case "pull@request":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets basic information about a given pull request from specified repository by specified arguments.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}pull@request [repos owner] [repos name] [number of pull request]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the number of pull request, this parameter cannot be empty and does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /* Advanced commands block. */

                /*
                    Command: issue@array
                    Task: Get a list of all issues in the specified repository.
                    Arguments: repository's owner, repository's name, page number, filters syntax.
                 */

                case "issue@array":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all issues in the specified repository by specified arguments and filters.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}issue@array [repos owner] [repos name] [page number] [filters syntax]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the number of page, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #4", "In this parameter, you must specify a list of filters, thanks to which you want to find certain objects. For more information, you can use the dedicated syntax command.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: commit@array
                    Task: Get a list of all commits in the specified repository.
                    Arguments: repository's owner, repository's name, page number, filters syntax.
                 */

                case "commit@array":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all commits in the specified repository by specified arguments and filters.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}commit@array [repos owner] [repos name] [page number] [filters syntax]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the login of the repository owner, moreover, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify the name of the repository, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #3", "In this parameter, you must specify the number of page, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #4", "In this parameter, you must specify a list of filters, thanks to which you want to find certain objects. For more information, you can use the dedicated syntax command.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: user@find
                    Task: Get a list of all users by specified filters.
                    Arguments: page number, filters syntax.
                 */

                case "user@find":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all users by specified arguments and filters.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}user@find [page number] [filters syntax]")         
                         .AddField("Command parameter #1", "In this parameter, you must specify the number of page, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify a list of filters, thanks to which you want to find certain objects. For more information, you can use the dedicated syntax command.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: repos@find
                    Task: Get a list of all repos by specified filters.
                    Arguments: page number, filters syntax.
                 */

                case "repos@find":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all repos by specified arguments and filters.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}repos@find [page number] [filters syntax]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the number of page, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify a list of filters, thanks to which you want to find certain objects. For more information, you can use the dedicated syntax command.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: code@find
                    Task: Get a list of all codes by specified filters.
                    Arguments: page number, filters syntax.
                 */

                case "code@find":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets a list of all codes by specified arguments and filters.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}code@find [page number] [filters syntax]")
                         .AddField("Command parameter #1", "In this parameter, you must specify the number of page, this parameter cannot be empty and does not contain spaces.")
                         .AddField("Command parameter #2", "In this parameter, you must specify a list of filters, thanks to which you want to find certain objects. For more information, you can use the dedicated syntax command.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /* Miscellaneous commands block. */

                /*
                    Command: git@api
                    Task: Get all specified information about GitAPI Status and etc.
                    Arguments: none.
                 */

                case "git@api":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets all specified information about GitAPI Status and etc.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}git@api");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /*
                    Command: git@help
                    Task: Get all information about specified command or display all commands.
                    Arguments?: command.
                 */

                case "git@help":
                    embed.WithTitle("Information about command")
                         .WithDescription("This command gets all information about specified command or display all commands.")
                         .WithColor(Color.Teal)
                         .AddField("Default view:", $"{_B9A}git@help (command)")
                         .AddField("Command Parameter #1", "In this parameter, you must specify the command, this parameter does not contain spaces.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                /* Default display mode or displaying all of commands. */

                case "all":
                    embed.WithTitle("Groups of commands")
                         .WithColor(Color.Teal)
                         .AddField("_S9B", "The simplest commands for requests to the GitHub API.")
                         .AddField("_A0Q", "The advanced commands for requests to the GitHub API.")
                         .AddField("_M1C", "The miscellaneous commands for displaying special information to bot's user.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                case "_S9B":
                    embed.WithTitle("Simple commands of GitHub API")
                         .WithColor(Color.Teal)
                         .AddField("repos@info [repos owner] [repos name]", "This command gets basic information about a given repository by specified arguments.")
                         .AddField("branch@info [repos owner] [repos name] [branch name]", "This command gets basic information about a given branch from specified repository by specified arguments.")
                         .AddField("release@info [repos owner] [repos name] [tag of release]", "This command gets basic information about a given release from specified repository by specified arguments.")
                         .AddField("issue@info [repos owner] [repos name] [number of issue]", "This command gets basic information about a given issue from specified repository by specified arguments.")
                         .AddField("commit@info [repos owner] [repos name] [reference of commit]", "This command gets basic information about a given commit from specified repository by specified arguments.")
                         .AddField("user@info [login]", "This command gets basic information about a given user by specified arguments.")
                         .AddField("branch@array [repos owner] [repos name] (page number)", "This command gets a list of all branches in the specified repository by specified arguments.")
                         .AddField("release@array [repos owner] [repos name] (page number)", "This command gets a list of all releases in the specified repository by specified arguments.")
                         .AddField("org@info [login]", "This command gets basic information about a given organization by specified arguments.")
                         .AddField("pull@request [repos owner] [repos name] [number of pull request]", "This command gets basic information about a given pull request from specified repository by specified arguments.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                case "_A0Q":
                    embed.WithTitle("Advanced commands of GitHub API")
                         .WithColor(Color.Teal)
                         .AddField("issue@array [repos owner] [repos name] [page number] [filters syntax]", "This command gets a list of all issues in the specified repository by specified arguments and filters.")
                         .AddField("commit@array [repos owner] [repos name] [page number] [filters syntax]", "This command gets a list of all commits in the specified repository by specified arguments and filters.")
                         .AddField("user@find [page number] [filters syntax]", "This command gets a list of all users by specified arguments and filters.")
                         .AddField("repos@find [page number] [filters syntax]", "This command gets a list of all repos by specified arguments and filters.")
                         .AddField("code@find [page number] [filters syntax]", "This command gets a list of all codes by specified arguments and filters.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                case "_M1C":
                    embed.WithTitle("Miscellaneous commands of GitHub API")
                         .WithColor(Color.Teal)
                         .AddField("git@api", "This command gets all specified information about GitAPI Status and etc.")
                         .AddField("git@help (command)", "This command gets all information about specified command or display all commands.")

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;

                default:
                    embed.WithTitle("Groups of commands")
                         .WithColor(Color.Teal)
                         .AddField("_S9B", "The simplest commands for requests to the GitHub API.")
                         .AddField("_A0Q", "The advanced commands for requests to the GitHub API.")
                         .AddField("_M1C", "The miscellaneous commands for displaying special information to bot's user.");

                    await Context.Channel.SendMessageAsync(null, false, embed.Build());
                    break;
            }
        }
    }
}
