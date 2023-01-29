using BeastRaiderAlbionBot.AlbionApiClient.Domain;

namespace BeastRaiderAlbionBot.AlbionApiClient;

public interface IAlbionClient
{
    public Task<SearchResults> Search(string searchTerm);

    public Task<Player> GetPlayer(string playerId);
}