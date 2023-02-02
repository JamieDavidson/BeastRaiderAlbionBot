namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;

public sealed record ItemPrice(
    string UniqueName,
    string City,
    (int Price, DateTime TimeStamp) MinimumSell,
    (int Price, DateTime Timestamp) MaximumSell,
    (int Price, DateTime Timestamp) MinimumBuy,
    (int Price, DateTime Timestamp) MaximumBuy);