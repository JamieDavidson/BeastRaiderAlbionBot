using BeastRaiderAlbionBot.AlbionDataProjectClient;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using BeastRaiderAlbionBot.Service.Graphing;
using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

internal sealed class GoldLookupCommandHandler : ICommandHandler
{
    private readonly IDataProjectClient _dataProjectClient;
    private readonly IDataGrapher _dataGrapher;

    public GoldLookupCommandHandler(IDataProjectClient dataProjectClient, IDataGrapher dataGrapher)
    {
        _dataProjectClient = dataProjectClient;
        _dataGrapher = dataGrapher;
    }

    public async Task HandleAsync(SocketSlashCommand socketSlashCommand)
    {
        await socketSlashCommand.RespondAsync("This takes a little while, so I'll post it here when it's done");

        GoldPriceHistory? priceHistory;
        if (socketSlashCommand.Data.Options.Any())
        {
            var hours = (long)socketSlashCommand.Data.Options.First().Value;

            if (hours > 720)
            {
                hours = 720;
            }

            if (hours <= 0)
            {
                hours = 6;
            }
            
            priceHistory = await _dataProjectClient.GetGoldPriceHistory(hours);
        }
        else
        {
            priceHistory = await _dataProjectClient.GetGoldPriceHistory();
        }
        
        var graph = _dataGrapher.GenerateGoldGraph(priceHistory);
        await socketSlashCommand.Channel.SendFileAsync(new MemoryStream(Convert.FromBase64String(graph)), "gold-graph.png");
    }
}