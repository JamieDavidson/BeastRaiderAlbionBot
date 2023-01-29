using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string GuildName { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string AllianceName { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string AllianceId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string AllianceTag { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public long? KillFame { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public long? DeathFame { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public decimal FameRatio { get; set; }
}