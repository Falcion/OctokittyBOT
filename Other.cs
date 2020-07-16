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
            EmbedBuilder gitEmbed = new EmbedBuilder();

            gitEmbed.WithTitle("Комадны Git:")
                    .WithColor(msgColor)
                    .AddField("~gitapi-limit", "Показывает информацию о запросах к GitHub API.")
                    .AddField("~repos-show [название репозитории] [имя автора]", "Показывает основную информацию о репозитории GitHub")
                    .AddField("~repos-branches [название репозитории] [имя автора]", "Показывает все различные ветки репозитории.")
                    .AddField("~repos-releases [название репозитории] [имя автора]", "Показывает различные выпуски репозитории.")
                    .AddField("~repos-issues [название репозитории] [имя автора] (количество дней)", "Показывает открытые темы репозитории (с учётом времени).")
                    .AddField("~repos-commits [название репозитории] [имя автора] (название ветки)", "Показывает обновления репозитории по определенной ветке.");

            await Context.Channel.SendMessageAsync("", false, gitEmbed.Build());

            EmbedBuilder advGit = new EmbedBuilder();

            advGit.WithTitle("Команды продвинутого Git:")
                  .WithColor(msgColor)
                  .AddField("~repos-advshow [название репозитории] [имя автора]", "Показывает продвинутую информацию о репозитории.")
                  .AddField("~repos-advbranches [название репозитории] [имя автора] [название ветки]", "Показывает продвинутую информацию о ветки репозитории.")
                  .AddField("~repos-advreleases [название репозитории] [имя автора] [название выпуска]", "Показывает продвинутую информацию о выпуске репозитории.");

            await Context.Channel.SendMessageAsync("", false, advGit.Build());
        }
    }
}
