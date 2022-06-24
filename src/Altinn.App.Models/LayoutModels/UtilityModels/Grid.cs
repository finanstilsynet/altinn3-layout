namespace Altinn.App.Models;

public record Grid : GridProps
{
    [JsonPropertyName("innerGrid")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public GridProps? InnerGrid { get; set; }

    [JsonPropertyName("labelGrid")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public GridProps? LabelGrid { get; set; }
}

public record GridProps
{
    [JsonPropertyName("xs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Xs { get; set;}
    
    [JsonPropertyName("sm")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Sm { get; set;}

    [JsonPropertyName("md")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Md { get; set;}

    [JsonPropertyName("lg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Lg { get; set;}

    [JsonPropertyName("xl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Xl { get; set;}
}