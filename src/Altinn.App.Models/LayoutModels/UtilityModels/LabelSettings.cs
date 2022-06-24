namespace Altinn.App.Models;

public record LabelSettings
{
    [JsonPropertyName("optionalIndicator")]
    public bool OptionalIndicator { get; set; } = true;
}