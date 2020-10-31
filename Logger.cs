using System;

namespace Stratum
{
    public static class Logger
    {
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine($"[{DateTime.Now}]: " + message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"[{DateTime.Now}]: " + message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"[{DateTime.Now}]: " + message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
