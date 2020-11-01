using System;

namespace Stratum
{
    public static class Logger
    {

        /*
            Usage: secondary information or comments in console.
            Color: DarkGray.
         */

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine($"[{DateTime.Now}]: " + message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*
            Usage: warning user about something.
            Color: Yellow.
         */

        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"[{DateTime.Now}]: " + message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*
            Usage: direct emphasis on the error.
            Color: Red.
         */

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"[{DateTime.Now}]: " + message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
