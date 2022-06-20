namespace Altinn.App.Models;

public class Data
{
    [JsonPropertyName("layout")]
    public List<BaseComponent> Layout { get; set; } = new();
}