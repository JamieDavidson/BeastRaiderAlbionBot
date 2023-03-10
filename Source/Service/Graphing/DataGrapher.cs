using System.Drawing.Imaging;
using BeastRaiderAlbionBot.AlbionDataProjectClient.Domain;
using ScottPlot;

namespace BeastRaiderAlbionBot.Service.Graphing;

internal sealed class DataGrapher : IDataGrapher
{
    // Can't run this asynchronously for real yet, as Plotly doesn't have
    // proper async support for C# bindings, they have some bizarre F# async type
    // that we can't await here
    public string GenerateGoldGraph(GoldPriceHistory priceHistory)
    {
        var xValues = priceHistory.PricePoints.Select(pp => pp.DateTime);
        var yValues = priceHistory.PricePoints.Select(pp => pp.Price);

        var chart = new Plot(1000, 500);

        chart.AddScatter(xValues.Select(x => x.ToOADate()).ToArray(), yValues.Select(c => (double)c).ToArray());
        chart.XAxis.DateTimeFormat(true);
        chart.XAxis.Label("Timestamp");
        chart.YAxis.Label("Gold Price");
        chart.Title($"Albion gold price over last {priceHistory.PricePoints.Count} hours");
        
        var bitmap = chart.Render();
        using var ms = new MemoryStream();
        bitmap.Save(ms, ImageFormat.Jpeg);
        var base64 = Convert.ToBase64String(ms.ToArray());

        return base64;
    }
}