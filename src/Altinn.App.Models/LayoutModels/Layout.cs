namespace Altinn.App.Models.LayoutModels;

public class Layout
{
    [JsonPropertyName("$schema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Schema => "https://altinncdn.no/schemas/json/layout/layout.schema.v1.json";
    public Data Data { get; set; } = default!;
}