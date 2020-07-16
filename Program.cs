using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using System.Reflection;
using System.IO;

namespace Stratum
{
    public class Program
    {
        static void Main(string[] args)
            => new Program().RunAsync().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandService cmd;
        private IServiceProvider service;

        private async Task RunAsync()
        {

            client = new DiscordSocketClient();
            cmd = new CommandService();

            service = new ServiceCollection()
                    .AddSingleton(client)
                    .AddSingleton(cmd)
                    .BuildServiceProvider();

            client.Log += Log;

            client.Ready += Ready;
            client.Connected += Connected;
            client.Disconnected += Disconnected;

            client.JoinedGuild += GuildAdd;
            client.LeftGuild += GuildRemove;

            await RegAsync();

            string token = File.ReadAllText("token.conf");

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        private Task GuildRemove(SocketGuild guild)
        {
            Console.WriteLine($"[{DateTime.Now}] Removed guild: {guild.Id}");

            return Task.CompletedTask;
        }

        private Task GuildAdd(SocketGuild guild)
        {
            Console.WriteLine($"[{DateTime.Now}] Added new guild: {guild.Id}");

            return Task.CompletedTask;
        }

        private Task Ready()
        {
            Console.WriteLine($"[{DateTime.Now}] Client is ready.");

            return Task.CompletedTask;
        }

        private Task Disconnected(Exception arg)
        {
            Console.WriteLine($"[{DateTime.Now}] Client disconnected. Information included: {arg}");
            return Task.CompletedTask;
        }

        private Task Connected()
        {
            Console.WriteLine($"[{DateTime.Now}] Client connected.");
            return Task.CompletedTask;
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine($"Logging: {msg}");

            return Task.CompletedTask;
        }

        private async Task RegAsync()
        {
            client.MessageReceived += HandleAsync;

            await cmd.AddModulesAsync(Assembly.GetEntryAssembly(), service);
        }

        private async Task HandleAsync(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, msg);

            if (msg.Author.IsBot) return;

            int argPos = 0;
            if(msg.HasCharPrefix('~', ref argPos))
            {
                Console.WriteLine($"[{DateTime.Now}] Initializing the command: {msg}");
                IResult result = await cmd.ExecuteAsync(context, argPos, service);

                if (!result.IsSuccess)
                {
                    EmbedBuilder errEmbed = new EmbedBuilder();

                    Color errColor = new Color(0x4FEFC8);

                    errEmbed.WithTitle("Непредвиденная ошибка")
                            .WithColor(errColor)
                            .WithCurrentTimestamp()
                            .AddField("Ошибка:", $"{result.Error}")
                            .AddField("Причина ошибки:", $"{result.ErrorReason}");

                    await context.Channel.SendMessageAsync("", false, errEmbed.Build());

                    Console.WriteLine($"[{DateTime.Now}] {result.Error} caused by {result.ErrorReason}");
                }
                else Console.WriteLine($"[{DateTime.Now}] {result}");
            }
        }
    }
}
