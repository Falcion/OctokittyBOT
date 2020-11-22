Command arguments are divided into three types: mandatory arguments, which are enclosed in square brackets `[]`, optional arguments, which are enclosed in parentheses `()`, and array arguments that can contain a different set of arguments, they are enclosed by `<>` symbols.

## Search Commands

Search and filter commands are distinguished by their support for the syntax of filters, and, therefore, by heavy typing of the input data. This group is divided into two subgroups: massive with filters and search commands, the latter support only two arguments - a page and a set of filters. They sort objects within the request and return an array of elements that satisfy the filters you enter, for example: commits to the repository or its issues, searching for users or code.

### Command: `issue@array`

This command displays the list of repository's issues, which were found by the given arguments and filters. This command supports page system of embeds.

**Using the command:** **`release@array [repository owner] [repository name] [page number] [filters syntax]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.

4. **The filters syntax.** In this syntax, you can type: issue filter, issue's creator, issue's mentioned, issue's assignee, issue's milestone.

### Command: `commit@array`

This command displays the list of repository's commits, which were found by the given arguments and filters. This command supports page system of embeds.

**Using the command:** **`commit@array [repository owner] [repository name] [page number] [filters syntax]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.

4. **The filters syntax.** In this syntax, you can type: until date, since date, commit's author, commit's path, commit's SHA.

### Command: `user@find`

This command displays the list of users, which were found by the given filters. This command supports page system of embeds.

**Using the command:** **`user@find [page number] [filters syntax]`**.

**Argument Information:**

1. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.

2. **The filters syntax.** In this syntax, you can type: followers range, repositories range, creation date, language of any repository, account type, user's location, username, user's email, user's fullname.

### Command: `repos@find`

This command displays the list of repositories, which were found by the given filters. This command supports page system of embeds.

**Using the command:** **`repos@find [page number] [filters syntax]`**.

**Argument Information:**

1. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.

2. **The filters syntax.** In this syntax, you can type: stars range, size range (kilobytes), forks range, fork qualifier, repository's language, creation date, updates period, repository's name, repository's owner, readme and description boolean.

### Command: `code@find`

This command displays the list of codes or files, which were found by the given filters. This command supports page system of embeds.

**Using the command:** **`code@find [page number] [filters syntax]`**.

**Argument Information:**

1. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.

2. **The filters syntax.** In this syntax, you can type: filename, path, repository's owner, repository's name, code's language, include forks or not, file size (bytes).