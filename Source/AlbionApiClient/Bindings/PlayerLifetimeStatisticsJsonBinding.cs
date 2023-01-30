using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerLifetimeStatisticsJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public PlayerCraftingStatisticsJsonBinding Crafting { get; set; }

    [JsonProperty(Required = Required.Always)]
    public PlayerGatheringStatisticsJsonBinding Gathering { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public PlayerPvEStatisticsJsonBinding PvE { get; set; }
}