using Octokit;

public class UseringRequester {

    public SearchUsersRequest UseringRegister(Range followers, DateRange creationDate, string location, Range repos, Language language, string username, string email, string fullname, AccountSearchType account) {

        if(location != "none") {

            if(email != "none") {

                if(fullname != "none") {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Location = location,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username, UserInQualifier.Email, UserInQualifier.Fullname },
                    };
                }

                else {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Location = location,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username, UserInQualifier.Email },
                    };
                }
            }

            else {

                if(fullname != "none") {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Location = location,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username, UserInQualifier.Fullname },
                    };
                }

                else {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Location = location,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username },
                    };
                }
            }
        }

        else {

            if(email != "none") {

                if(fullname != "none") {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username, UserInQualifier.Email, UserInQualifier.Fullname },
                    };
                }

                else {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username, UserInQualifier.Email },
                    };
                }
            }

            else {

                if(fullname != "none") {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username, UserInQualifier.Fullname },
                    };
                }

                else {

                    return new SearchUsersRequest(username) {

                        Followers = followers,
                        Created = creationDate,
                        Repositories = repos,
                        AccountType = account,
                        Language = language,

                        In = new[] { UserInQualifier.Username },
                    };
                }
            }
        }
    }
}