using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;

internal sealed class ItemDefinitionJsonBinding
{
    [JsonProperty(Required = Required.Always)]
    public string UniqueName { get; set; }
    
    [JsonProperty(Required = Required.AllowNull)]
    public ItemLocalizedNamesJsonBinding? LocalizedNames { get; set; }
}