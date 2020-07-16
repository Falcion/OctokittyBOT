using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stratum
{
    public class Other : ModuleBase<SocketCommandContext>
    {
        Color msgColor = new Color(0x4FEFC8);

        [Command("help")]

        public async Task Help()
        {
            EmbedBuilder projectEmbed = new EmbedBuilder();

            projectEmbed.WithTitle("Проектные команды:")
                        .WithColor(msgColor)
                        .AddField("~lib", "Показывает библиотеку кодов внутри проекта.")
                        .AddField("~pull", "Показывает журнал изменений проекта, или информацию о нём.")
                        .AddField("~clear", "Чистит весь журнал изменений.")
                        .AddField("~push [тяж] [чист] [код] [предпис]", "Публикует в журнале изменений информацию об обновлении проекта и отправляет соотвествующую инструкцию.");

            await Context.Channel.SendMessageAsync("", false, projectEmbed.Build());
        }
    }
}
