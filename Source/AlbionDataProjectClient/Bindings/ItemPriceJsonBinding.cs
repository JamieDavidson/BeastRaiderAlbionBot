using Newtonsoft.Json;

namespace BeastRaiderAlbionBot.AlbionDataProjectClient.Bindings;

public sealed class ItemPriceJsonBinding
{
    [JsonProperty(Required = Required.Always, PropertyName = "item_id")]
    public string ItemId { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public string City { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public int Quality { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "sell_price_min")]
    public int MinimumSellPrice { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "sell_price_min_date")]
    public DateTime MinimumSellPriceDate { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "sell_price_max")]
    public int MaximumSellPrice { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "sell_price_max_date")]
    public DateTime MaximumSellPriceDate { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "buy_price_min")]
    public int MinimumBuyPrice { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "buy_price_min_date")]
    public DateTime MinimumBuyPriceDate { get; set; }
    
    [JsonProperty(Required = Required.Always, PropertyName = "buy_price_max")]
    public int MaximumBuyPrice { get; set; }

    [JsonProperty(Required = Required.Always, PropertyName = "buy_price_max_date")]
    public DateTime MaximumBuyPriceDate { get; set; }
}