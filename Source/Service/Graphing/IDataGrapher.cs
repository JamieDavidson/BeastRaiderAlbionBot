using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;

namespace BeastRaiderAlbionBot.Service.Graphing;

internal interface IDataGrapher
{
    Task<string> GenerateGoldGraphAsync(GoldPriceHistory priceHistory);
}