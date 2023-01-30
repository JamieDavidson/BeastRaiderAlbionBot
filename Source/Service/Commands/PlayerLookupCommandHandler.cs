using BeastRaiderAlbionBot.AlbionApiClient;
using Discord;
using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

internal sealed class PlayerLookupCommandHandler : ICommandHandler
{
    private readonly IAlbionClient _albionClient;

    public PlayerLookupCommandHandler(IAlbionClient albionClient)
    {
        _albionClient = albionClient;
    }

    public async Task HandleAsync(SocketSlashCommand socketSlashCommand)
    {
        var playerName = (string)socketSlashCommand.Data.Options.First().Value;

        var results = await _albionClient.Search(playerName);

        if (!results.Players.Any())
        {
            await socketSlashCommand.RespondAsync($"No players found matching name {playerName}");
            return;
        }

        var match = results.Players.FirstOrDefault(p => p.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));

        if (match != null)
        {
            var player = await _albionClient.GetPlayer(match.Id);

            var totalFame = player.KillFame +
                            player.PvEFame +
                            player.CraftingFame +
                            player.GatheringFame;

            var embedBuilder = new EmbedBuilder()
                .WithTitle($"Player information for {match.Name}")
                .WithColor(Color.Green)
                .WithFields(new[]
                {
                    new EmbedFieldBuilder().WithName("Total Fame").WithValue(totalFame.ToString("N0")).WithIsInline(false),
                    new EmbedFieldBuilder().WithName("Kill fame").WithValue(player.KillFame.ToString("N0")).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Death fame").WithValue(player.DeathFame.ToString("N0")).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Fame ratio").WithValue(player.FameRatio).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("PvE Fame").WithValue(player.PvEFame.ToString("N0")).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Gathering Fame").WithValue(player.GatheringFame.ToString("N0")).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Crafting Fame").WithValue(player.CraftingFame.ToString("N0")).WithIsInline(true)
                });
            
            await socketSlashCommand.RespondAsync(embed: embedBuilder.Build());
            return;
        }

        var names = string.Join(Environment.NewLine, results.Players.Select(p => p.Name));
        
        await socketSlashCommand.RespondAsync($"Found {results.Players.Count} potential matches: \r\n{names}");
    }
}