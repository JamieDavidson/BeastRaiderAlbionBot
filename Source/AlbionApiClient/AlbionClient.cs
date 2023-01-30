using BeastRaiderAlbionBot.AlbionApiClient.Bindings;
using BeastRaiderAlbionBot.AlbionApiClient.Domain;
using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient;

public sealed class AlbionClient : IAlbionClient
{
    public async Task<SearchResults> Search(string searchTerm)
    {
        var results = await GetAsync<SearchResultJsonBinding>($"search?q={searchTerm}");

        return ToDomain(results);
    }

    public async Task<Player> GetPlayer(string playerId)
    {
        var result = await GetAsync<PlayerJsonBinding>($"players/{playerId}");

        return ToDomain(result);
    }

    private static async Task<T> GetAsync<T>(string path)
    {
        using var client = CreateHttpClient();

        var response = await client.GetAsync(path);

        var bodyJson = await response.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<T>(bodyJson);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static SearchResults ToDomain(SearchResultJsonBinding binding)
    {
        return new SearchResults(binding.Players.Select(ToDomain).ToArray(), binding.Guilds.Select(ToDomain).ToArray());
    }

    private static PlayerSearchResult ToDomain(PlayerSearchResultJsonBinding binding)
    {
        return new PlayerSearchResult(
            binding.Id,
            binding.Name,
            binding.GuildId,
            binding.AllianceId,
            binding.Avatar,
            binding.AvatarRing,
            binding.KillFame,
            binding.DeathFame,
            binding.FameRatio,
            binding.TotalKills ?? 0,
            binding.GvgKills ?? 0,
            binding.GvgWon ?? 0);
    }

    private static GuildSearchResult ToDomain(GuildSearchResultJsonBinding binding)
    {
        return new GuildSearchResult(
            binding.Id,
            binding.Name,
            binding.AllianceId,
            binding.AllianceName,
            binding.KillFame ?? 0,
            binding.DeathFame);
    }
    
    private static Player ToDomain(PlayerJsonBinding binding)
    {
        return new Player(
            binding.Id,
            binding.Name,
            binding.GuildName,
            binding.AllianceName,
            binding.AllianceId,
            binding.AllianceTag,
            binding.KillFame ?? 0,
            binding.DeathFame ?? 0,
            binding.FameRatio,
            binding.LifetimeStatistics.PvE.Total,
            binding.LifetimeStatistics.Gathering.All.Total,
            binding.LifetimeStatistics.Crafting.Total);
    }

    private static HttpClient CreateHttpClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri("https://gameinfo.albiononline.com/api/gameinfo/")
        };
    }
}