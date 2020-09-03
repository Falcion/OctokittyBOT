using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using System;
using Discord;

namespace Stratum {

    public class Main : ModuleBase<SocketCommandContext> {

        [Command("search-users")]

        public async Task SearchUsers(int page, [Remainder]string filters) {

            string apiToken
                    = Storage.apiToken;

            GitHubClient gitClient
                    = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            Octokit.Range followersCount 
                        = Octokit.Range.GreaterThanOrEquals(0);

            DateRange creationDate 
                    = DateRange.GreaterThanOrEquals(new DateTime(2015, 9, 15));

            Octokit.Range repositories
                        = Octokit.Range.GreaterThanOrEquals(0);

            Language language
                        = Language.Unknown;

            AccountSearchType accountType = AccountSearchType.User;

            string location = "none",
                   username = "none",
                   email = "none",
                   fullname = "none";

            int parsingChecker = 144;

            string[] filterArray = filters.Split("/ +/");

            for(int i = 0; i < filterArray.Length; i++) {

                if(filterArray[i].StartsWith(" followers: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 12);

                    string[] requesterArray = filterArray[i].Split(' ');

                    for(int j = 0; j < requesterArray.Length; j++) {
                        if(int.Parse(requesterArray[j]).GetType() 
                                                        == parsingChecker.GetType()) {

                            followersCount 
                                = new FollowersRequester().FollowersRegister(requesterArray[0], requesterArray[1]);
                        }
                    }
                }

                if(filterArray[i].StartsWith(" creation-date: ")) {

                    filterArray[i] 
                        = filterArray[i].Remove(0, 16);

                    creationDate
                        = new DateRequester().DateRegister(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" location: ")) {

                    filterArray[i]
                        = filterArray[i].Remove(0, 11);

                    location = filterArray[i];
                }

                if(filterArray[i].StartsWith(" repositories: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 15);

                    string[] requesterArray = filterArray[i].Split(' ');

                    for(int j = 0; j < requesterArray.Length; j++) {
                        if(int.Parse(requesterArray[j]).GetType() 
                                                        == parsingChecker.GetType()) {

                            repositories 
                                = new RepositoryRequester().RepositoryRegister(requesterArray[0], requesterArray[1]);
                        }
                    }
                }

                if(filterArray[i].StartsWith(" language: "))
                        language = new LanguageRequester().LanguageRegister(filterArray[i]);

                if(filterArray[i].StartsWith(" username: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 11);

                    username = filterArray[i];
                }

                if(filterArray[i].StartsWith(" email: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 11);

                    if(filterArray[i].Contains('@')) return;

                    email = filterArray[i];
                }

                if(filterArray[i].StartsWith(" fullname: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 11);

                    fullname = filterArray[i];
                }

                if(filterArray[i].StartsWith(" account-type: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 15);

                    accountType
                            = new AccounterRequester().AccounterRegister(filterArray[i]);
                }
            }

            if(username == "none") return;

            SearchUsersRequest usersRequest
                        = new UseringRequester().UseringRegister(followersCount, creationDate, location, repositories, language, username, email, fullname, accountType);

            SearchUsersResult usersResult
                        = await gitClient.Search.SearchUsers(usersRequest);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Search Users Request - Result")
                                                        .WithDescription("Current list's count: " + usersResult.TotalCount + ". If you want to see all of users, please type next page's number.")
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithFooter(
                                                            footer => footer.Text = "Page: " + page.ToString()
                                                        );

            if(page > 0) page--;
            else if(page <= 0) page = 0;

            int algBreaker = 0;
            for(int i = 0 + 25 * page; i < usersResult.Items.Count; i++) {
                
                algBreaker++;
                if(algBreaker == 25) break;

                string userInfo = "Email: " + usersResult.Items[i].Email + "\nBio: " + usersResult.Items[i].Bio + "\nURL: " + usersResult.Items[i].Url;

                messageEmbed.AddField(usersResult.Items[i].Name, userInfo);
            }

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}