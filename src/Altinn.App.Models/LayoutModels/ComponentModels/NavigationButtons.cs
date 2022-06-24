using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public record NavigationButtons : BaseTextComponent
{
    [JsonPropertyName("size")]
    [JsonPropertyOrder(100)]
    public string Size { get; set; } = "h2";
}