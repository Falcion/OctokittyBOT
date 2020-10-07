using Octokit;

using Discord;
using Discord.WebSocket;

namespace Stratum {

    public class Debug {

        private Config configModule;
        private Logger logModule;

        private string apiToken;
        private string authToken;

        private bool debugMode;

        public bool GitDebug() {
            
            apiToken = configModule.getApiToken();
            debugMode = configModule.getDebugMode();

            if(debugMode == false) return true;

            if(apiToken.Length == 0) {

                logModule.Error("Wrong format of API token! Please, check your configuration file!");
                return false;
            }

            if(apiToken == "") {

                logModule.Error("Wrong format of API token! Please, check your configuration file!");
                return false;
            }

            if(apiToken == null) {

                logModule.Error("Wrong format of API token! Please, check your configuration file!");
                return false;
            }

            try {
                GitHubClient gitHub = new GitHubClient(new ProductHeaderValue("Debug"));
                Credentials tokenAuth = new Credentials(apiToken);

                gitHub.Credentials = tokenAuth;

            } catch(ApiException exception) {

                string exceptionMessage = exception.ApiError.Message;

                logModule.Error(exceptionMessage);
            }

            return true;
        }

        public bool BotDebug(DiscordSocketClient clientSocket) {
            
            authToken = configModule.getAuthToken();
            debugMode = configModule.getDebugMode();

            if(debugMode == false) return true;

            if(authToken.Length == 0) {

                logModule.Error("Wrong format of API token! Please, check your configuration file!");
                return false;
            }

            if(authToken == "") {

                logModule.Error("Wrong format of API token! Please, check your configuration file!");
                return false;
            }

            if(authToken == null) {

                logModule.Error("Wrong format of API token! Please, check your configuration file!");
                return false;
            }

            try {
                clientSocket.LoginAsync(TokenType.Bot, authToken);
                clientSocket.StartAsync();

            } catch {

                logModule.Error("Error with Discord API Debug! Please, check your bot's token or other specified data!");
            }

            return true;
        }
    }
}