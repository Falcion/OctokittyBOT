using Discord.Commands;
using System.Threading.Tasks;
using Discord;

namespace Stratum {
    public class Handler : ModuleBase<SocketCommandContext> {

        string baseURL = "https://github.com/Falcion/Stratum";

        string[] gitURL = { "/issues", "/releases", "/tree/syntax/.wikia" };

        [Command("gitapi-help")]
    
        public async Task ApiHelp() {

            string prefix 
                    = Storage.prefix;

            string imgURL 
                    = "https://github.com/Falcion/Stratum/blob/syntax/.src/icon.png";

            EmbedBuilder messageEmbed = new EmbedBuilder()
        
                                                        .WithTitle("GitHub API - Help")
                                                        .WithDescription("For additional links, please type: ``gitapi-links`` and you'll get all information, links and etc.")
                                                        .WithColor(Color.LighterGrey)
                                                        .WithCurrentTimestamp()
                                                        .WithUrl(baseURL + gitURL[2])
                                                        .WithThumbnailUrl(imgURL)
                                                        .AddField($"``{prefix}gitapi-limit``", "Shows information about current GitHub API Limits (for Core and Search Requests).")
                                                        .AddField($"``{prefix}repos-info [author] [name]``", "Shows information about specified repository.")
                                                        .AddField($"``{prefix}repos-branches [author] [name]``", "Shows information about branches of specified repository.")
                                                        .AddField($"``{prefix}repos-releases [author] [name]``", "Shows information about releases of specified repository (includes page-system.)")
                                                        .AddField($"``{prefix}repos-issues [author] [name] [page number] [filters]``", "Shows list of issues in specified repository that sorted by specified filters. For more information check hyperlink in title.")
                                                        .AddField($"``{prefix}repos-commits [author] [name] [page number] [filters]``", "Shows list of commits in specified repository that sorted by specified filters. For more information check hyperlink in title.")
                                                        .AddField($"``{prefix}repos-core [repository author] [repository name]``", "Shows advanced information about specified repository.")
                                                        .AddField($"``{prefix}branch-info [repository author] [repository name] [branch name]", "Shows advanced information about specified branch.")
                                                        .AddField($"``{prefix}release-info [repository author] [repository name] [tag]", "Shows advanced information about specified release.")
                                                        .AddField($"``{prefix}issue-info [repository author] [repository name] [issue number]", "Shows advanced information about specified issue.")
                                                        .AddField($"``{prefix}commit-info [repository author] [repository name] [reference]", "Shows advanced information about specified commit.")
                                                        .AddField($"``{prefix}user-core [username (login)]", "Shows advanced information about user.")
                                                        .AddField($"``{prefix}gitapi-help", "Shows information about all commands.")
                                                        .AddField($"``{prefix}gitapi-links", "Shows all specified links of this project.");

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }

        [Command("gitapi-links")]

        public async Task ApiLinks() {

            string imgURL 
                    = "https://github.com/Falcion/Stratum/blob/syntax/.src/icon.png";

            EmbedBuilder messageEmbed = new EmbedBuilder()

                                                        .WithTitle("GitHub API - Links")
                                                        .WithColor(Color.LighterGrey)
                                                        .WithCurrentTimestamp()
                                                        .WithUrl("https://github.com/Falcion/Stratum#information")
                                                        .WithThumbnailUrl(imgURL)
                                                        .AddField("Bot's Repository on GitHub:", baseURL)
                                                        .AddField("Issues:", baseURL + gitURL[0])
                                                        .AddField("Releases:", baseURL + gitURL[1])
                                                        .AddField("Commands' Syntax:", baseURL + gitURL[2]);

            await Context.Channel.SendMessageAsync("", false,
                                                        messageEmbed.Build()    );
        }
    }
}