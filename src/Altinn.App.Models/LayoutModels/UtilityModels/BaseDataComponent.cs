namespace Altinn.App.Models;

public abstract record BaseDataComponent : BaseTextComponent
{
    [JsonPropertyName("dataModelBindings")]
    [JsonPropertyOrder(3)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Dictionary<string, string> DataModelBindings { get; set; } = default!;

    [JsonPropertyName("labelSettings")]
    [JsonPropertyOrder(998)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public LabelSettings? LabelSettings { get; set; }

    [JsonPropertyName("triggers")]
    [JsonPropertyOrder(999)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<string>? Triggers { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public IEnumerable<TriggerNames> TriggerEnum
    {
        get
        {
            return Triggers?.Select(trigger => trigger switch
            {
                "validation" => TriggerNames.validation,
                "validatePage" => TriggerNames.validatePage,
                "validateAllPages" => TriggerNames.validateAllPages,
                "calculatePageOrder" => TriggerNames.calculatePageOrder,
                _ => throw new ArgumentException()
            }) ?? Enumerable.Empty<TriggerNames>();
        }
        set
        {
            Triggers = value.Select(trigger=> trigger.ToString()).ToList();
        }
    }

    public enum TriggerNames
    {
        validation,
        validatePage,
        validateAllPages,
        calculatePageOrder,
    }


}