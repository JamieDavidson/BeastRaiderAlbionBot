using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class GuildSearchResultJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string AllianceId { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string AllianceName { get; set; }

    [JsonProperty(Required = Required.AllowNull)]
    public long? KillFame { get; set; }

    [JsonProperty(Required = Required.Always)]
    public long DeathFame { get; set; }
}