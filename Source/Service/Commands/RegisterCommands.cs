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

        var itemLookup = new SlashCommandBuilder()
            .WithName("item")
            .WithDescription("Look up an item's price by unique name")
            .AddOption("name", ApplicationCommandOptionType.String, "The item name to search for");

        try
        {
            var guild = Program._discordClient.GetGuild(1065101489565073518);
            await guild.CreateApplicationCommandAsync(playerLookup.Build());
            await guild.CreateApplicationCommandAsync(goldChart.Build());
            await guild.CreateApplicationCommandAsync(itemLookup.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}