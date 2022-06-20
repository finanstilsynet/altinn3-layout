using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class AddressComponent : BaseDataComponent
{
    [JsonPropertyName("simplified")]
    [JsonPropertyOrder(100)]
    public bool Simplified { get; set; } = false;
}