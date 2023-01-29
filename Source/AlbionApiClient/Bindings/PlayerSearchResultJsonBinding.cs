using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class PlayerSearchResultJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public string Id { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string GuildId { get; set; }
    
    [JsonProperty(Required = Required.AllowNull)]
    public string? GuildName { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string AllianceId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string Avatar { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string AvatarRing { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public long KillFame { get; set; }

    [JsonProperty(Required = Required.Always)]
    public long DeathFame { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public decimal FameRatio { get; set; }
    
    [JsonProperty(Required = Required.AllowNull)]
    public long? TotalKills { get; set; }
    
    [JsonProperty(Required = Required.AllowNull)]
    public long? GvgKills { get; set; }
    
    [JsonProperty(Required = Required.AllowNull)]
    public long? GvgWon { get; set; }
}