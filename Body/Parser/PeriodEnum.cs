using System;
using System.Collections.Generic;
using Octokit;

namespace Stratum.Body.Parser
{
    public static class PeriodEnum
    {
        public static DateRange getPeriodRange(string? argument)
        {
            /*
                Separating the two dates into separate elements separated by a space. 
                Then process them and get numbers (already dividing the dates into elements).
             */

            string[]? constructor = argument.Split(' ');

            string[]? fromOffset = constructor[0].Split('/');
            string[]? toOffset = constructor[1].Split('/');

            /* First date handler. */

            List<int> fromArray = new List<int>();

            for (int fromInt = 0; fromInt < fromOffset.Length; fromInt++)
                fromArray.Add(int.Parse(fromOffset[fromInt]));

            /* Second date handler. */

            List<int> toArray = new List<int>();

            for (int toInt = 0; toInt < toOffset.Length; toInt++)
                toArray.Add(int.Parse(fromOffset[toInt]));

            /* Forming DateTimeOffset objects and create DateRange.Beetwen.*/

            DateTimeOffset[]? OffsetArray = new DateTimeOffset[]
            {
                new DateTimeOffset(new DateTime(fromArray[0], fromArray[1], fromArray[2])),
                new DateTimeOffset(new DateTime(toArray[0], toArray[1], toArray[2]))
            };

            return DateRange.Between(OffsetArray[0], OffsetArray[1]);
        }

        /* A method that returns a generic DateRange value that works for all types of requests. */

        public static DateRange getDefaultRange()
        {
            return DateRange.Between(new DateTimeOffset(new DateTime(1999, 10, 1)), DateTimeOffset.Now);
        }

        /* A method that returns a static DateRange value that works for none of requests (system getter). */

        private static DateRange getStaticRange()
        {
            return new DateRange(new DateTimeOffset(new DateTime(1999, 10, 1)), DateTimeOffset.Now);
        }
    }
}
