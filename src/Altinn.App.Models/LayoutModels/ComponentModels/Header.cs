namespace Altinn.App.Models.LayoutModels.ComponentModels;

public class Header : BaseComponent
{
    [JsonPropertyName("size")]
    [JsonPropertyOrder(100)]
    public string Size { get; set; } = "h2";

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public HeaderSizes SizeEnum
    {
        get => Size switch
        {
            "h2" => HeaderSizes.H2,
            "H2" => HeaderSizes.H2,
            "L" => HeaderSizes.H2,
            "l" => HeaderSizes.H2,
            "h3" => HeaderSizes.H3,
            "H3" => HeaderSizes.H3,
            "M" => HeaderSizes.H3,
            "m" => HeaderSizes.H3,
            "h4" => HeaderSizes.H4,
            "H4" => HeaderSizes.H4,
            "S" => HeaderSizes.H4,
            "s" => HeaderSizes.H4,
            _ => HeaderSizes.INVALID
        };
        set
        {
            Size = value switch {
                HeaderSizes.H2 => "h2",
                HeaderSizes.H3 => "h3",
                HeaderSizes.H4 => "h4",
                _ => null,
            };
        }
    }

    public enum HeaderSizes
    {
        INVALID,
        H2,
        H3,
        H4,
    }
}