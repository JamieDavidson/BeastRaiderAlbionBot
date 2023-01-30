using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerAllGatheringStatisticsJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public long Total { get; set; }
}