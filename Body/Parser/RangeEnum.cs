using System;

using Octokit;

namespace Stratum.Body.Parser
{
    public static class RangeEnum
    {
        public static Octokit.Range getRange(string[]? argument)
        {
            int number = int.Parse(argument[1]);

            switch(argument[0])
            {
                case ">>": 
                    return Octokit.Range.GreaterThan(number);

                case ">=": 
                    return Octokit.Range.GreaterThanOrEquals(number);

                case "<<":
                    return Octokit.Range.LessThan(number);

                case "<=":
                    return Octokit.Range.LessThanOrEquals(number);
            }

            return getStaticRange();
        }

        /* A method that returns a generic Octokit.Range value that works for all types of requests. */

        public static Octokit.Range getDefaultRange()
        {
            return Octokit.Range.GreaterThanOrEquals(0);
        }

        /* A method that returns a static Octokit.Range value that works for none of requests (system getter). */

        private static Octokit.Range getStaticRange()
        {
            return new Octokit.Range(0);
        }
    }
}
