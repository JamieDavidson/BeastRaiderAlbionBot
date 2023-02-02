using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Repositories;
using Discord;
using Discord.WebSocket;

namespace BeastRaiderAlbionBot.Service.Commands;

public sealed class ItemLookupCommandHandler : ICommandHandler
{
    private readonly IItemNameRepository _itemNameRepository;

    public ItemLookupCommandHandler(IItemNameRepository itemNameRepository)
    {
        _itemNameRepository = itemNameRepository
            ?? throw new ArgumentNullException(nameof(itemNameRepository));
    }

    public async Task HandleAsync(SocketSlashCommand socketSlashCommand)
    {
        var itemName = socketSlashCommand.Data.Options.First().Value as string;

        var item = await _itemNameRepository.GetByUniqueNameAsync(itemName);

        if (item == null)
        {
            var itemMatches = await _itemNameRepository.GetByEnglishNameAsync(itemName);

            if (!itemMatches.Any())
            {
                var fuzzy = TryFuzzySearch(itemName);
                
                await socketSlashCommand.RespondAsync($"No item found matching unique name {itemName}");
            }
            else if (itemMatches.Length == 1)
            {
                
                await socketSlashCommand.RespondAsync($"Found item matching {itemName}, unique name is {itemMatches.First().UniqueName}");
            }
            else
            {
                var embedBuilder = new EmbedBuilder().WithDescription(string.Join(Environment.NewLine, itemMatches.Select(a => a.UniqueName)));
                
                await socketSlashCommand.RespondAsync(
                    "Found multiple potential matches, try searching for one of the following: ", new [] { embedBuilder.Build() });
            }
            
            return;
        }

        await socketSlashCommand.RespondAsync($"Found item matching {itemName}, item name is {item.EnglishName}");
    }

    private async Task<ItemDefinition[]> TryFuzzySearch(string searchTerm)
    {
        return await _itemNameRepository.FindFuzzyMatches(searchTerm);
    }
}