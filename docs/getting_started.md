Stagnum as a bot for the Discord application and interacting with GitHub requires two tokens from different APIs: from the Discord API and the GitHub API, respectively. They must be specified in the configuration file following strong typing.

### Setup

When the bot application is launched for the first time, as well as if all the necessary libraries are present, it will create a .cfg configuration file with the written lines and inform you about this in the console and stop its work, but will not close the terminal itself.

1. Tokens from the API cannot be empty, contain symbols like `$` or `\`, as well as others that are prohibited in specifying tokens.
2. The bot prefix has a completely free form, except for the contents of characters in the form `\`.
3. The debugger mode changes according to the comment inside the configuration file. This boolean type must be specified in uppercase only.
