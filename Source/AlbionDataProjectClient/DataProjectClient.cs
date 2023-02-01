using BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient;

public sealed class DataProjectClient : IDataProjectClient
{
    public async Task<GoldPriceHistory> GetGoldPriceHistory(long priceCount = 24)
    {
        var history = await GetAsync<GoldPricePointJsonBinding[]>($"gold?count={priceCount}");

        return new GoldPriceHistory(history.Select(ph => new GoldPricePoint(ph.Timestamp, ph.Price)));
    }

    private static async Task<T> GetAsync<T>(string path)
    {
        using var httpClient = CreateHttpClient();

        var response = await httpClient.GetAsync(path);

        var bodyJson = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(bodyJson);
    }

    private static HttpClient CreateHttpClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri("https://www.albion-online-data.com/api/v2/stats/")
        };
    }
}