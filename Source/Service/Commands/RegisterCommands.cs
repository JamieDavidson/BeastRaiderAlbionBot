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

        try
        {
            var guild = Program._discordClient.GetGuild(1065101489565073518);
            await guild.CreateApplicationCommandAsync(playerLookup.Build());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}