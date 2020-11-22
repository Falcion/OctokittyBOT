Command arguments are divided into three types: mandatory arguments, which are enclosed in square brackets `[]`, optional arguments, which are enclosed in parentheses `()`, and array arguments that can contain a different set of arguments, they are enclosed by `<>` symbols.

## Search Commands

Search and filter commands are distinguished by their support for the syntax of filters, and, therefore, by heavy typing of the input data. This group is divided into two subgroups: massive with filters and search commands, the latter support only two arguments - a page and a set of filters. They sort objects within the request and return an array of elements that satisfy the filters you enter, for example: commits to the repository or its issues, searching for users or code.