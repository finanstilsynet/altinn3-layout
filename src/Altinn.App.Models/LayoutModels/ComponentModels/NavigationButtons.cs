using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class NavigationButtons : BaseTextComponent
{
    [JsonPropertyName("size")]
    [JsonPropertyOrder(100)]
    public string Size { get; set; } = "h2";
}