using System;
using System.Collections.Generic;
using System.Text;

namespace Stratum
{
    public static class Debugger
    {
        public static bool SUCCESS;

        public static void Init()
        {
            bool? ENABLED = Configuration.getDebug();

            /* If Debugger disabled, shut it down. */

            if (ENABLED == false)
            {
                setSuccess(true);
                return;
            }

            setSuccess(true);

            /* Reading bot params from Config module. */

            string? AUTH_TOKEN = Configuration.getAuthToken();
            string? GIT_TOKEN = Configuration.getGitToken();

            /* The array of banned chars, which tokens mustn't contain. */

            char[] BANNED_CHARS = new char[] { '\'', '\"', ':', ';', '\\', '@', '#', '№', '$', '%', '^', '&', '?', '*', '(', ')', '{', '}', '<', '>', ',', '.', '/', '|', '!', '~', '`' };

            for (int i = 0; i < BANNED_CHARS.Length; i++)
            {
                if (AUTH_TOKEN.StartsWith(BANNED_CHARS[i]))
                {
                    Logger.Error("Invalid Discord API token format!");

                    setSuccess(false);
                    return;
                }
                if (GIT_TOKEN.StartsWith(BANNED_CHARS[i]))
                {
                    Logger.Error("Invalid GitHub API token format!");

                    setSuccess(false);
                    return;
                }
            }
        }

        /*
            Getters and setters methods.
         */

        public static bool getSuccess()
        {
            return SUCCESS;
        }

        private static void setSuccess(bool arg)
        {
            SUCCESS = arg;
        }
    }
}
