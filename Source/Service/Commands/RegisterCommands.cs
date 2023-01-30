using Discord;

namespace BeastRaiderAlbionBot.Service.Commands;

internal static class RegisterCommands
{
    public static async Task SetupSlashCommands()
    {
        var playerLookup = new SlashCommandBuilder()
            .WithName("player")
            .WithDescription("Lookup player by name")
            .AddOption("player", ApplicationCommandOptionType.String, "The player to look up", isRequired: true);

        var goldChart = new SlashCommandBuilder()
            .WithName("gold")
            .WithDescription("Create gold price history graph")
            .AddOption("hours", ApplicationCommandOptionType.Integer, "The amount of hours to retrieve data for, default 24", isRequired: false);

        try
        {
            var guild = Program._discordClient.GetGuild(1065101489565073518);
            await guild.CreateApplicationCommandAsync(playerLookup.Build());
            await guild.CreateApplicationCommandAsync(goldChart.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}