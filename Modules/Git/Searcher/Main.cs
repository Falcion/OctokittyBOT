using Discord.Commands;
using System.Threading.Tasks;
using Octokit;
using System;
using Discord;

namespace Stratum {

    public class Main : ModuleBase<SocketCommandContext> {

        [Command("search-users")]

        public async Task SearchUsers(string gitUser, int page, [Remainder]string filters) {

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
            }
        }
    }
}