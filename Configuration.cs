using System;
using System.IO;

namespace Stratum
{
    public static class Configuration
    {
        public static string AUTH_TOKEN;
        public static string GIT_TOKEN;
        public static string BOT_PREFIX;

        public static bool DEBUG;

        /*
            Initiliazation method.
            Used to check for the existence of a configuration file, create it, or call a postinitialization method.
         */

        public static void Init()
        {
            if(!File.Exists(".cfg"))
            {
                File.Create(".cfg").Close();

                Logger.Warn("Created configuration file! Write GitHub API token and Discord API token in this file.");

                string ARRAY = "AUTH_TOKEN: \"\"\nGIT_TOKEN: \"\"\nBOT_PREFIX: \"$ \"\nDEBUG: FALSE";

                File.WriteAllText(".cfg", ARRAY);

                Environment.Exit(-1);
            }

            PostInit();
        }

        /*
            Postinitialization method.
            Used to read an already existing configuration file (can be reused).
         */

        public static void PostInit()
        {
            string[] param = File.ReadAllLines(".cfg");

            for (int i = 0; i < param.Length; i++)
            {
                if (param[i].StartsWith("AUTH_TOKEN: "))
                {
                    param[i] = param[i].Remove(0, 12);

                    param[i] = param[i].Remove(param[i].IndexOf('\"'), 1);
                    param[i] = param[i].Remove(param[i].LastIndexOf('\"'), 1);

                    AUTH_TOKEN = param[i];
                }
                if (param[i].StartsWith("GIT_TOKEN: "))
                {
                    param[i] = param[i].Remove(0, 11);

                    param[i] = param[i].Remove(param[i].IndexOf('\"'), 1);
                    param[i] = param[i].Remove(param[i].LastIndexOf('\"'), 1);

                    GIT_TOKEN = param[i];
                }
                if (param[i].StartsWith("BOT_PREFIX: "))
                {
                    param[i] = param[i].Remove(0, 12);

                    param[i] = param[i].Remove(param[i].IndexOf('\"'), 1);
                    param[i] = param[i].Remove(param[i].LastIndexOf('\"'), 1);

                    BOT_PREFIX = param[i];
                }
                if(param[i].StartsWith("DEBUG: "))
                {
                    param[i] = param[i].Remove(0, 7);

                    param[i] = param[i].ToLower();

                    DEBUG = bool.Parse(param[i]);
                }
            }
        }

        /*
            Getters and setters methods.
         */

        public static string getAuthToken()
        {
            return AUTH_TOKEN;
        }

        public static void setAuthToken(string token)
        {
            AUTH_TOKEN = token;
        }

        public static string getGitToken()
        {
            return GIT_TOKEN;
        }

        public static void setGitToken(string token)
        {
            GIT_TOKEN = token;
        }

        public static string getBotPrefix()
        {
            return BOT_PREFIX;
        }

        public static void setBotPrefix(string prefix)
        {
            BOT_PREFIX = prefix;
        }

        public static bool getDebug()
        {
            return DEBUG;
        }

        public static void setDebug(bool arg)
        {
            DEBUG = arg;
        }
    }
}
