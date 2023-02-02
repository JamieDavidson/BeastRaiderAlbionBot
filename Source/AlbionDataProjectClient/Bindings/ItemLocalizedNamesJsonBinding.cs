using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;

internal sealed class ItemLocalizedNamesJsonBinding
{
    [JsonProperty(Required = Required.Always, PropertyName = "EN-US")]
    public string English { get; set; }
}