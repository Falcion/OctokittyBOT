using System;

using Octokit;

namespace Stratum.Body.Parser
{
    public static class DateEnum
    {
        public static DateRange getDateRange(string? argument)
        {
            /*
                Split the string by a character indicating inequality logic and a date.
                Subsequently, we split the string with the date into the number of year, month, day and work with the received data.
             */

            string[]? constructor = argument.Split(' ');
            string[]? timeOffset = constructor[1].Split('/');

            int[] dateOffset = new int[] { 1999, 10, 1 };

            for(int i = 0; i < timeOffset.Length; i++) 
                dateOffset[i] = int.Parse(timeOffset[i]);

            switch(constructor[0])
            {
                case ">>":
                    return DateRange.GreaterThan(new DateTimeOffset(new DateTime(dateOffset[0], dateOffset[1], dateOffset[2])));

                case ">=":
                    return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(dateOffset[0], dateOffset[1], dateOffset[2])));

                case "<<":
                    return DateRange.LessThan(new DateTimeOffset(new DateTime(dateOffset[0], dateOffset[1], dateOffset[2])));

                case "<=":
                    return DateRange.GreaterThan(new DateTimeOffset(new DateTime(dateOffset[0], dateOffset[1], dateOffset[2])));
            }

            return getStaticRange();
        }

        /* A method that returns a generic DateRange value that works for all types of requests. */

        public static DateRange getDefaultRange()
        {
            return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(1999, 10, 1)));
        }

        /* A method that returns a static DateRange value that works for none of requests (system getter). */

        private static DateRange getStaticRange()
        {
            return new DateRange(new DateTimeOffset(new DateTime(1999, 10, 1)), DateTimeOffset.Now);
        }
    }
}
