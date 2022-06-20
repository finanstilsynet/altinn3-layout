using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class AttachmentList : BaseTextComponent
{
    [JsonPropertyName("dataTypeIds")]
    [JsonPropertyOrder(100)]
    [Required]
    [MinLength(1)]
    public List<string> DataTypeIds { get; set; } = new();
}