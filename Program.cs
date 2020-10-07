using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.DependencyInjection;

namespace Stratum {

    public class Program {

        public string authToken;
        public string apiToken;
        public string botPrefix;

        public Config configModule;
        public Debug debugModule;
        public Logger logModule;

        static void Main(string[] args)
            => new Program().Run().GetAwaiter().GetResult();

        private DiscordSocketClient CLIENT;
        private CommandService CMD;
        private IServiceProvider SERVICE;

        private async Task Run() {
            Console.OutputEncoding = Encoding.UTF8;

            configModule.Setup();

            bool gitDebug = debugModule.GitDebug();
            bool botDebug = debugModule.BotDebug(CLIENT);
            
            if(gitDebug == false) {

                logModule.Error("Error in GitHub API Debug! Please, check your token or other specified data!");

                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(-1);
            }

            if(botDebug == false) {

                logModule.Error("Error in Discord API Debug! Please, check your token or other specified data!");

                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(-1);
            }

            CLIENT = new DiscordSocketClient();
            CMD = new CommandService();

            SERVICE = new ServiceCollection()
                          .AddSingleton(CLIENT)
                          .AddSingleton(CMD)
                          .BuildServiceProvider();

            await RegistryModule();

            CLIENT.Log += LOGGER;

            this.authToken = configModule.authToken;

            await CLIENT.LoginAsync(TokenType.Bot, this.authToken);
            await CLIENT.StartAsync();

            await Task.Delay(-1);
        }

        private Task LOGGER(LogMessage messageBody) {
            string logMessage = messageBody.Message;
            
            if(logMessage.Contains("Exception")) logModule.Error(logMessage);
            else logModule.Info(logMessage);

            return Task.CompletedTask;
        }

        private async Task RegistryModule() {
            CLIENT.MessageReceived += HANDLE;

            await CMD.AddModulesAsync(Assembly.GetEntryAssembly(), SERVICE);
        }

        private async Task HANDLE(SocketMessage MSG) {

            this.botPrefix = configModule.botPrefix;

            SocketUserMessage _MSG = MSG as SocketUserMessage;
            SocketCommandContext CONTEXT = new SocketCommandContext(CLIENT, _MSG);

            if(_MSG.Author.IsBot) return;

            int ARGPOS = 0;
            if(_MSG.HasStringPrefix(this.botPrefix, ref ARGPOS)) {

                IResult RESULT = await CMD.ExecuteAsync(CONTEXT, ARGPOS, SERVICE);

                if(!RESULT.IsSuccess) {

                    logModule.Error(RESULT.Error + " _P_08192__ " + RESULT.ErrorReason);

                    EmbedBuilder EMBED = new EmbedBuilder();

                    int HASH = RESULT.Error.GetHashCode();

                    EMBED.WithTitle($"{HASH}")
                         .WithColor(Color.Red)
                         .AddField("ERROR:", RESULT.Error)
                         .AddField("_P_08192__", RESULT.ErrorReason);

                    await CONTEXT.Channel.SendMessageAsync("", false, EMBED.Build());

                } else logModule.Info($"{RESULT}");
            }
        }
    }
}
