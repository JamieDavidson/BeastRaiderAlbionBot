using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

internal sealed class PlayerLookupCommandHandler : ICommandHandler
{
    public async Task HandleAsync(SocketSlashCommand socketSlashCommand)
    {
        var playerName = (string)socketSlashCommand.Data.Options.First().Value;
        await socketSlashCommand.RespondAsync($"This will look up player {playerName}, eventually...");
    }
}