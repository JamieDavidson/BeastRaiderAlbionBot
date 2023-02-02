using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Repositories;

public interface IItemNameRepository
{
    Task<ItemDefinition?> GetByUniqueNameAsync(string uniqueName);

    Task<ItemDefinition[]> GetByEnglishNameAsync(string name);

    Task<ItemDefinition[]> FindFuzzyMatches(string searchTerm);
}