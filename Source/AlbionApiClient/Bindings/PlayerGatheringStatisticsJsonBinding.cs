using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerGatheringStatisticsJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public PlayerAllGatheringStatisticsJsonBinding All { get; set; }
}