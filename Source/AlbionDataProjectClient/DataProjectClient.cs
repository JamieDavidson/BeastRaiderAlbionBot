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

    public async Task<ItemPrice[]> GetItemPrices(IEnumerable<string> itemNames)
    {
        var itemPrices = await GetAsync<ItemPriceJsonBinding[]>($"prices/{string.Join(',', itemNames)}");

        return itemPrices.Select(ToDomain).ToArray();
    }

    private static ItemPrice ToDomain(ItemPriceJsonBinding binding)
    {
        return new ItemPrice(
            binding.ItemId,
            binding.City,
            (binding.MinimumSellPrice, binding.MinimumSellPriceDate),
            (binding.MaximumSellPrice, binding.MaximumSellPriceDate),
            (binding.MinimumBuyPrice, binding.MinimumBuyPriceDate),
            (binding.MaximumBuyPrice, binding.MaximumBuyPriceDate));
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