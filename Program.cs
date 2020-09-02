using System.Threading.Tasks;
using System;
using System.Text;
using System.IO;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using System.Reflection;

namespace Stratum {

    public class Program {

        public string authToken, apiToken, prefix;

        static void Main(string[] args)
            => new Program().Run().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandService command;
        private IServiceProvider service;

        private async Task Run() { 
            Console.OutputEncoding = Encoding.UTF8;

            await Configuration();

            client = new DiscordSocketClient();
            command = new CommandService();

            service = new ServiceCollection()
                                            .AddSingleton(client)
                                            .AddSingleton(command)
                                            .BuildServiceProvider();

            await Registry();

            client.Log += Log;

            await client.LoginAsync(TokenType.Bot, authToken);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage message) {
            Console.WriteLine(message);

            return Task.CompletedTask;
        }

        private Task Configuration() {

            if(!File.Exists(".conf")) {
                string configDefault = "authToken = \"\"" + Environment.NewLine + "apiToken = \"\"" + Environment.NewLine + "prefix = \"$ \"";

                File.Create(".conf")
                                    .Close();

                File.WriteAllText(".conf", configDefault);

                Console.WriteLine("Created default configuration file. Please, type in your bot token!");

                Error("Awaiting for bot token.");
            }

            string[] configArray = File.ReadAllLines(".conf", Encoding.UTF8);

            for(int i = 0; i < configArray.Length; i++) {

                    if(configArray[i].StartsWith(' ')) continue;

                    if(configArray[i].StartsWith("authToken =")) {
                        
                        authToken = LineParse(11, configArray[i]);
                        Storage.authToken 
                                = LineParse(11, configArray[i]);
                    }

                    if(configArray[i].StartsWith("apiToken =")) {
                        
                        apiToken = LineParse(10, configArray[i]);
                        Storage.apiToken 
                                = LineParse(10, configArray[i]);
                    }

                    if(configArray[i].StartsWith("prefix =")) {
                        
                        prefix = LineParse(8, configArray[i]);
                        Storage.prefix 
                                = LineParse(8, configArray[i]);      
                    }                  
            }

            return Task.CompletedTask;
        }

        private async Task Registry() {

            client.MessageReceived += Handle;

            await command.AddModulesAsync(Assembly.GetEntryAssembly(), 
                                                                    service);
        }

        private async Task Handle(SocketMessage arg) {

            SocketUserMessage message
                                    = arg as SocketUserMessage; 
            SocketCommandContext commandContext 
                                    = new SocketCommandContext(client, message);

            if(message.Author.IsBot) return;

            int argPos = 0;
            if(message.HasStringPrefix(prefix, ref argPos)) {

                IResult result 
                            = await command.ExecuteAsync(commandContext, argPos, service);

                if(!result.IsSuccess) {

                    Console.WriteLine(result.Error + " caused by " + result.ErrorReason);

                    EmbedBuilder messageEmbed = new EmbedBuilder()

                                                                .WithTitle("Error")
                                                                .WithColor(Color.Default)
                                                                .WithCurrentTimestamp()
                                                                .AddField("Error:", result.Error)
                                                                .AddField("Error Reason:", result.ErrorReason);

                    await commandContext.Channel.SendMessageAsync("", false, messageEmbed.Build()   );
                }

                else Console.WriteLine(result);
            }
        }

        private string LineParse(int charNumber, [Remainder]string configElement) {
            
            configElement = configElement.Remove(0, charNumber);

            if(configElement.StartsWith(' ')) configElement = configElement.Remove(0, 1);

            if(!configElement.StartsWith('\"')) Error("Wrong format! Please reset configuration file and write data again!");

            configElement = configElement.Remove(0, 1);

            int charIndex = configElement.LastIndexOf('\"');
            configElement = configElement.Remove(charIndex, 1);

            return configElement;
        }

        private Task Error([Remainder]string errCode) {

            Console.WriteLine(errCode);
            Environment.Exit(0);

            return Task.CompletedTask;
        }
    }
}
