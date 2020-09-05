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
                    = DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(2011, 4, 1)));

            Octokit.Range repositories
                        = Octokit.Range.GreaterThanOrEquals(0);

            Language language
                        = Language.Unknown;

            AccountSearchType accountType = AccountSearchType.User;

            string location = "none",
                   username = "none",
                   email = "none",
                   fullname = "none";

            string[] filterArray = filters.Split("/ +/");

            for(int i = 0; i < filterArray.Length; i++) {

                if(filterArray[i].StartsWith(" followers: ")) {

                    filterArray[i]
                            = filterArray[i].Remove(0, 12);

                    string[] requesterArray = filterArray[i].Split(' ');

                    followersCount 
                        = new FollowersRequester().FollowersRegister(requesterArray[0], requesterArray[1]);
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

                    repositories 
                        = new RepositoryRequester().RepositoryRegister(requesterArray[0], requesterArray[1]);
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

        [Command("search-repos")]

        public async Task SearchRepos(int page, [Remainder]string filters) {

            string apiToken
                    = Storage.apiToken;

            GitHubClient gitClient
                    = new GitHubClient(new ProductHeaderValue("Stratum"));

            Credentials tokenAuth
                        = new Credentials(apiToken);

            gitClient.Credentials = tokenAuth;

            Octokit.Range starsRange = Octokit.Range.GreaterThanOrEquals(0),
                  sizeRange = Octokit.Range.GreaterThan(0),
                  forksRange = Octokit.Range.GreaterThanOrEquals(0);

            ForkQualifier includeForks = ForkQualifier.IncludeForks;

            Language language = Language.Unknown;

            DateTime dateParser = DateTime.Now;
            DateRange creationDate = DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1))),
                      updateDate = DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

            string[] filterArray = filters.Split("/ +/");

            string name = "none",
                   owner = "none";

            bool readme = true,
                 desc = true;

            for(int i = 0; i < filterArray.Length; i++) {

                if(filterArray[i].StartsWith(" starts: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 9);

                    string[] indexer = filterArray[i].Split(' ');

                    starsRange
                        = new RangeRequester().RangeRegister(indexer[0], indexer[1]);
                }

                if(filterArray[i].StartsWith(" size: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 7);

                    string[] indexer = filterArray[i].Split(' ');

                    sizeRange
                        = new SizeRequester().SizeRegister(indexer[0], indexer[1]);
                }

                if(filterArray[i].StartsWith(" forks: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 8);

                    string[] indexer = filterArray[i].Split(' ');

                    forksRange
                        = new RangeRequester().RangeRegister(indexer[0], indexer[1]);
                }

                if(filterArray[i].StartsWith(" only-forks: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 13);

                    includeForks
                        = new ForkerRequester().ForkerRegister(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" language: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 11);

                    language
                        = new LanguageRequester().LanguageRegister(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" readme: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 9);

                    readme = bool.Parse(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" desc: ")) {

                    filterArray[i] = 
                            filterArray[i].Remove(0, 7);

                    desc = bool.Parse(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" name: ")) {

                    filterArray[i] =
                            filterArray[i].Remove(0, 7);

                    name = filterArray[i];
                }

                if(filterArray[i].StartsWith(" creation-date: ")) {

                    filterArray[i] = 
                            filterArray[i].Remove(0, 16);

                    creationDate =
                        new DateRequester().DateRegister(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" update-date: ")) {

                    filterArray[i] = 
                            filterArray[i].Remove(0, 14);

                    updateDate
                        = new UpdateRequester().UpdateRegister(filterArray[i]);
                }

                if(filterArray[i].StartsWith(" owner: ")) {

                    filterArray[i] = 
                            filterArray[i].Remove(0, 8);

                    owner = filterArray[i];
                }
            }

            SearchRepositoriesRequest repositoriesRequest 
                = new RepositoringRequester().RepositoringRegister(starsRange, sizeRange, forksRange, includeForks, language, readme, desc, name, creationDate, updateDate, owner, dateParser);
            
            SearchRepositoryResult repositoryResult
                = await gitClient.Search.SearchRepo(repositoriesRequest);

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("Search Repositories Request - Result")
                                                        .WithDescription("Current list's count: " + repositoryResult.TotalCount + ". If you want to see all of users, please type next page's number.")
                                                        .WithColor(Color.Default)
                                                        .WithCurrentTimestamp()
                                                        .WithFooter(
                                                            footer => footer.Text = "Page: " + page.ToString()
                                                        );

            if(page > 0) page--;
            else if(page <= 0) page = 0;

            int algBreaker = 0;
            for(int i = 0 + 25 * page; i < repositoryResult.Items.Count; i++) {
                
                algBreaker++;
                if(algBreaker == 25) break;

                string reposInfo = "Archived: ``" + repositoryResult.Items[i].Archived + "``\nLanguage: ``" + repositoryResult.Items[i].Language + "``\nRepository's URL: ``" + repositoryResult.Items[i].Url + "``";

                messageEmbed.AddField(repositoryResult.Items[i].FullName, reposInfo);
            }

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}