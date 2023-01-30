using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient;

public interface IDataProjectClient
{
    Task<GoldPriceHistory> GetGoldPriceHistory(long priceCount = 24);
}