using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;

internal sealed class GoldPricePointJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public DateTime Timestamp { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public long Price { get; set; }
}