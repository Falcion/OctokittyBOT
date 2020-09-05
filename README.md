## Stratum's Repository

## Packages

Stratum was written in [Visual Studio](https://visualstudio.microsoft.com/) and debugged in [VSCode](https://code.visualstudio.com/) with help of [Discord.net](https://discord.foxbot.me/docs/) and [Octokit](https://github.com/octokit/octokit.net).
** **

![discord.net-package](https://img.shields.io/nuget/v/Discord.net?color=blue&label=discord.net&style=for-the-badge)

![octokit.net-package](https://img.shields.io/nuget/v/Octokit?color=blue&label=Octokit&style=for-the-badge)

![dependencyInjection-package](https://img.shields.io/nuget/vpre/Microsoft.Extensions.DependencyInjection?label=DependencyInjection&style=for-the-badge)

** **

## Information

**Stratum** - special bot that created for integration with GitHub API through Discord, that allows GitHub's developers and contributers to find, show up and see some information about repositories, projects, issues and etc.

His current potential is restricted by [GitHub API OAuth](https://developer.github.com/v3/).

**Documentations List:**

*   [Octokit](https://octokitnet.readthedocs.io/en/latest/)
*   [Discord.net](https://discord.foxbot.me/docs/)
*   [C# (Microsoft)](https://docs.microsoft.com/en-us/dotnet/csharp/)
*   [GitHub API](https://docs.github.com/en/rest)

## Command-List

| Command | Information | Syntax |
| :------: | :---------: | :-----: |
| gitapi-limit | Shows information about current GitHub API Limits (for Core and Search Requests). | ``gitapi-limit`` |
| gitapi-help | Shows information about all commands. | ``gitapi-help`` |
| gitapi-links | Shows all specified links of this project. | ``gitapi-links`` |
| repos-info | Shows information about specified repository. | ``repos-info [repository author] [repository name]`` |
| repos-branches | Shows information about branches of specified repository. | ``repos-branches [repository author] [repository name]`` |
| repos-releases | Shows information about releases of specified repository (includes page-system.) | ``repos-releases [repository author] [repository name]`` |
| repos-issues | Shows list of issues in specified repository that sorted by specified filters. For more information [check this](https://github.com/Falcion/Stratum/blob/syntax/.wikia/REPOS-ISSUES.md). | ``repos-issues [repository author] [repository name] [page number] [filters]`` |
| repos-commits | Shows list of commits in specified repository that sorted by specified filters. For more information [check this](https://github.com/Falcion/Stratum/blob/syntax/.wikia/REPOS-COMMITS.md). | ``repos-commits [repository author] [repository name] [page number] [filters]`` |
| repos-core | Shows advanced information about specified repository. | ``repos-core [repository author] [repository name]`` |
| branch-info | Shows advanced information about specified branch. | ``branch-info [repository author] [repository name] [branch name]`` |
| release-info | Shows advanced information about specified release. | ``release-info [repository author] [repository name] [tag]`` |
| issue-info | Shows advanced information about specified issue. | ``issue-info [repository author] [repository name] [issue number]`` |
| commit-info | Shows advanced information about specified commit. | ``commit-info [repository author] [repository name] [reference]`` |
| organization | Shows information about organization. | ``organization [username (login)]`` |
| pull-request | Shows information about pull request. | ``pull-request [repository author] [repository name] [pull request number]`` |
| user-core | Shows advanced information about user. | ``user-core [username (login)]`` |
| search-users | Shows list of users that sorted by specified filters. For more information [check this](https://github.com/Falcion/Stratum/blob/syntax/.wikia/SEARCH-USERS.md). | ``search-users [page number] [filters]`` |
| search-repos | Shows list of users that sorted by specified filters. For more information [check this](https://github.com/Falcion/Stratum/blob/syntax/.wikia/SEARCH-REPOS.md). | ``search-repos [page number] [filters]`` |


## License

Repository is licensed under [MIT License](https://github.com/Falcion/Stratum/blob/master/LICENSE).

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
