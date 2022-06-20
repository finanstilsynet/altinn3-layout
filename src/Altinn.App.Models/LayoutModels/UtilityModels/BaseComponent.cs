using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

[JsonConverter(typeof(ComponentConverter))]
public abstract class BaseComponent
{
    [JsonPropertyName("id")]
    [JsonPropertyOrder(0)]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [RegularExpression(@"^[0-9a-zA-Z][0-9a-zA-Z-]*[0-9a-zA-Z]$")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("type")]
    [JsonPropertyOrder(1)]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Type { get; set; } = default!;



    [JsonPropertyName("required")]
    [JsonPropertyOrder(1000)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Required { get; set; } = false;

    [JsonPropertyName("readOnly")]
    [JsonPropertyOrder(1001)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ReadOnly { get; set; } = false;

    [JsonPropertyOrder(1002)]
    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Hidden { get; set; } = false;
}