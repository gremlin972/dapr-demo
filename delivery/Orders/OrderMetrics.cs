using System.Text.Json.Serialization;
namespace delivery
{
    public record OrderMetrics
    (
        [property: JsonPropertyName("Pending orders")] int Count,
        [property: JsonPropertyName("Max duration")] int MaxWaiting
    );
}
