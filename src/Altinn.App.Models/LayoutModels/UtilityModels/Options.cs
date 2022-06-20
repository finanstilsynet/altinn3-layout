using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class Options
{
    [JsonPropertyName("label")]
    [Required]
    public string Label { get; set; } = default!;

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; } = default!;
}