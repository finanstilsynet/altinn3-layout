using Altinn.App.Models.JsonConverters;

namespace Altinn.App.Models.LayoutModels;

[JsonConverter(typeof(ComponentConverter))]
public abstract class BaseComponent
{
    [JsonPropertyName("id")]
    [JsonPropertyOrder(0)]
    public string Id { get; set; } = default!;

    [JsonPropertyName("type")]
    [JsonPropertyOrder(1)]
    public string Type { get; set; } = default!;

    [JsonPropertyName("textResourceBindings")]
    [JsonPropertyOrder(2)]
    public Dictionary<string,string> TextResourceBindings { get; set; } = default!;

    [JsonPropertyName("dataModelBindings")]
    [JsonPropertyOrder(3)]
    public Dictionary<string,string> DataModelBindings { get; set; } = default!;

    [JsonPropertyName("required")]
    [JsonPropertyOrder(4)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Required { get; set; } = false;
    
    [JsonPropertyName("readOnly")]
    [JsonPropertyOrder(5)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ReadOnly { get; set; } = false;

    [JsonPropertyOrder(6)]
    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Hidden { get; set; } = false;
}