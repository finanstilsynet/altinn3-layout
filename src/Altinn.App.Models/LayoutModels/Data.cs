namespace Altinn.App.Models.LayoutModels;

public class Data
{
    [JsonPropertyName("layout")]
    public List<BaseComponent> Layout { get; set; } = default!;
}