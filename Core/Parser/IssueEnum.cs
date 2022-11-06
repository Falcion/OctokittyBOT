using System;

using Octokit;

namespace Stagnum.Core.Parser
{
    public static class IssueEnum
    {
        public static IssueFilter getIssueFilter(string? argument)
        {
            /* 
                Remove uppercase characters to simplify the query system.
                This will remove the extra burden on search queries and their syntax.
            */

            argument = argument.ToLower();

            switch (argument)
            {
                /*
                    Support for all kinds of IssueFilter in Octokit.net.
                    All filters except IssueFilter.All work on behalf of the bot and make calls from its login.
                 */

                case "all":
                    return IssueFilter.All;

                case "assigned":
                    return IssueFilter.Assigned;

                case "created":
                    return IssueFilter.Created;

                case "mentioned":
                    return IssueFilter.Mentioned;

                case "subscribed":
                    return IssueFilter.Subscribed;
            }

            return getStaticFilter();
        }

        /* A method that returns a generic IssueFilter value that works for all types of requests. */

        public static IssueFilter getDefaultFilter()
        {
            return IssueFilter.All;
        }

        /* A method that returns a static IssueFilter value that works for none of requests (system getter). */

        private static IssueFilter getStaticFilter()
        {
            return new IssueFilter();
        }
    }
}
