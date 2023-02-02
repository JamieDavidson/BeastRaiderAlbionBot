using BeastRaiderAlbionBot.AlbionApiClient;
using BeastRaiderAlbionBot.AlbionDataProjectClient;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Repositories;
using BeastRaiderAlbionBot.Service.Graphing;
using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

internal static class RootCommandHandler
{
    private static readonly Dictionary<string, ICommandHandler> HandlerMap = new()
    {
        { "player", new PlayerLookupCommandHandler(new AlbionClient()) },
        { "gold", new GoldLookupCommandHandler(new DataProjectClient(), new DataGrapher()) },
        { "item", new ItemLookupCommandHandler(new ItemNameRepository()) }
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