using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;

namespace BeastRaiderAlbionBot.Service.Graphing;

internal interface IDataGrapher
{
    string GenerateGoldGraph(GoldPriceHistory priceHistory);
}