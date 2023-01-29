using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

internal interface ICommandHandler
{
    Task HandleAsync(SocketSlashCommand socketSlashCommand);
}