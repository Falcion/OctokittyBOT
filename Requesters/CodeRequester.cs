using Octokit;

public class CodeRequester {

    public SearchCodeRequest CodeRegister(string filename, string path, Language language, bool forks, Range size, string user, string reposOwner, string reposName) {

        if(reposOwner != "none") {

            if(user != "none") {
                
                if(path != "none") {

                    return new SearchCodeRequest("auth", reposOwner, reposName) {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        Path = path,
                        FileName = filename,
                        User = user,
                    };
                }

                else {

                    return new SearchCodeRequest("auth", reposOwner, reposName) {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        FileName = filename,
                        User = user,
                    };
                }
            }

            else {

                if(path != "none") {

                    return new SearchCodeRequest("auth", reposOwner, reposName) {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        Path = path,
                        FileName = filename,
                    };
                }

                else {

                    return new SearchCodeRequest("auth", reposOwner, reposName) {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        FileName = filename,
                    };
                }
            }
        }

        else {
            
            if(user != "none") {
                
                if(path != "none") {

                    return new SearchCodeRequest("auth") {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        Path = path,
                        FileName = filename,
                        User = user,
                    };
                }

                else {

                    return new SearchCodeRequest("auth") {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        FileName = filename,
                        User = user,
                    };
                }
            }

            else {

                if(path != "none") {

                    return new SearchCodeRequest("auth") {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        Path = path,
                        FileName = filename,
                    };
                }

                else {

                    return new SearchCodeRequest("auth") {

                        In = new[] { CodeInQualifier.File, CodeInQualifier.Path },
                            
                        Language = language,
                        Forks = forks,
                        Size = size,
                        FileName = filename,
                    };
                }
            }
        }
    }
}