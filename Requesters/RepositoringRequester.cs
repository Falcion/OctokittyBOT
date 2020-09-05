using Octokit;
using System;

public class RepositoringRequester {

    public SearchRepositoriesRequest RepositoringRegister(Octokit.Range starsRange, Octokit.Range sizeRange, Octokit.Range forksRange, ForkQualifier includeForks, Language language, bool readme, bool desc, string name, DateRange creationDate, DateRange updateDate, string owner, DateTime dateParser) {

        if(readme != false) {

            if(desc != false) {

                if(owner != "none") {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                Created = creationDate,

                                User = owner,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                User = owner,
                            };
                        }
                    }
                }

                else {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                Created = creationDate,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },
                            };
                        }
                    }
                }
            }

            else {

                if(owner != "none") {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                Created = creationDate,

                                User = owner,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                User = owner,
                            };
                        }
                    }
                }

                else {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                Created = creationDate,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },

                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Readme, InQualifier.Name },
                            };
                        }
                    }
                }
            }
        }

        else {

            if(desc != false) {

                if(owner != "none") {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                Created = creationDate,

                                User = owner,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                User = owner,
                            };
                        }
                    }
                }

                else {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                Created = creationDate,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },

                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Description, InQualifier.Name },
                            };
                        }
                    }
                }
            }

            else {

                if(owner != "none") {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                Created = creationDate,

                                User = owner,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                Updated = updateDate,

                                User = owner,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                User = owner,
                            };
                        }
                    }
                }

                else {

                    if(creationDate != DateRange.GreaterThan(new DateTimeOffset(new DateTime(2011, 4, 1)))) {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                Created = creationDate,
                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                Created = creationDate,
                            };
                        }
                    }

                    else {

                        if(updateDate != DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), dateParser)) {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },

                                Updated = updateDate,
                            };
                        }

                        else {

                            return new SearchRepositoriesRequest(name) {

                                Stars = starsRange,
                                Size = sizeRange,
                                Forks = forksRange,
                                Fork = includeForks,
                                Language = language,

                                In = new[] { InQualifier.Name },
                            };
                        }
                    }
                }
            }
        }
    }
}