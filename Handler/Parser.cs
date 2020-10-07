using System;

using Octokit;

namespace Stratum {

    public class Parser {

        public IssueFilter ISSUEFILTER(string FILTERSTRING) {
            switch(FILTERSTRING) {

                case "ALL": return IssueFilter.All;
                case "ASSIGNED": return IssueFilter.Assigned;
                case "CREATED": return IssueFilter.Created;
                case "MENTIONED": return IssueFilter.Mentioned;
                case "SUBSCRIBED": return IssueFilter.Subscribed;
            }

            return IssueFilter.All;
        }

        public RepositoryIssueRequest ISSUEREQUEST(IssueFilter ISSUEFILTER, string ISSUECREATOR, string ISSUEMENTIONED, string ISSUEASSIGNEE, string ISSUEMILESTONE) {
            
            if(ISSUECREATOR != "NONE") {

                if(ISSUEMENTIONED != "NONE") {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }

                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Mentioned = ISSUEMENTIONED,

                            };
                        }
                    }

                } else {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }
                        
                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Creator = ISSUECREATOR,

                            };
                        }
                    }
                }

            } else {

                if(ISSUEMENTIONED != "NONE") {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }

                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Mentioned = ISSUEMENTIONED,

                            };
                        }
                    }

                } else {

                    if(ISSUEASSIGNEE != "NONE") {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Assignee = ISSUEASSIGNEE,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Assignee = ISSUEASSIGNEE,

                            };
                        }
                        
                    } else {

                        if(ISSUEMILESTONE != "NONE") {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,
                                Milestone = ISSUEMILESTONE,

                            };

                        } else {

                            return new RepositoryIssueRequest() {
                                
                                Filter = ISSUEFILTER,

                            };
                        }
                    }
                }
            }
        }

        public CommitRequest COMMITREQUEST(DateTime DATECHECKER, DateTime UNTILDATE, DateTime SINCEDATE, string COMMITAUTHOR, string PATH, string SHA, string[] REPOSITORY) {

            if(SINCEDATE != DATECHECKER) {

                if(COMMITAUTHOR != "NONE") {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }
                    }

                } else {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Path = PATH,
                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Path = PATH,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Sha = SHA,
                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Since = SINCEDATE,
                                Until = UNTILDATE,
                            };
                        }
                    }
                }

            } else {

                if(COMMITAUTHOR != "NONE") {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Path = PATH,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Author = COMMITAUTHOR,
                                Until = UNTILDATE,
                            };
                        }
                    }

                } else {

                    if(PATH != "NONE") {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Path = PATH,
                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Path = PATH,
                                Until = UNTILDATE,
                            };
                        }

                    } else {

                        if(SHA != "NONE") {

                            return new CommitRequest() {

                                Sha = SHA,
                                Until = UNTILDATE,
                            };

                        } else {

                            return new CommitRequest() {

                                Until = UNTILDATE,
                            };
                        }
                    }
                }
            }
        } 
    }
}