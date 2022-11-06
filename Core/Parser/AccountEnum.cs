using System;

using Octokit;

namespace Stagnum.Core.Parser
{
    public static class AccountEnum
    {
        public static AccountSearchType getAccountType(string? argument)
        {
            /* 
                Remove uppercase characters to simplify the query system.
                This will remove the extra burden on search queries and their syntax.
            */

            argument = argument.ToLower();

            switch(argument)
            {
                case "org":
                    return AccountSearchType.Org;

                case "user":
                    return AccountSearchType.User;
            }

            return getStaticType();
        }

        /* A method that returns a generic AccountSearchType value that works for all types of requests. */

        public static AccountSearchType getDefaultType()
        {
            return AccountSearchType.User;
        }

        /* A method that returns a static AccountSearchType value that works for none of requests (system getter). */

        private static AccountSearchType getStaticType()
        {
            return new AccountSearchType();
        }
    }
}
