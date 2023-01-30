using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerCraftingStatisticsJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public long Total { get; set; }
}