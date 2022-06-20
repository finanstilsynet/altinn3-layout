namespace Altinn.App.Models;

public class LabelSettings
{
    [JsonPropertyName("optionalIndicator")]
    public bool OptionalIndicator { get; set; } = true;
}