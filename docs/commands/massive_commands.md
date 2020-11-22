Command arguments are divided into three types: mandatory arguments, which are enclosed in square brackets `[]`, optional arguments, which are enclosed in parentheses `()`.

## Massive Commands

In information-massive commands, support for the functionality of pages appears. They execute the simplest functionality of interacting with the API, although they make up a massive request that returns lists of objects, for example: releases of the repository, or its branches.

### Command: `branch@array`

This command displays the list of repository's branches, which were found by the given arguments. This command supports page system of embeds.

**Using the command:** **`branch@array [repository owner] [repository name] (page number)`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.

### Command: `release@array`

This command displays the list of repository's releases, which were found by the given arguments. This command supports page system of embeds.

**Using the command:** **`release@array [repository owner] [repository name] (page number)`**.

**Argument Information:**

1. **The owner of the repository.**
In this argument, you must specify the username of the repository owner. This parameter must not contain spaces or characters prohibited by GitHub.

2. **The name of the repository.**
In this argument, you must specify the full name of the repository. This parameter must not contain spaces or characters prohibited by GitHub.

3. **The number of the page.**
In this argument, you must specify the number of list's page. This parameter is optional and must be an integer type.