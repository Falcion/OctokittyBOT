using System;

using Octokit;

namespace Stagnum.Core.Parser
{
    public static class ForkEnum
    {
        public static ForkQualifier getForkQualifier(string? argument)
        {
            /* 
                Remove uppercase characters to simplify the query system.
                This will remove the extra burden on search queries and their syntax.
            */

            argument = argument.ToLower();

            switch(argument)
            {
                case "include@forks": 
                    return ForkQualifier.IncludeForks;

                case "only@forks": 
                    return ForkQualifier.OnlyForks;
            }

            return new ForkQualifier();
        }

        /* A method that returns a generic ForkQualifier value that works for all types of requests. */

        public static ForkQualifier getDefaultQualifier()
        {
            return ForkQualifier.IncludeForks;
        }

        /* A method that returns a static ForkQualifier value that works for none of requests (system getter). */

        private static ForkQualifier getStaticQualifier()
        {
            return new ForkQualifier();
        }
    }
}
