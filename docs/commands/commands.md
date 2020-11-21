Stagnum completely bases its work on teams, some of which have high requirements for typing and the type of input data. For each department of teams and more detailed information about them, you can follow the link to the documentation page by clicking on the teams themselves.

### Using Commands

Stagnum accepts commands both on servers in any channel and in private messages. The bot responds to messages only if there is a prefix at the beginning of the same message, the prefix is ​​entered by the user himself in the bot config.

### Commands groups

1. **Information commands.**

Informational commands do not differ in heavy typing of arguments and are easy to enter data. They execute the simplest functionality of interacting with the API of the GitHub service, i.e., work with its simplest elements, for example: getting information about a repository, user, commit or pull request.

2. **Massive information commands.**

In information-massive commands, support for the functionality of pages appears. They execute the simplest functionality of interacting with the API, although they make up a massive request that returns lists of objects, for example: releases of the repository, or its branches.

3. **Search and filter commands.**

Search and filter commands are distinguished by their support for the syntax of filters, and, therefore, by heavy typing of the input data. This group is divided into two subgroups: massive with filters and search commands, the latter support only two arguments - a page and a set of filters. They sort objects within the request and return an array of elements that satisfy the filters you enter, for example: commits to the repository or its issues, searching for users or code.
