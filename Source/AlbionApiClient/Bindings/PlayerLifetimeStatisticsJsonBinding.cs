using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerLifetimeStatisticsJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public PlayerCraftingStatisticsJsonBinding Crafting { get; set; }
}