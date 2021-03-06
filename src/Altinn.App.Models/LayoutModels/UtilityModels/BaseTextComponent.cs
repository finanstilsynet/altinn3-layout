namespace Altinn.App.Models;

public record BaseTextComponent : BaseComponent
{
    [JsonPropertyName("textResourceBindings")]
    [JsonPropertyOrder(2)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Dictionary<string, string> TextResourceBindings { get; set; } = default!;
}