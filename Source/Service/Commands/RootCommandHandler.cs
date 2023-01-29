using BeastRaiderAlbionBot.AlbionApiClient;
using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

internal static class RootCommandHandler
{
    private static readonly Dictionary<string, ICommandHandler> HandlerMap = new()
    {
        { "player", new PlayerLookupCommandHandler(new AlbionClient()) }
    };
    
    public static async Task HandleSlashCommand(SocketSlashCommand arg)
    {
        Console.WriteLine($"Received {arg.CommandName}");
        if (!HandlerMap.TryGetValue(arg.CommandName, out var handler))
        {
            return;
        }

        await handler.HandleAsync(arg);
    }
}