using BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient;

public sealed class DataProjectClient : IDataProjectClient
{
    public async Task<GoldPriceHistory> GetGoldPriceHistory(long priceCount = 24)
    {
        using var httpClient = CreateHttpClient();

        var response = await httpClient.GetAsync($"gold?count={priceCount}");

        var bodyJson = await response.Content.ReadAsStringAsync();

        var history = JsonConvert.DeserializeObject<GoldPricePointJsonBinding[]>(bodyJson);

        return new GoldPriceHistory(history.Select(ph => new GoldPricePoint(ph.Timestamp, ph.Price)));
    }

    private static HttpClient CreateHttpClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri("https://www.albion-online-data.com/api/v2/stats/")
        };
    }
}