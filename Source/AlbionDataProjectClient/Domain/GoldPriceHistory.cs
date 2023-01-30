namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;

public sealed class GoldPriceHistory
{
    public IReadOnlyCollection<GoldPricePoint> PricePoints { get; }

    public GoldPriceHistory(IEnumerable<GoldPricePoint> pricePoints)
    {
        PricePoints = pricePoints
            .OrderBy(pp => pp.DateTime)
            .ToArray();
    }
}

public sealed record GoldPricePoint(DateTime DateTime, long Price);