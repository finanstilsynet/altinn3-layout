using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public record AttachmentList : BaseTextComponent
{
    [JsonPropertyName("dataTypeIds")]
    [JsonPropertyOrder(100)]
    [Required]
    [MinLength(1)]
    public List<string> DataTypeIds { get; set; } = new();
}