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
| :------ | :---------: | -----: |
| gitapi-limit | Shows information about current GitHub API Limits (for Core and Search Requests). | ``gitapi-limit`` |
| repos-info | Shows information about specified repository. | ``repos-info [author] [name]`` |
| repos-branches | Shows information about branches of specified repository. | ``repos-branches [author] [name]`` |


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