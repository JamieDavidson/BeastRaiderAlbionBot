using System.Globalization;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using Plotly.NET;
using Plotly.NET.CSharp;
using Plotly.NET.ImageExport;
using Chart = Plotly.NET.CSharp.Chart;

namespace BeastRaiderAlbionBot.Service.Graphing;

internal sealed class DataGrapher : IDataGrapher
{
    // Can't run this asynchronously for real yet, as Plotly doesn't have
    // proper async support for C# bindings, they have some bizarre F# async type
    // that we can't await here
    public async Task<string> GenerateGoldGraphAsync(GoldPriceHistory priceHistory)
    {
        var xValues = priceHistory.PricePoints.Select(pp => pp.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        var yValues = priceHistory.PricePoints.Select(pp => pp.Price);
        
        var chart = Chart.Line<string, long, string>(
            xValues,
            yValues,
            ShowMarkers: true);

        var base64 = chart.ToBase64PNGString(Height: 500, Width: 1500);

        return base64;
    }
}