using System;

namespace Stratum {

    public class Logger {

        public void Info(string infoBody) {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("[" + $"{DateTime.Now}" + "]: " + infoBody);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Error(string errorBody) {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("[" + $"{DateTime.Now}" + "]: " + errorBody);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Warn(string warnBody) {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("[" + $"{DateTime.Now}" + "]: " + warnBody);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}