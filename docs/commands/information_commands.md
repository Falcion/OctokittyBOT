Command arguments are divided into three types: mandatory arguments, which are enclosed in square brackets `[]`, optional arguments, which are enclosed in parentheses `()`.

## Information Commands

Informational commands do not differ in heavy typing of arguments and are easy to enter data. They execute the simplest functionality of interacting with the API of the GitHub service, i.e., work with its simplest elements, for example: getting information about a repository, user, commit or pull request.

### Command: `repos@info`

This command displays the basic information about the repository, which was found by the given arguments.

**Using the command:** **`repos@info [repository owner] [repository name]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

### Command: `branch@info`

This command displays the basic information about the repository's branch, which was found by the given arguments.

**Using the command:** **`branch@info [repository owner] [repository name] [branch name]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The name of the repository's branch.**
In this argument, you must specify the name of repository's branch. This parameter must not contain spaces or characters prohibited by GitHub.

### Command: `release@info`

This command displays the basic information about the repository's release, which was found by the given arguments.

**Using the command:** **`release@info [repository owner] [repository name] [release tag]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The tag of the repository's release.**
In this argument, you must specify the tag of repository's release. This parameter must not contain spaces or characters prohibited by GitHub.

### Command: `issue@info`

This command displays the basic information about the repository's issue, which was found by the given arguments.

**Using the command:** **`issue@info [repository owner] [repository name] [issue number]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The number of the repository's issue.**
In this argument, you must specify the number of repository's issue. This parameter must be in an integer type.

### Command: `commit@info`

This command displays the basic information about the repository's commit, which was found by the given arguments.

**Using the command:** **`commit@info [repository owner] [repository name] [commit ref]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The reference of the repository's commit.**
In this argument, you must specify the reference (SHA) of repository's commit. This parameter must not contain spaces or characters prohibited by GitHub.

### Command: `user@info`

This command displays the basic information about the user, which was found by the given login.

**Using the command:** **`user@info [user login]`**.

**Argument Information:**

1. **The login of user.**
In this argument, you must specify the login of the user. This parameter must not contain spaces or characters prohibited by GitHub.

### Command: `org@info`

This command displays the basic information about the organization, which was found by the given login.

**Using the command:** **`org@info [org login]`**.

**Argument Information:**

1. **The login of user.**
In this argument, you must specify the login of the organization. This parameter must not contain spaces or characters prohibited by GitHub.

### Command: `pull@request`

This command displays the basic information about the repository's commit, which was found by the given arguments.

**Using the command:** **`pull@request [repository owner] [repository name] [issue number]`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The number of the repository's issue.**
In this argument, you must specify the number of repository's issue. This parameter must be in an integer type.