using System;

using Octokit;

namespace Stratum.Body
{
    public static class Parser
    {
        public static IssueFilter getIssueFilter(string? arg)
        {
            /* We simplify user input, you can even input with CapsLock. */

            arg = arg.ToLower();

            switch(arg)
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

            return new IssueFilter();
        }

        public static DateTime getDate(string? arg) 
        {
            return DateTime.Parse(arg);
        }
    }
}
