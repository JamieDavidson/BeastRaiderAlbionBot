using BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Repositories;

public sealed class ItemNameRepository : IItemNameRepository
{
    private readonly IReadOnlyCollection<ItemDefinition> _loadedItems;

    public ItemNameRepository()
    {
        var json = File.ReadAllText(@".\StaticData\items.json");

        var itemJson = JsonConvert.DeserializeObject<ItemDefinitionJsonBinding[]>(json);

        _loadedItems = itemJson!.Select(ToDomain).ToArray();
    }

    public Task<ItemDefinition?> GetByUniqueNameAsync(string uniqueName)
    {
        return Task.FromResult(_loadedItems.FirstOrDefault(i => i.UniqueName.Equals(uniqueName, StringComparison.InvariantCultureIgnoreCase)));
    }

    public Task<ItemDefinition[]> GetByEnglishNameAsync(string englishName)
    {
        return Task.FromResult(_loadedItems.Where(a => a.EnglishName.Equals(englishName, StringComparison.InvariantCultureIgnoreCase)).ToArray());
    }

    public Task<ItemDefinition[]> FindFuzzyMatches(string searchTerm)
    {
        throw new NotImplementedException();
    }

    private static ItemDefinition ToDomain(ItemDefinitionJsonBinding binding)
    {
        return new ItemDefinition(binding.UniqueName, binding.LocalizedNames?.English ?? "Unknown");
    }
}