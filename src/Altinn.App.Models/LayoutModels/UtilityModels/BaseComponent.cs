using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

[JsonConverter(typeof(ComponentConverter))]
public abstract record BaseComponent
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

    [JsonPropertyOrder(1000)]
    [JsonPropertyName("required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public BooleanLayoutDynamicsExprWrapper? Required { get; set; }

    [JsonPropertyOrder(1001)]
    [JsonPropertyName("readOnly")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public BooleanLayoutDynamicsExprWrapper? ReadOnly { get; set; }

    [JsonPropertyOrder(1002)]
    [JsonPropertyName("hidden")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public BooleanLayoutDynamicsExprWrapper? Hidden { get; set; }
}