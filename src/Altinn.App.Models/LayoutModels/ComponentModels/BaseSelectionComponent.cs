using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public abstract class BaseSelectionComponent : BaseDataComponent
{
    [JsonPropertyName("optionsId")]
    [JsonPropertyOrder(100)]
    public string? OptionsId { get; set; }

    [JsonPropertyName("options")]
    [JsonPropertyOrder(101)]
    public Options? Options { get; set; }
}