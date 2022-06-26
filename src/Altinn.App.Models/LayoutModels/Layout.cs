namespace Altinn.App.Models;

public record Layout
{
    [JsonPropertyName("$schema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Schema => "https://altinncdn.no/schemas/json/layout/layout.schema.v1.json";

    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public Data Data { get; set; } = default!;
}