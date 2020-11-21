using System;
using System.Collections.Generic;
using System.Text;

namespace Stagnum
{
    public static class Debugger
    {
        public static bool SUCCESS;

        public static void Init()
        {
            bool? ENABLED = Configuration.getDebug();

            _F9A(true);

            /* If Debugger disabled, shut it down. */

            if (ENABLED == false)
            {
                return;
            }

            /* Reading bot params from Config module. */

            string? AUTH_TOKEN = Configuration.getAuthToken();
            string? GIT_TOKEN = Configuration.getGitToken();

            /* The array of banned chars, which tokens mustn't contain. */

            char[] BANNED_CHARS = new char[] { '\'', '\"', ':', ';', '\\', '@', '#', '№', '$', '%', '^', '&', '?', '*', '(', ')', '{', '}', '<', '>', ',', '.', '/', '|', '!', '~', '`', ' ' };

            for (int i = 0; i < BANNED_CHARS.Length; i++)
            {
                if (AUTH_TOKEN.StartsWith(BANNED_CHARS[i]))
                {
                    Logger.Error("Invalid Discord API token format!");

                    _F9A(false);
                    return;
                }
                if (GIT_TOKEN.StartsWith(BANNED_CHARS[i]))
                {
                    Logger.Error("Invalid GitHub API token format!");

                    _F9A(false);
                    return;
                }
            }

            /* Checking the configuration variables for the moment they are empty. */

            if (AUTH_TOKEN == null)
            {
                Logger.Error("Invalid Discord API token format!");

                _F9A(false);
                return;
            }

            if (GIT_TOKEN == null)
            {
                Logger.Error("Invalid GitHub API token format!");

                _F9A(false);
                return;
            }
        }

        /*
            Getters and setters methods.
         */

        public static bool getSuccess()
        {
            return SUCCESS;
        }

        private static void _F9A(bool arg)
        {
            SUCCESS = arg;
        }
    }
}
