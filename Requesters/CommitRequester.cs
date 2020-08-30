using Octokit;
using System;

public class CommitRequester {

    public CommitRequest CommitRegister(string author, string path, string sha, DateTime untilDate, DateTime sinceDate, DateTime dateChecker) {

        if(author != "none") {

            if(path != "none") {

                if(sha != "none") {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Author = author,
                            Path = path,
                            Sha = sha,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Author = author,
                            Path = path,
                            Sha = sha,
                            Until = untilDate,
                        };

                    }
                }

                else {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Author = author,
                            Path = path,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Author = author,
                            Path = path,
                            Until = untilDate,
                        };

                    }
                }
            }

            else {

                if(sha != "none") {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Author = author,
                            Sha = sha,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Author = author,
                            Sha = sha,
                            Until = untilDate,
                        };

                    }
                }

                else {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Author = author,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Author = author,
                            Until = untilDate,
                        };

                    }
                }
            }
        }

        else {

            if(path != "none") {

                if(sha != "none") {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Path = path,
                            Sha = sha,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Path = path,
                            Sha = sha,
                            Until = untilDate,
                        };

                    }
                }

                else {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Path = path,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Path = path,
                            Until = untilDate,
                        };

                    }
                }
            }

            else {

                if(sha != "none") {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Sha = sha,
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Sha = sha,
                            Until = untilDate,
                        };

                    }
                }

                else {

                    if(sinceDate != dateChecker) {

                        return new CommitRequest() {
                            Since = sinceDate,
                            Until = untilDate,
                        };
                    }

                    else {

                        return new CommitRequest() {
                            Until = untilDate,
                        };

                    }
                }
            }
        }
    }
}