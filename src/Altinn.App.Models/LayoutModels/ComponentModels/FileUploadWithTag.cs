using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class FileUploadWithTag : BaseDataComponent
{
    [JsonPropertyName("size")]
    [JsonPropertyOrder(100)]
    public string Size { get; set; } = "h2";
}