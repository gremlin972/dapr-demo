using System.Text.Json.Serialization;

namespace delivery
{
    public record Order(
        [property: JsonPropertyName("Guid")] Guid _Guid,
        [property: JsonPropertyName("SeqNr")] int _SeqNr, 
        [property: JsonPropertyName("Time")] DateTime _Time
    );
}