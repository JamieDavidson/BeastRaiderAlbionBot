using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionApiClient.Bindings;

internal sealed class SearchResultJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public GuildSearchResultJsonBinding[] Guilds { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public PlayerSearchResultJsonBinding[] Players { get; set; }
}