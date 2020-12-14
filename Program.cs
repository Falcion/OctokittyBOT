using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stagnum
{
    public class Program
    {
        private static void Main(string[] args)
            => new Program().Run().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandService cmd;
        private IServiceProvider service;

        public async Task Run()
        {
            Console.OutputEncoding = Encoding.Unicode;

            client = new DiscordSocketClient();
            cmd = new CommandService();

            service = new ServiceCollection()
                                    .AddSingleton(client)
                                    .AddSingleton(cmd)
                                    .BuildServiceProvider();

            await Receive();

            client.Log += Log;

            await client.LoginAsync(TokenType.Bot, File.ReadAllText("token.txt"));
            await client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        private async Task Receive()
        {
            client.MessageReceived += Handle;

            await cmd.AddModulesAsync(Assembly.GetEntryAssembly(), service);
        }

        private async Task Handle(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, msg);

            if (msg.Author.IsBot) return;

            int argPos = 0;
            if(msg.HasStringPrefix("+", ref argPos))
            {
                var result = await cmd.ExecuteAsync(context, argPos, service);

                if (!result.IsSuccess) Console.WriteLine(result.Error);
            }
        }
    }
}
