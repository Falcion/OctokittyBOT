** **

## Stratum

## Introduction

**Stratum** - special bot that created for integration with GitHub API through Discord, that allows GitHub's developers and contributors to find, show up and see some information about repositories, projects, issues and etc.

His current potential is restricted by [GitHub API OAuth](https://developer.github.com/v3/).

## Packages

**Stratum** was written in [VSCode](https://code.visualstudio.com/) and debugged in [Visual Studio](https://visualstudio.microsoft.com/) with help of [Discord.net](https://discord.foxbot.me/docs/) and [Octokit.net](https://github.com/octokit/octokit.net).

| Package name | Package Version |
| :---: | :---: |
| [Discord.net](https://www.nuget.org/packages/Discord.Net/) | 2.2.0 |
| [Octokit.net](https://www.nuget.org/packages/Octokit/) | 0.48.0 |
| [Microsoft.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/) | 5.0.0-rc.1.20451.14 | 

## Commands

| Command | Information |
| :-----: | :---------: |
| **GITAPI-LIMIT** | Shows current status of GitHub API with specific token. |
| **GITAPI-HELP** | Shows information and list of current commands. |
| **REPOS-INFO [AUTHOR] [NAME]** | Shows information about specific repository. |
| **BRANCH-INFO [AUTHOR] [NAME] [BRANCH]** | Shows information about specific branch. |
| **RELEASE-INFO [AUTHOR] [NAME] [TAG]** | Shows advanced information about specific release. |
| **ISSUE-INFO [AUTHOR] [NAME] [NUMBER]** | Shows advanced information about specific issue. |
| **COMMIT-INFO [AUTHOR] [NAME]** | Shows information about specific commit. |
| **USER-INFO [LOGIN]** | Shows information about specific user. |
| **REPOS-BRANCHES [AUTHOR] [NAME] [PAGE]** | Shows information about branches of specific repository. |
| **REPOS-RELEASES [AUTHOR] [NAME] [PAGE]** | Shows information about releases of specific repository. |
| **REPOS-ISSUES [AUTHOR] [NAME] [PAGE] [FILTERS]** | Shows list of issues in specific repository that sorted by specific filters. |
| **REPOS-COMMITS [AUTHOR] [NAME] [PAGE] [FILTERS]** | Shows list of commits in specific repository that sorted by specific filters. |
| **SEARCH-USERS [PAGE] [FILTERS]** | Shows a list of found users using specific filters. |
| **SEARCH-REPOS [PAGE] [FILTERS]** | Shows a list of found repositories using specific filters. |
| **SEARCH-CODE [PAGE] [FILTERS]** | Shows a list of found codes using specific filters. |
| **ORGANIZATION [NAME]** | Shows information about specific organization. |
| **PULL-REQUEST [AUTHOR] [NAME] [NUMBER]** | Shows information about specific pull request. |

## License

This repository is licensed under [MIT License](https://github.com/Falcion/Stratum/blob/main/LICENSE).

```LICENSE
MIT License

Copyright (c) 2020 Falcion

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```