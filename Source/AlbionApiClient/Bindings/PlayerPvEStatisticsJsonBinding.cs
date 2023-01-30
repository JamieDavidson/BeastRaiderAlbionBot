using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerPvEStatisticsJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public long Total { get; set; }
}