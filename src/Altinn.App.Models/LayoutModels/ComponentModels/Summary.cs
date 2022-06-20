using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class Summary : BaseComponent
{
    [JsonPropertyName("simplified")]
    [JsonPropertyOrder(100)]
    public bool Simplified { get; set; } = false;
}