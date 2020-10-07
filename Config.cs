using System;
using System.IO;

namespace Stratum {

    public class Config {

        private Logger logModule;

        private string fileConfig = "app.conf";

        public string authToken;
        public string apiToken;
        public string botPrefix;

        public bool isDebug;

        public void Setup() {
            if(!File.Exists(fileConfig)) {

                File.Create(fileConfig).Close();

                logModule.Info("Created configuration file! Write GitHub API token and Discord API token in this file.");

                string[] stringArray = new string[] { "authToken = \"\"" + Environment.NewLine + "apiToken = \"\"" + Environment.NewLine + "botPrefix = \"$\"" + Environment.NewLine + "isDebug = \"true\"" };

                File.WriteAllLines(fileConfig, stringArray);

                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(-1);

            } else {

                string[] confLines = File.ReadAllLines(fileConfig);

                for(int i = 0; i < confLines.Length; i++) {
                    string confElement = confLines[i];

                    if(confElement.StartsWith("authToken = ")) {

                        confElement = confElement.Remove(0, 12);

                        int currentIndex = confElement.IndexOf('\"');
                        int endingIndex = confElement.LastIndexOf('\"');

                        confElement = confElement.Remove(currentIndex, 1);
                        confElement = confElement.Remove(endingIndex, 1);

                        this.authToken = confElement;
                    }

                    if(confElement.StartsWith("apiToken = ")) {

                        confElement = confElement.Remove(0, 11);

                        int currentIndex = confElement.IndexOf('\"');
                        int endingIndex = confElement.LastIndexOf('\"');

                        confElement = confElement.Remove(currentIndex, 1);
                        confElement = confElement.Remove(endingIndex, 1);

                        this.apiToken = confElement;
                    }

                    if(confElement.StartsWith("botPrefix = ")) {

                        confElement = confElement.Remove(0, 12);

                        int currentIndex = confElement.IndexOf('\"');
                        int endingIndex = confElement.LastIndexOf('\"');

                        confElement = confElement.Remove(currentIndex, 1);
                        confElement = confElement.Remove(endingIndex, 1);

                        this.botPrefix = confElement;
                    }

                    if(confElement.StartsWith("isDebug = ")) {

                        confElement = confElement.Remove(0, 10);

                        int currentIndex = confElement.IndexOf('\"');
                        int endingIndex = confElement.LastIndexOf('\"');

                        confElement = confElement.Remove(currentIndex, 1);
                        confElement = confElement.Remove(endingIndex, 1);

                        this.isDebug = bool.Parse(confElement);
                    }
                }
            }
        }

        public void Reboot() {
            string[] confLines = File.ReadAllLines(fileConfig);

            for(int i = 0; i < confLines.Length; i++) {
                string confElement = confLines[i];

                if(confElement.StartsWith("authToken = ")) {

                    confElement = confElement.Remove(0, 12);

                    int currentIndex = confElement.IndexOf('\"');
                    int endingIndex = confElement.LastIndexOf('\"');

                    confElement = confElement.Remove(currentIndex, 1);
                    confElement = confElement.Remove(endingIndex, 1);

                    this.authToken = confElement;
                }

                if(confElement.StartsWith("apiToken = ")) {

                    confElement = confElement.Remove(0, 11);

                    int currentIndex = confElement.IndexOf('\"');
                    int endingIndex = confElement.LastIndexOf('\"');

                    confElement = confElement.Remove(currentIndex, 1);
                    confElement = confElement.Remove(endingIndex, 1);

                    this.apiToken = confElement;
                }

                if(confElement.StartsWith("botPrefix = ")) {

                    confElement = confElement.Remove(0, 12);

                    int currentIndex = confElement.IndexOf('\"');
                    int endingIndex = confElement.LastIndexOf('\"');

                    confElement = confElement.Remove(currentIndex, 1);
                    confElement = confElement.Remove(endingIndex, 1);

                    this.botPrefix = confElement;
                }

                if(confElement.StartsWith("isDebug = ")) {

                    confElement = confElement.Remove(0, 10);

                    int currentIndex = confElement.IndexOf('\"');
                    int endingIndex = confElement.LastIndexOf('\"');

                    confElement = confElement.Remove(currentIndex, 1);
                    confElement = confElement.Remove(endingIndex, 1);

                    this.isDebug = bool.Parse(confElement);
                }
            }
        }

        public string getAuthToken() {
            return this.authToken;
        }

        public void setAuthToken(string newToken) {
            this.authToken = newToken;
        }

        public string getApiToken() {
            return this.apiToken;
        }

        public void setApiToken(string newToken) {
            this.apiToken = newToken;
        }

        public string getBotPrefix() {
            return this.botPrefix;
        }

        public void setBotPrefix(string newPrefix) {
            this.botPrefix = newPrefix;
        }

        public bool getDebugMode() {
            return this.isDebug;
        }

        public void setDebugMode(bool debugMode) {
            this.isDebug = debugMode;
        }
    }
}