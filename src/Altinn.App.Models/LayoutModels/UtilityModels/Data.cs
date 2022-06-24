namespace Altinn.App.Models;

public record Data
{
    [JsonPropertyName("layout")]
    public List<BaseComponent> Layout { get; set; } = new();
}