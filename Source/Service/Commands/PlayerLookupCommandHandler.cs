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

            var embedBuilder = new EmbedBuilder()
                .WithTitle($"Player information for {match.Name}")
                .WithColor(Color.Green)
                .WithFields(new[]
                {
                    new EmbedFieldBuilder().WithName("Kill fame").WithValue(player.KillFame).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Death fame").WithValue(player.DeathFame).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Fame ratio").WithValue(player.FameRatio).WithIsInline(true)
                });
            
            await socketSlashCommand.RespondAsync(embed: embedBuilder.Build());
            return;
        }

        var names = string.Join(Environment.NewLine, results.Players.Select(p => p.Name));
        
        await socketSlashCommand.RespondAsync($"Found {results.Players.Count} potential matches: \r\n{names}");
    }
}