using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace Stratum
{
    public class Project : ModuleBase<SocketCommandContext>
    {
        Color msgColor = new Color(0x4FEFC8);

        [Command("lib")]

        public async Task Library()
        {
            EmbedBuilder libEmbed = new EmbedBuilder();

            libEmbed.WithTitle("Библиотека кодов")
                    .WithColor(msgColor)
                    .WithCurrentTimestamp()
                    .AddField("Код 0x00050", "Соотвествие: обновление списка файлов, репозитории и архива файлов.")
                    .AddField("Код 0x00150", "Соотвествие: обновление списка модификаций, списка файлов, репозитории, архива файлов.")
                    .AddField("Код 0x05150", "Соотвествие: обновление списка файлов, репозитории и архива файлов.")
                    .AddField("Код 0x00555", "Соотвествие: обновление репозитории и архива файлов.");

            await Context.Channel.SendMessageAsync("", false, libEmbed.Build());
        }

        [Command("pull")]

        public async Task Pull()
        {
            EmbedBuilder pullEmbed = new EmbedBuilder();

            pullEmbed.WithTitle("Журнал изменений проекта")
                     .WithColor(msgColor)
                     .WithCurrentTimestamp();
            string[] pullArray = File.ReadAllLines("pull.log");

            if(pullArray.Length == 1)
            {
                pullEmbed.AddField("Статус журнала:", "Неизвестно.")
                         .AddField("Последняя дата изменений:", "Неизвестно.")
                         .AddField("Общее количество изменений:", "Неизвестно.");

                await Context.Channel.SendMessageAsync("", false, pullEmbed.Build());
            }
            if(pullArray.Length > 1)
            {
                int pullCount = pullArray.Count();
                string currentPull = pullArray[pullCount - 1];

                string[] currentArray = currentPull.Split(' ');

                string dateFragment = currentArray[0].Remove(0, 1);
                string timeFragment = currentArray[1].Replace(']', ' ');

                string forceDate = dateFragment + ' ' + timeFragment;

                pullEmbed.AddField("Статус журнала:", "Активен.")
                         .AddField("Последняя дата изменений:", $"{forceDate}")
                         .AddField("Общее количество изменений:", $"{pullCount - 1}");

                await Context.Channel.SendMessageAsync("", false, pullEmbed.Build());
                await Context.Channel.SendFileAsync("pull.log");
            }
        }

        [Command("push")]
        [RequireOwner]

        public async Task Push(bool isHard, bool isWiped, 
                                        string pushCode, [Remainder]string desc = "Отсутствует.")
        {
            string[] codeArray = { "0x00050", "0x00150", "0x05150", "0x00555" };

            if (!codeArray.Contains(pushCode))
            {
                EmbedBuilder errEmbed = new EmbedBuilder();

                errEmbed.WithTitle("Критическая ошибка")
                        .WithColor(msgColor)
                        .WithCurrentTimestamp()
                        .AddField("Причина ошибки:", "Ошибка в указании аргументов.");

                await Context.Channel.SendMessageAsync("", false, errEmbed.Build());
                return;
            }

            string hardwarePush;

            if (isHard == true && isWiped == true) hardwarePush = "Тяжёлая.";
            else if ((isHard == true && isWiped == false) || (isHard == false && isWiped == true)) hardwarePush = "Средняя.";
            else hardwarePush = "Слабая.";

            string hardString;
            if (isHard == true) hardString = "Да.";
            else hardString = "Нет.";

            string wipedString;
            if (isWiped == true) wipedString = "Да.";
            else wipedString = "Нет.";

            string reactPush = "";
            switch (pushCode)
            {
                case "0x00050": reactPush = "Реакция: обновление списка файлов, репозитории и архива файлов.";
                    break;

                case "0x00150": reactPush = "Реакция: обновление списка модификаций, списка файлов, репозитории, архива файлов.";
                    break;

                case "0x05150": reactPush = "Реакция: обновление списка файлов, репозитории и архива файлов.";
                    break;

                case "0x00555": reactPush = "Реакция: обновление репозитории и архива файлов.";
                    break;
            }

            EmbedBuilder pushEmbed = new EmbedBuilder();

            pushEmbed.WithTitle("Изменения проекта")
                     .WithDescription(reactPush)
                     .WithColor(msgColor)
                     .WithCurrentTimestamp()
                     .AddField("Тяжесть изменения:", hardwarePush)
                     .AddField("Крупные ли изменения:", hardString)
                     .AddField("Чистка ли мира:", wipedString)
                     .AddField("Код обновления:", pushCode)
                     .AddField("Предписание:", desc);

            await Context.Channel.SendMessageAsync("", false, pushEmbed.Build());

            string fileText = File.ReadAllText("pull.log");
            File.WriteAllText("pull.log", fileText + Environment.NewLine +  $"[{DateTime.Now}] Код обновления: {pushCode}; Тяжесть изменений: {hardwarePush};" 
                    + $" Крупные изменения: {hardString}; Чистка мира: {wipedString}; Предписание: {desc}");
        }

        [Command("clear")]
        [RequireOwner]

        public async Task Clear()
        {
            EmbedBuilder clearEmbed = new EmbedBuilder();
                                         

            File.WriteAllText("pull.log", $"[{DateTime.Now}] Файл журнала успешно создан.");

            clearEmbed.WithTitle("Журнал изменений проекта успешно очищен")
                      .WithColor(msgColor)
                      .WithCurrentTimestamp()
                      .AddField("Дата обнуления журнала изменений:", $"{DateTime.Now}")
                      .AddField("Новый статус журнала изменений:", "Неизвестно");

            await Context.Channel.SendMessageAsync("", false, clearEmbed.Build());
        }
    }
}
